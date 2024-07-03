using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730ebu202211894.API.Assessment.Domain.Services;
using si730ebu202211894.API.Assessment.Interfaces.Rest.Resources;
using si730ebu202211894.API.Assessment.Interfaces.Rest.Transform;

namespace si730ebu202211894.API.Assessment.Interfaces;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class MentalStateExamController(IMentalStateExamCommandService mentalStateExamCommandService): ControllerBase
{
    
    [HttpPost]
    public async Task<IActionResult> CreateMentalStateExam(CreateMentalStateExamResource resource)
    {
        var createMentalStateExamCommand = CreateMentalStateExamCommandFromResourceAssembler.ToCommandFromResourceAssembler(resource);
        var mentalStateExam = await mentalStateExamCommandService.Handle(createMentalStateExamCommand);
        if (mentalStateExam is null) return BadRequest();
        var mentalStateExamResource = MentalStateExamResourceFromEntityAssembler.ToResourceFromEntity(mentalStateExam);
        return Ok(mentalStateExamResource);
    }
    
}