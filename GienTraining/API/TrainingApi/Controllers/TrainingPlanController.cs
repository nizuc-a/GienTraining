using Microsoft.AspNetCore.Mvc;
using TrainingApi.Dto.Training;
using TrainingApi.Helpers;
using TrainingApi.Interfaces.Repository;
using TrainingApi.Mappers;

namespace TrainingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrainingPlanController : ControllerBase
{
    private readonly ITrainingPlanRepository _trainingPlanRepository;

    public TrainingPlanController(ITrainingPlanRepository trainingPlanRepository)
    {
        _trainingPlanRepository = trainingPlanRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] TrainingQueryObject query)
    {
        var plans = await _trainingPlanRepository.GetAllAsync(query);

        var plansDto = plans.Select(x => x.ToDto());

        return Ok(plansDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var plan = await _trainingPlanRepository.GetByIdAsync(id);

        if (plan is null)
        {
            return NotFound();
        }
        
        return Ok(plan);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateTrainingPlanDto trainingPlanDto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var plan = trainingPlanDto.ToPlan();

        await _trainingPlanRepository.CreateAsync(plan);
        
        return CreatedAtAction(nameof(GetById), new { id = plan.Id }, plan);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var plan = await _trainingPlanRepository.GetByIdAsync(id);
        
        return plan is null ? NotFound() : NoContent();
    }
}