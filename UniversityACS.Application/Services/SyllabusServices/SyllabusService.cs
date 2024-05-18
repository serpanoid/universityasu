using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.SyllabusServices;

public class SyllabusService : ISyllabusService
{
    private readonly ApplicationDbContext _context;

    public SyllabusService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateResponseDto<SyllabusDto>> CreateAsync(SyllabusDto dto, CancellationToken cancellationToken)
    {
        var syllabus = dto.ToEntity();
        
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            syllabus.File = memoryStream.ToArray();
        }
        
        await _context.Syllabi.AddAsync(syllabus, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return new CreateResponseDto<SyllabusDto>
        {
            Success = true, 
            Id = syllabus.Id
        };
    }

    public async Task<UpdateResponseDto<SyllabusDto>> UpdateAsync(Guid id, SyllabusDto dto, CancellationToken cancellationToken)
    {
        var existingSyllabus = await _context.Syllabi
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingSyllabus == null)
        {
            return new UpdateResponseDto<SyllabusDto>
            {
                Success = false, 
                ErrorMessage = "Syllabus not found"
            };
        }
        
        existingSyllabus.UpdateEntity(dto);
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            existingSyllabus.File = memoryStream.ToArray();
        }
        
        _context.Syllabi.Update(existingSyllabus);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<SyllabusDto>
        {
            Success = true, 
            Id = existingSyllabus.Id
        };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingSyllabus = await _context.Syllabi
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingSyllabus == null)
        {
            return new ResponseDto()
            {
                Success = false, 
                ErrorMessage = "Syllabus not found"
            };
        }
        
        _context.Syllabi.Remove(existingSyllabus);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<SyllabusResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingSyllabus = await _context.Syllabi
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingSyllabus == null)
        {
            return new DetailsResponseDto<SyllabusResponseDto>
            {
                Success = false, 
                ErrorMessage = "Syllabus not found"
            };
        }
        
        return new DetailsResponseDto<SyllabusResponseDto> 
        { 
            Success = true, 
            Item = existingSyllabus.ToDto()
        };
    }

    public async Task<ListResponseDto<SyllabusResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var syllabi = await _context.Syllabi
            .ToListAsync(cancellationToken);

        return new ListResponseDto<SyllabusResponseDto>()
        {
            Items = syllabi.Select(x => x.ToDto()).ToList(),
            TotalCount = syllabi.Count,
            Success = true
        };
    }

    public async Task<ListResponseDto<SyllabusResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var syllabi = await _context.Syllabi
            .Where(x=>x.TeacherId == userId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<SyllabusResponseDto>()
        {
            Items = syllabi.Select(x => x.ToDto()).ToList(),
            TotalCount = syllabi.Count,
            Success = true
        };
    }
}