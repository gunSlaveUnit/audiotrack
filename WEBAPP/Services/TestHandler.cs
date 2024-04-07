using System.Collections;
using DAL.Interfaces;
using DAL.Models;
using DAL.Models.Patient;
using DAL.Models.Test;
using WEBAPP.Interfaces;

namespace WEBAPP.Services;

public class TestHandler : ITestHandler
{
    private readonly IRepository<Record> _historyRepository;
    private readonly IRepository<PatientStatus> _patientStatusesRepository;
    private readonly IRepository<Sex> _patientsSexesRepository;
    private readonly IRepository<Patient> _patientsRepository;
    private readonly IRepository<Test> _testsRepository;

    public TestHandler(IRepository<Record> historyRepository, 
        IRepository<PatientStatus> patientStatusesRepository, 
        IRepository<Sex> patientsSexesRepository, 
        IRepository<Patient> patientsRepository,
        IRepository<Test> testsRepository)
    {
        _historyRepository = historyRepository;
        _patientStatusesRepository = patientStatusesRepository;
        _patientsSexesRepository = patientsSexesRepository;
        _patientsRepository = patientsRepository;
        _testsRepository = testsRepository;
    }

    public async Task HandleTestToChangePatientStatus(Test e)
    {
        var createdTest = await _testsRepository.CreateAsync(e);

        var existingPatientWithSameData = await FindPatientWithSameData(e);
        
        var patientStatuses = await _patientStatusesRepository.GetAsync();

        var historyChangeStatusRecord = new Record
        {
            DateChange = DateTime.Now,
        };
        
        if (existingPatientWithSameData is null)
        {
            var newPatient = new Patient
            {
                Surname = e.LastName,
                Name = e.Name,
                Patronymic = e.Othername,
                BirthDay = e.BirthDay,
                Status = patientStatuses.First(s => s.Code == (int)PossiblePatientStatuses.Codes.NEEDS_SCREENING).Id,
                Tests = new [] { createdTest.Id }
            };
            
            var availableSexes = await _patientsSexesRepository.GetAsync();
            var patientSex = availableSexes.First(s => s.Code == e.Sex);
            newPatient.Sex = patientSex.Id;
            
            var createdNewPatient = await _patientsRepository.CreateAsync(newPatient);
            
            historyChangeStatusRecord.Patient = createdNewPatient.Id;
            historyChangeStatusRecord.NewStatus = createdNewPatient.Status;
            
            await _historyRepository.CreateAsync(historyChangeStatusRecord);
            
            return;
        }

        historyChangeStatusRecord.Patient = existingPatientWithSameData.Id;

        existingPatientWithSameData.Tests = existingPatientWithSameData.Tests.Append(createdTest.Id);
        
        var amountTests = existingPatientWithSameData.Tests.Count();
        if (amountTests % 2 == 0)
        {
            IEnumerable<Test> lastTwoTests = new List<Test>();
            
            for (var i = amountTests - 1 ; i > amountTests - 3; --i)
            {
                var existingTest = await _testsRepository.GetAsync(existingPatientWithSameData.Tests.ElementAt(i));

                lastTwoTests = lastTwoTests.Append(existingTest);
            }

            var screeningPassedSuccess =
                lastTwoTests.ElementAt(0).Examinations.First().Result == (int)PossibleTestStatuses.Codes.PASSED &&
                lastTwoTests.ElementAt(1).Examinations.First().Result == (int)PossibleTestStatuses.Codes.PASSED;

            var patientStatus = 
                await _patientStatusesRepository.GetAsync(existingPatientWithSameData.Status);

            switch (patientStatus.Code)
            {
                case (int)PossiblePatientStatuses.Codes.NEEDS_SCREENING:
                    existingPatientWithSameData.Status
                        = screeningPassedSuccess
                            ? patientStatuses.First(s => s.Code == (int)PossiblePatientStatuses.Codes.SCREENING_PASSED)
                                .Id
                            : patientStatuses.First(s =>
                                s.Code == (int)PossiblePatientStatuses.Codes.NEEDS_APPOINTMENT_EXAMINATION).Id;
                    break;
                
                case (int)PossiblePatientStatuses.Codes.NEEDS_APPOINTMENT_EXAMINATION:
                    // TODO: all tests need to be scaned for contacts
                    var haveContactDetails =
                        GetEmailAddressesFromTests(lastTwoTests).Any() && 
                        GetPhonesFromTests(lastTwoTests).Any();
                    
                    if (!haveContactDetails)
                        existingPatientWithSameData.Status
                            = patientStatuses.First(s => s.Code == (int)PossiblePatientStatuses.Codes.CONTACT_INFORMATION_REQUIRED).Id;
                    break;
                
                case (int)PossiblePatientStatuses.Codes.REGISTERED_EXAMINATION:
                    // TODO: if not success, we need to analyze test results for recommendation
                    
                    existingPatientWithSameData.Status
                        = screeningPassedSuccess
                            ? patientStatuses.First(s => s.Code == (int)PossiblePatientStatuses.Codes.EXAMINATION_COMPLETED_SUCCESSFULLY)
                                .Id
                            : patientStatuses.First(s =>
                                s.Code == (int)PossiblePatientStatuses.Codes.NEEDS_REHAB).Id;
                    break;
            }
            
            historyChangeStatusRecord.NewStatus = existingPatientWithSameData.Status;
                    
            await _historyRepository.CreateAsync(historyChangeStatusRecord);
        }
        
        await _patientsRepository.UpdateAsync(existingPatientWithSameData.Id, existingPatientWithSameData);
    }
    
    private async Task<Patient?> FindPatientWithSameData(Test e)
    {
        var currentPatient = new Patient
        {
            Surname = e.LastName,
            Name = e.Name,
            Patronymic = e.Othername,
            BirthDay = e.BirthDay,
        };

        var availableSexes = await _patientsSexesRepository.GetAsync();
        var patientSex = availableSexes.First(s => s.Code == e.Sex);
        currentPatient.Sex = patientSex.Id;
        
        var existingPatients = await _patientsRepository.GetAsync();
        
        return 
            existingPatients.FirstOrDefault(
                p => 
                    p.Surname == currentPatient.Surname && 
                    p.Name == currentPatient.Name && 
                    p.Patronymic == currentPatient.Patronymic && 
                    p.BirthDay == currentPatient.BirthDay &&
                    p.Sex == currentPatient.Sex
            );
    }

    private IEnumerable<string> GetEmailAddressesFromTests(IEnumerable<Test> tests)
    {
        IEnumerable<string> emails = new List<string>();

        foreach (var test in tests)
        {
            var email = test.Email;
            if (email != "")
                emails.Append(email);
        }

        return emails;
    }
    
    private IEnumerable<string> GetPhonesFromTests(IEnumerable<Test> tests)
    {
        IEnumerable<string> phones = new List<string>();

        foreach (var test in tests)
        {
            var phone = test.Phones;
            if (phone != "")
                phones.Append(phone);
        }

        return phones;
    }
}