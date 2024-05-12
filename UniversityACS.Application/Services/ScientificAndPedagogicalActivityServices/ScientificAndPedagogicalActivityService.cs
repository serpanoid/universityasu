using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.ScientificAndPedagogicalActivityServices;

public class ScientificAndPedagogicalActivityService : IScientificAndPedagogicalActivityService
{
    private readonly ApplicationDbContext _context;

    public ScientificAndPedagogicalActivityService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateResponseDto<ScientificAndPedagogicalActivityDto>> CreateAsync(
        ScientificAndPedagogicalActivityDto dto, CancellationToken cancellationToken)
    {
        var activity = dto.ToEntity();

        await _context.ScientificAndPedagogicalActivities.AddAsync(activity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return new CreateResponseDto<ScientificAndPedagogicalActivityDto>
        {
            Success = true, Item = activity.ToDto(), Id = activity.Id
        };
    }

    public async Task<UpdateResponseDto<ScientificAndPedagogicalActivityDto>> UpdateAsync(Guid id, 
        ScientificAndPedagogicalActivityDto dto, CancellationToken cancellationToken)
    {
        var existingActivity = await _context.ScientificAndPedagogicalActivities
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingActivity == null)
        {
            return new UpdateResponseDto<ScientificAndPedagogicalActivityDto>
            {
                Success = false, ErrorMessage = "Activity not found"
            };
        }
        
        existingActivity.UpdateEntity(dto);
        _context.ScientificAndPedagogicalActivities.Update(existingActivity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<ScientificAndPedagogicalActivityDto>
        {
            Success = true, Item = existingActivity.ToDto(), Id = existingActivity.Id
        };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingActivity = await _context.ScientificAndPedagogicalActivities
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingActivity == null)
        {
            return new ResponseDto()
            {
                Success = false, ErrorMessage = "Activity not found"
            };
        }
        
        _context.ScientificAndPedagogicalActivities.Remove(existingActivity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<ScientificAndPedagogicalActivityDto>> GetByIdAsync(Guid id, 
        CancellationToken cancellationToken)
    {
        var existingActivity = await _context.ScientificAndPedagogicalActivities
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingActivity == null)
        {
            return new DetailsResponseDto<ScientificAndPedagogicalActivityDto>
            {
                Success = false, ErrorMessage = "Activity not found"
            };
        }
        
        return new DetailsResponseDto<ScientificAndPedagogicalActivityDto>
        {
            Success = true, Item = existingActivity.ToDto()
        };
    }

    public async Task<ListResponseDto<ScientificAndPedagogicalActivityDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var activities = await _context.ScientificAndPedagogicalActivities
            .ToListAsync(cancellationToken);
        
        return new ListResponseDto<ScientificAndPedagogicalActivityDto>
        {
            Success = true, 
            Items = activities.Select(a => a.ToDto()).ToList(), 
            TotalCount = activities.Count
        };
    }
}