using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Services.ApplicationUserServices;

public interface IApplicationUserService
{
    Task<CreateResponseDto<ApplicationUserDto>> CreateAsync(ApplicationUserDto dto, CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<ApplicationUserDto>> UpdateAsync(Guid id, ApplicationUserDto dto, CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<ApplicationUserDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<ApplicationUserDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ListResponseDto<ApplicationUserDto>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken = default!);
    Task<ResponseDto> ChangePasswordAsync(ChangePasswordDto changePasswordDto, CancellationToken cancellationToken = default!);
}