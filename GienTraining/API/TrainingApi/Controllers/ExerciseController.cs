using DataModel.Model;
using Microsoft.AspNetCore.Mvc;
using TrainingApi.Interfaces.Repository;

namespace TrainingApi.Controllers;

[ApiController]
[Route("/api/TrainingDay/{dayId:int}/[controller]")]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly ITrainingDayRepository _trainingDayRepository;

    public ExerciseController(IExerciseRepository exerciseRepository, ITrainingDayRepository trainingDayRepository)
    {
        _exerciseRepository = exerciseRepository;
        _trainingDayRepository = trainingDayRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetByDayId(int dayId)
    {
        var day = await _trainingDayRepository.GetByIdAsync(dayId);
        if(day == null)
            return NotFound();
        
        var workouts = await _exerciseRepository.GetAllAsync(dayId);
        
        return Ok(workouts);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetById(int excerciseId)
    {
        var workouts = await _exerciseRepository.GetByIdAsync(excerciseId);
        if(workouts == null)
            return NotFound();
        
        return Ok(workouts);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(int dayId,[FromBody] Exercise exercise)
    {
        var day = await _trainingDayRepository.GetByIdAsync(dayId);
        if(day == null)
            return NotFound();

        await _exerciseRepository.CreateAsync(exercise);
        
        return CreatedAtAction(nameof(GetById), new { id = exercise.Id }, exercise);
    }
}