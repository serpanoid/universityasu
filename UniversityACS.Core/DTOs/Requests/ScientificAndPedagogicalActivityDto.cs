namespace UniversityACS.Core.DTOs.Requests;

public class ScientificAndPedagogicalActivityDto
{
    public Guid Id { get; set; }

    public Guid? TeacherId { get; set; }
    
    public string? ActivityTitle { get; set; }
    public string? FieldOfStudy { get; set; }
    public DateTime ActivityDate { get; set; }
    public string? Location { get; set; }
    public List<string>? Participants { get; set; }
    public string? Description { get; set; }
    public string? Findings { get; set; }
}