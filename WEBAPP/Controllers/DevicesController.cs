using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using WEBAPI.Interfaces;
using WEBAPP.Controllers.Base;

namespace WEBAPI.Controllers;

[ApiController]
[Route("api/devices")]
public class DevicesController : CrudController<Device>
{
    private readonly ICodesService _codesService;
    private readonly IRepository<DAL.Models.DeviceLinkInfo> _codesRepository;
    private readonly IRepository<Device> _devicesRepository;

    public DevicesController(IRepository<DAL.Models.DeviceLinkInfo> codesRepository,
        IRepository<Device> devicesRepository,
        ICodesService codesService) : base(devicesRepository)
    {
        _codesService = codesService;
        _codesRepository = codesRepository;
        _devicesRepository = devicesRepository;
    }
    
    #region LINK

    public class DevicePreLinkInfo
    {
        [Required]
        [JsonPropertyName("region")]
        public string Region { get; set; }
        
        [Required]
        [JsonPropertyName("institution")]
        public string Institution { get; set; }
    }

    [HttpPost("prelink")]
    public async Task<IActionResult> GetCode(DevicePreLinkInfo devicePreLinkInfo)
    {
        var generatedCode = _codesService.GenerateNumericCode();
        var code = new DeviceLinkInfo
        {
            Code = generatedCode,
            Region = devicePreLinkInfo.Region,
            Institution = devicePreLinkInfo.Institution
        };

        await _codesRepository.CreateAsync(code);
        
        return CreatedAtAction(nameof(GetCode), new { id = code.Id }, code);
    }
    
    public class LinkRequest
    {
        [BsonElement("pin")]
        [JsonPropertyName("pin")]
        public string Pin { get; set; }
        
        [BsonElement("device_serial_number")]
        [JsonPropertyName("device_serial_number")]
        public string DeviceSerialNumber { get; set; }
    }
    
    [HttpPost("link")]
    public async Task<IActionResult> Link(LinkRequest linkInfo)
    {
        var availableCodes = await _codesRepository.GetAsync();
        var code = availableCodes.FirstOrDefault(x => x.Code == linkInfo.Pin);

        if (code is null)
            return NotFound(new {
                message = "Данного кода подтверждения не существует"
            });

        var devices = await _devicesRepository.GetAsync();
        var existingDevice = devices.FirstOrDefault(d => d.SerialNumber == linkInfo.DeviceSerialNumber);

        if (existingDevice is not null)
        {
            await _codesRepository.RemoveAsync(code.Id);
            
            return BadRequest( new {
                message = "Данное устройство уже привязано. Сначала отвяжите его"
            });
        }
        
        var token = _codesService.GenerateToken();

        var device = new Device()
        {
            AccessToken = token,
            SerialNumber = linkInfo.DeviceSerialNumber,
            Region = code.Region,
            Institution = code.Institution
        };
        
        await Repository.CreateAsync(device);

        if (code.Id == null) 
            return NoContent();
        
        await _codesRepository.RemoveAsync(code.Id);

        return CreatedAtAction(nameof(Link), new { id = device.Id }, device);
    }
    
    #endregion
}