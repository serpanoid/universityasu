using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class SyllabusMappings
{
    public static Syllabus ToEntity(this SyllabusDto dto)
    {
        return new Syllabus
        {
            Id = dto.Id,
            TeacherId = dto.TeacherId,
            CourseTitle = dto.CourseTitle,
            Instructor = dto.Instructor,
            CourseDescription = dto.CourseDescription,
            GradingPolicy = dto.GradingPolicy,
            Textbooks = dto.Textbooks,
            CourseSchedule = dto.CourseSchedule
        };
    }

    public static void UpdateEntity(this Syllabus syllabus, SyllabusDto dto)
    {
        syllabus.TeacherId = dto.TeacherId;
        syllabus.CourseTitle = dto.CourseTitle;
        syllabus.Instructor = dto.Instructor;
        syllabus.CourseDescription = dto.CourseDescription;
        syllabus.GradingPolicy = dto.GradingPolicy;
        syllabus.Textbooks = dto.Textbooks;
        syllabus.CourseSchedule = dto.CourseSchedule;
    }

    public static SyllabusDto ToDto(this Syllabus syllabus)
    {
        return new SyllabusDto
        {
            Id = syllabus.Id,
            TeacherId = syllabus.TeacherId,
            CourseTitle = syllabus.CourseTitle,
            Instructor = syllabus.Instructor,
            CourseDescription = syllabus.CourseDescription,
            GradingPolicy = syllabus.GradingPolicy,
            Textbooks = syllabus.Textbooks,
            CourseSchedule = syllabus.CourseSchedule
        };
    }
}