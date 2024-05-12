using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class ApplicationUserMappings
{
    public static ApplicationUser ToEntity(this ApplicationUserDto dto)
    {
        return new ApplicationUser
        {
            UserName = dto.UserName,
            Email = dto.Email,
            DepartmentEmail = dto.DepartmentEmail,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            DepartmentId = dto.DepartmentId,
            PhoneNumber = dto.PhoneNumber
        };
    }

    public static void UpdateEntity(this ApplicationUser user, ApplicationUserDto dto)
    {
        user.UserName = dto.UserName;
        user.Email = dto.Email;
        user.DepartmentEmail = dto.DepartmentEmail;
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.DepartmentId = dto.DepartmentId;
        user.PhoneNumber = dto.PhoneNumber;
    }

    public static ApplicationUserDto ToDto(this ApplicationUser user)
    {
        return new ApplicationUserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            DepartmentEmail = user.DepartmentEmail,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DepartmentId = user.DepartmentId,
            PhoneNumber = user.PhoneNumber
        };
    }
}