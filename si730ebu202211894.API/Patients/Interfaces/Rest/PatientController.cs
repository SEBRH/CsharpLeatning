using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730ebu202211894.API.Patients.Domain.Services;
using si730ebu202211894.API.Patients.Interfaces.Rest.Resource;
using si730ebu202211894.API.Patients.Interfaces.Rest.Transform;

namespace si730ebu202211894.API.Patients.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PatientController(IPatientCommandService patientCommandService): ControllerBase
{
    
    [HttpPost]
    public async Task<IActionResult> CreatePatient(CreatePatientResource resource)
    {
        var createPatientCommand = CreatePatientResourceFromResourceAssembler.ToCommandFromResource(resource);
        var patient = await patientCommandService.Handle(createPatientCommand);
        if (patient is null) return BadRequest();
        var patientResource = PatientResourceFromEntityAssembler.ToResourceFromEntity(patient);
        return Ok(patientResource);
    }
    
}