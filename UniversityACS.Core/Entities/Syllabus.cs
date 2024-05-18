﻿namespace UniversityACS.Core.Entities;

public class Syllabus
{
    public Guid Id { get; set; }

    public Guid? TeacherId { get; set; }
    public ApplicationUser? Teacher { get; set; }
    
    public string? Name { get; set; }
    public byte[]? File { get; set; }
}