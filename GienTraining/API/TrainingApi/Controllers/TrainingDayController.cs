using Microsoft.AspNetCore.Mvc;
using TrainingApi.Dto.Training;
using TrainingApi.Interfaces.Repository;
using TrainingApi.Mappers;

namespace TrainingApi.Controllers;

[ApiController]
[Route("/api/TrainingPlan/{planId:int}/[controller]")]
public class TrainingDayController : ControllerBase
{
    private readonly ITrainingDayRepository _trainingDayRepository;
    private readonly ITrainingPlanRepository _trainingPlanRepository;

    public TrainingDayController(ITrainingDayRepository trainingDayRepository, ITrainingPlanRepository trainingPlanRepository)
    {
        _trainingDayRepository = trainingDayRepository;
        _trainingPlanRepository = trainingPlanRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetByPlanId(int planId)
    {
        var plan = await _trainingPlanRepository.GetByIdAsync(planId);
        if(plan == null)
            return NotFound();
        
        var workouts = await _trainingDayRepository.GetAllAsync(planId);

        var workoutsDto = workouts.Select(x => x.ToDto());
        
        return Ok(workoutsDto);
    }

    [HttpGet("{dayId:int}")]
    public async Task<IActionResult> GetById(int dayId)
    {
        var day = await _trainingDayRepository.GetByIdAsync(dayId);
        if(day == null)
            return NotFound();
        
        return Ok(day);
    }

    [HttpPost]
    public async Task<IActionResult> Create(int planId,[FromBody] CreateTrainingDayDto trainingDay)
    {
        var plan = await _trainingPlanRepository.GetByIdAsync(planId);
        if(plan == null)
            return NotFound();

        var day = trainingDay.ToTrainingDay();
        day.TrainingPlanId = planId;
        day.TrainingPlan = plan;

        await _trainingDayRepository.CreateAsync(day);
        
        return CreatedAtAction(nameof(GetById), new { id = day.Id }, day);
    }
}