using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.Application.Services.SyllabusServices;

public interface ISyllabusService
{
    Task<CreateResponseDto<SyllabusDto>> CreateAsync(SyllabusDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<SyllabusDto>> UpdateAsync(Guid id, SyllabusDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<SyllabusDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<SyllabusDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ListResponseDto<SyllabusDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default!);
}