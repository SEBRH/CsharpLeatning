using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730ebu202211894.API.Personel.Domain.Services;
using si730ebu202211894.API.Personel.Interfaces.Rest.Resources;
using si730ebu202211894.API.Personel.Interfaces.Rest.Transform;

namespace si730ebu202211894.API.Personel.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ExaminerController(IExaminerCommandService examinerCommandService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateExaminer(CreateExaminerResource resource)
    {
        var createExaminerCommand = CreateExaminerFromResourceAssembler.ToCommandFromResourceAssembler(resource);
        var examiner = await examinerCommandService.Handle(createExaminerCommand);
        if (examiner is null) return BadRequest();
        var examinerResource = ExaminerResourceFromEntityAssembler.ToResourceFromEntity(examiner);
        return Ok(examinerResource);
    }
}