using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.Application.Services.ScientificAndPedagogicalActivityServices;

public interface IScientificAndPedagogicalActivityService
{
    Task<CreateResponseDto<ScientificAndPedagogicalActivityDto>> CreateAsync(ScientificAndPedagogicalActivityDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<ScientificAndPedagogicalActivityDto>> UpdateAsync(Guid id, ScientificAndPedagogicalActivityDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<ScientificAndPedagogicalActivityDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<ScientificAndPedagogicalActivityDto>> GetAllAsync(CancellationToken cancellationToken = default!);
}