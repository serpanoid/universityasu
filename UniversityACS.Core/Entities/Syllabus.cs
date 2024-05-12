﻿namespace UniversityACS.Core.Entities;

public class Syllabus
{
    public Guid Id { get; set; }

    public Guid? TeacherId { get; set; }
    public ApplicationUser? Teacher { get; set; }
    
    public string? CourseTitle { get; set; }
    public string? Instructor { get; set; }
    public string? CourseDescription { get; set; }
    public string? GradingPolicy { get; set; }
    public List<string>? Textbooks { get; set; }
    public List<string>? CourseSchedule { get; set; } 
}