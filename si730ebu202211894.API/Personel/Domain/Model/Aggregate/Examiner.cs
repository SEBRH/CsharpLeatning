using System.ComponentModel.DataAnnotations.Schema;
using si730ebu202211894.API.Personel.Domain.Model.Command;
using si730ebu202211894.API.Personel.Domain.Model.Entities;
using si730ebu202211894.API.Personel.Domain.Model.ValueObject;

namespace si730ebu202211894.API.Personel.Domain.Model.Aggregate;

public partial class Examiner
{
    public int Id  { get; set; }
    
    public string NationalProviderIdentifier { get; set; }

    /// <summary>
    ///  Examiner Full Name
    /// </summary>
    public ExaminerFullName Name { get; set; }
    
    public string FullName => Name.FullName;

    /// <summary>
    ///  Examiner Type
    /// </summary>
    public int ExaminerTypeId { get; set; }
    
    [ForeignKey("ExaminerTypeId")]
    public ExaminerType ExaminerType { get; set; }
    
    public string ExaminerTypeName => ExaminerType.Name;
    
    
    
    
    
    
    
    public Examiner()
    {
        Name = new ExaminerFullName();
    }

    public Examiner(CreateExaminerCommand command)
    {
        
        Name = new ExaminerFullName(command.FirstName, command.LastName);
        NationalProviderIdentifier = command.NationalProviderIdentifier;
        ExaminerTypeId = command.ExaminerTypeId;
    }
    
}