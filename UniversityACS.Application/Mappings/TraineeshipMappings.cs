using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class TraineeshipMappings
{
    public static Traineeship ToEntity(this TraineeshipDto dto)
    {
        return new Traineeship
        {
            Id = dto.Id,
            TraineeId = dto.TraineeId,
            Company = dto.Company,
            Position = dto.Position,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Salary = dto.Salary
        };
    }

    public static void UpdateEntity(this Traineeship traineeship, TraineeshipDto dto)
    {
        traineeship.TraineeId = dto.TraineeId;
        traineeship.Company = dto.Company;
        traineeship.Position = dto.Position;
        traineeship.StartDate = dto.StartDate;
        traineeship.EndDate = dto.EndDate;
        traineeship.Salary = dto.Salary;
    }

    public static TraineeshipDto ToDto(this Traineeship traineeship)
    {
        return new TraineeshipDto
        {
            Id = traineeship.Id,
            TraineeId = traineeship.TraineeId,
            Company = traineeship.Company,
            Position = traineeship.Position,
            StartDate = traineeship.StartDate,
            EndDate = traineeship.EndDate,
            Salary = traineeship.Salary
        };
    }
}