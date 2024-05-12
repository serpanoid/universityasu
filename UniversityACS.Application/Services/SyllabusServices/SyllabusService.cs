using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
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
        await _context.Syllabi.AddAsync(syllabus, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return new CreateResponseDto<SyllabusDto>
        {
            Success = true, 
            Item = syllabus.ToDto(), 
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
        _context.Syllabi.Update(existingSyllabus);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<SyllabusDto>
        {
            Success = true, 
            Item = existingSyllabus.ToDto(), 
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

    public async Task<DetailsResponseDto<SyllabusDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingSyllabus = await _context.Syllabi
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingSyllabus == null)
        {
            return new DetailsResponseDto<SyllabusDto>
            {
                Success = false, 
                ErrorMessage = "Syllabus not found"
            };
        }
        
        return new DetailsResponseDto<SyllabusDto> { 
            Success = true, 
            Item = existingSyllabus.ToDto()
        };
    }

    public async Task<ListResponseDto<SyllabusDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var syllabi = await _context.Syllabi
            .ToListAsync(cancellationToken);

        return new ListResponseDto<SyllabusDto>()
        {
            Items = syllabi.Select(x => x.ToDto()).ToList(),
            TotalCount = syllabi.Count,
            Success = true
        };
    }

    public async Task<ListResponseDto<SyllabusDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var syllabi = await _context.Syllabi
            .Where(x=>x.TeacherId == userId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<SyllabusDto>()
        {
            Items = syllabi.Select(x => x.ToDto()).ToList(),
            TotalCount = syllabi.Count,
            Success = true
        };
    }
}