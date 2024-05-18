using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.ScheduleServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.Schedules.Base)]
public class SchedulesController : ControllerBase
{
    private readonly IScheduleService _scheduleService;

    public SchedulesController(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }
    
    [HttpPost(ApiEndpoints.Schedules.Create)]
    public async Task<ActionResult<CreateResponseDto<ScheduleResponseDto>>> CreateAsync(ScheduleDto dto, CancellationToken cancellationToken)
    {
        var response = await _scheduleService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpPut(ApiEndpoints.Schedules.Update)]
    public async Task<ActionResult<UpdateResponseDto<ScheduleResponseDto>>> UpdateAsync(Guid id, ScheduleDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _scheduleService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpDelete(ApiEndpoints.Schedules.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _scheduleService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.Schedules.GetById)]
    public async Task<ActionResult<DetailsResponseDto<ScheduleResponseDto>>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _scheduleService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.Schedules.GetByDepartmentId)]
    public async Task<ActionResult<ListResponseDto<ScheduleResponseDto>>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken)
    {
        var response = await _scheduleService.GetByDepartmentIdAsync(departmentId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.Schedules.GetAll)]
    public async Task<ActionResult<ListResponseDto<ScheduleResponseDto>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var response = await _scheduleService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}