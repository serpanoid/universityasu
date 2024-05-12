namespace UniversityACS.Core.DTOs.Requests;

public class TraineeshipDto
{
    public Guid Id { get; set; }

    public Guid? TraineeId { get; set; }
    
    public string? Company { get; set; }
    public string? Position { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Salary { get; set; }
}