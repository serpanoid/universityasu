﻿using Microsoft.AspNetCore.Http;

namespace UniversityACS.Core.DTOs.Requests;

public class ScheduleDto
{
    public Guid Id { get; set; }

    public Guid? DepartmentId { get; set; }
    
    public string? Name { get; set; }
    public IFormFile? File { get; set; }
}