using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.ApplicationUserServices;

public class ApplicationUserService : IApplicationUserService
{
    private readonly ApplicationDbContext _context;

    public ApplicationUserService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateResponseDto<ApplicationUserDto>> CreateAsync(ApplicationUserDto dto, CancellationToken cancellationToken)
    {
        var existingUser = await _context.ApplicationUsers
            .FirstOrDefaultAsync(x => x.UserName == dto.UserName, cancellationToken);

        if (existingUser != null)
        {
            return new CreateResponseDto<ApplicationUserDto>()
            {
                Success = false,
                ErrorMessage = "User with the same username already exists."
            };
        }

        if (dto.Password == null)
        {
            return new CreateResponseDto<ApplicationUserDto>()
            {
                Success = false, 
                ErrorMessage = "Password is required."
            };
        }
        
        var hasher = new PasswordHasher<ApplicationUser>();
        
        var newUser = dto.ToEntity();
        newUser.PasswordHash = hasher.HashPassword(newUser, dto.Password);

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync(cancellationToken);
        
        return new CreateResponseDto<ApplicationUserDto>()
        {
            Success = true, 
            Item = newUser.ToDto(), 
            Id = newUser.Id
        };
    }

    public async Task<UpdateResponseDto<ApplicationUserDto>> UpdateAsync(Guid id, ApplicationUserDto dto, CancellationToken cancellationToken)
    {
        var existingUser = await _context.ApplicationUsers
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingUser == null)
        {
            return new UpdateResponseDto<ApplicationUserDto>()
            {
                Success = false,
                ErrorMessage = "User not found"
            };
        }
        
        existingUser.UpdateEntity(dto);
        _context.ApplicationUsers.Update(existingUser);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<ApplicationUserDto>()
        {
            Success = true,
            Item = existingUser.ToDto(),
            Id = existingUser.Id
        };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingUser = await _context.ApplicationUsers
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        if (existingUser == null)
        {
            return new UpdateResponseDto<ApplicationUserDto>()
            {
                Success = false,
                ErrorMessage = "User not found"
            };
        }
        
        _context.ApplicationUsers.Remove(existingUser);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<ApplicationUserDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingUser = await _context.ApplicationUsers
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        if (existingUser == null)
        {
            return new DetailsResponseDto<ApplicationUserDto>()
            {
                Success = false,
                ErrorMessage = "User not found"
            };
        }

        return new DetailsResponseDto<ApplicationUserDto>()
        {
            Item = existingUser.ToDto(),
            Success = true
        };
    }

    public async Task<ListResponseDto<ApplicationUserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var users = await _context.ApplicationUsers.ToListAsync(cancellationToken);

        return new ListResponseDto<ApplicationUserDto>()
        {
            Items = users.Select(u => u.ToDto()).ToList(),
            TotalCount = users.Count,
            Success = true
        };
    }

    public async Task<ListResponseDto<ApplicationUserDto>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken)
    {
        var users = await _context.ApplicationUsers
            .Where(x=>x.DepartmentId == departmentId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<ApplicationUserDto>()
        {
            Items = users.Select(u => u.ToDto()).ToList(),
            TotalCount = users.Count,
            Success = true
        };
    }

    public async Task<ResponseDto> ChangePasswordAsync(ChangePasswordDto changePasswordDto, CancellationToken cancellationToken)
    {
        var existingUser = await _context.ApplicationUsers
            .FirstOrDefaultAsync(x => x.Id == changePasswordDto.UserId, cancellationToken);

        if (existingUser == null)
        {
            return new ResponseDto() { Success = false, ErrorMessage = "User not found" };
        }
        
        var hasher = new PasswordHasher<ApplicationUser>();
        var passwordVerificationResult =
            hasher.VerifyHashedPassword(existingUser, existingUser.PasswordHash, changePasswordDto.OldPass);

        if (passwordVerificationResult != PasswordVerificationResult.Success)
        {
            return new ResponseDto() { Success = false, ErrorMessage = "Invalid old password" };
        }

        existingUser.PasswordHash = hasher.HashPassword(existingUser, changePasswordDto.NewPass);
        _context.ApplicationUsers.Update(existingUser);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }
}