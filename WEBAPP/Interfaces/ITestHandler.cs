using DAL.Models.Test;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPP.Interfaces;

public interface ITestHandler
{
    public Task HandleTestToChangePatientStatus(Test e);
}