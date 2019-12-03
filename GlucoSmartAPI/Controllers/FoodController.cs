using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlucoSmart.Data;
using GlucoSmartAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlucoSmartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly GlucoSmartDb _context;
        public FoodController(GlucoSmartDb context)
        {
            _context = context;
        }

        //POST: api/Food
        [HttpPost]
        public async Task<IActionResult> NewFood(FoodEntry foodEntry)
        {
            if (foodEntry != null)
            {
                _context.FoodEntry.Add(foodEntry);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //GET: api/Food/<username>
        [HttpGet("{username}")]
        public List<FoodEntry> GetFood(string userName)
        {
            List<FoodEntry> userFoods = new List<FoodEntry>();
            List<FoodEntry> foods;
            if (userName != null)
            {
                foods = _context.FoodEntry.ToList();

                foreach(FoodEntry food in foods)
                {
                    if (food.Username == userName)
                    {
                        userFoods.Add(food);
                    }
                }

                return userFoods;
            }
            else
            {
                return null;
            }
        }
    }
}
