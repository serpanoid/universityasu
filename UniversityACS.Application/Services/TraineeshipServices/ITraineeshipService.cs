using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.Application.Services.TraineeshipServices;

public interface ITraineeshipService
{
    Task<CreateResponseDto<TraineeshipDto>> CreateAsync(TraineeshipDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<TraineeshipDto>> UpdateAsync(Guid id, TraineeshipDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<TraineeshipDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<TraineeshipDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ListResponseDto<TraineeshipDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default!);
}