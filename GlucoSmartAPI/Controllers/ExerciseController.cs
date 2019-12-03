using GlucoSmart.Data;
using GlucoSmartAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlucoSmartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly GlucoSmartDb _context;
        public ExerciseController(GlucoSmartDb context)
        {
            _context = context;
        }

        //POST: api/Exercise
        [HttpPost]
        public async Task<IActionResult> NewExercise(ExerciseEntry exerciseEntry)
        {
            if (exerciseEntry != null)
            {
                _context.ExerciseEntry.Add(exerciseEntry);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //GET: api/Exercise/<username>
        [HttpGet("{username}")]
        public List<ExerciseEntry> GetExercise(string userName)
        {
            List<ExerciseEntry> userExercises = new List<ExerciseEntry>();
            List<ExerciseEntry> exercises;
            if (userName != null)
            {
                exercises = _context.ExerciseEntry.ToList();

                foreach (ExerciseEntry exercise in exercises)
                {
                    if (exercise.Username == userName)
                    {
                        userExercises.Add(exercise);
                    }
                }

                return userExercises;
            }
            else
            {
                return null;
            }
        }
    }
}
