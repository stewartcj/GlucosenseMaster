using GlucoSmart.Data;
using GlucoSmartAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GlucoSmartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlucoseController : ControllerBase
    {
        private readonly GlucoSmartDb _context;
        public GlucoseController(GlucoSmartDb context)
        {
            _context = context;
        }

        //POST: api/Glucose
        [HttpPost]
        public async Task<IActionResult> NewGlucose(GlucoseEntry glucoseEntry)
        {
            if (ModelState.IsValid)
            {
                _context.GlucoseEntry.Add(glucoseEntry);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //GET: api/Glucose/<username>
        [HttpGet("{username}")]
        public List<GlucoseEntry> GetGlucose(string userName)
        {
            List<GlucoseEntry> userGlucose = new List<GlucoseEntry>();
            List<GlucoseEntry> glucose;
            if (userName != null)
            {
                glucose = _context.GlucoseEntry.ToList();

                foreach (GlucoseEntry glu in glucose)
                {
                    if (glu.Username == userName)
                    {
                        userGlucose.Add(glu);
                    }
                }

                return userGlucose;
            }
            else
            {
                return null;
            }
        }
    }
}
