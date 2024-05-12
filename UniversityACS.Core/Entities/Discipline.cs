namespace UniversityACS.Core.Entities;

public class Discipline
{
    public Guid Id { get; set; }
    
    public Guid? TeacherId { get; set; }
    public ApplicationUser? Teacher { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string? FieldOfStudy { get; set; }
    public string? Description { get; set; }
    public List<string>? Courses { get; set; }
}