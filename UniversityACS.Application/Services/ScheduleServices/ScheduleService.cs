using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.ScheduleServices;

public class ScheduleService : IScheduleService
{
    private readonly ApplicationDbContext _context;

    public ScheduleService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateResponseDto<ScheduleDto>> CreateAsync(ScheduleDto dto, CancellationToken cancellationToken)
    {
        var entity = dto.ToEntity();

        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }

        await _context.Schedules.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<ScheduleDto>()
        {
            Success = true,
            Id = entity.Id
        };
    }

    public async Task<UpdateResponseDto<ScheduleDto>> UpdateAsync(Guid id, ScheduleDto dto, CancellationToken cancellationToken)
    {
        var entity = await _context.Schedules
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new UpdateResponseDto<ScheduleDto>()
            {
                Success = false, ErrorMessage = "Schedule not found"
            };
        }
        
        entity.UpdateEntity(dto);
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }
        
        _context.Schedules.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<ScheduleDto>() { Success = true, Id = entity.Id };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.Schedules
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new ResponseDto()
            {
                Success = false, ErrorMessage = "Schedule not found"
            };
        }
        
        _context.Schedules.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<ScheduleResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.Schedules
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new DetailsResponseDto<ScheduleResponseDto>()
            {
                Success = false, ErrorMessage = "Schedule not found"
            };
        }

        return new DetailsResponseDto<ScheduleResponseDto>()
        {
            Success = true,
            Item = entity.ToDto()
        };
    }

    public async Task<ListResponseDto<ScheduleResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.Schedules
            .ToListAsync(cancellationToken);

        return new ListResponseDto<ScheduleResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }

    public async Task<ListResponseDto<ScheduleResponseDto>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken)
    {
        var entities = await _context.Schedules
            .Where(x=>x.DepartmentId == departmentId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<ScheduleResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }
}