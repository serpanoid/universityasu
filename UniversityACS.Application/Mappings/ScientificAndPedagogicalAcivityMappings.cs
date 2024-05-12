using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class ScientificAndPedagogicalAcivityMappings
{
    public static ScientificAndPedagogicalActivity ToEntity(this ScientificAndPedagogicalActivityDto dto)
    {
        return new ScientificAndPedagogicalActivity
        {
            Id = dto.Id,
            TeacherId = dto.TeacherId,
            ActivityTitle = dto.ActivityTitle,
            FieldOfStudy = dto.FieldOfStudy,
            ActivityDate = dto.ActivityDate,
            Location = dto.Location,
            Participants = dto.Participants,
            Description = dto.Description,
            Findings = dto.Findings
        };
    }

    public static void UpdateEntity(this ScientificAndPedagogicalActivity entity,
        ScientificAndPedagogicalActivityDto dto)
    {
        entity.TeacherId = dto.TeacherId;
        entity.ActivityTitle = dto.ActivityTitle;
        entity.FieldOfStudy = dto.FieldOfStudy;
        entity.ActivityDate = dto.ActivityDate;
        entity.Location = dto.Location;
        entity.Participants = dto.Participants;
        entity.Description = dto.Description;
        entity.Findings = dto.Findings;
    }

    public static ScientificAndPedagogicalActivityDto ToDto(this ScientificAndPedagogicalActivity entity)
    {
        return new ScientificAndPedagogicalActivityDto
        {
            Id = entity.Id,
            TeacherId = entity.TeacherId,
            ActivityTitle = entity.ActivityTitle,
            FieldOfStudy = entity.FieldOfStudy,
            ActivityDate = entity.ActivityDate,
            Location = entity.Location,
            Participants = entity.Participants,
            Description = entity.Description,
            Findings = entity.Findings
        };
    }
}