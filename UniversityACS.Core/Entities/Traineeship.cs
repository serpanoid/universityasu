namespace UniversityACS.Core.Entities;

public class Traineeship
{
    public Guid Id { get; set; }

    public Guid? TraineeId { get; set; }
    public ApplicationUser? Trainee { get; set; }
    
    public string? Company { get; set; }
    public string? Position { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Salary { get; set; }
}