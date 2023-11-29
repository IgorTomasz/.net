using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Perscription.Models;
using Perscription.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Perscription.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;

        public DoctorsController(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Doctors.Select(e=> new
            {
                IdDoctor = e.IdDoctor,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email
            }).ToListAsync());
        }

		[HttpGet("/{docId}")]
		public async Task<IActionResult> Get(int docId)
		{
			return Ok(await _context.Doctors.Where(e=> e.IdDoctor==docId).Select(e => new
			{
				IdDoctor = e.IdDoctor,
				FirstName = e.FirstName,
				LastName = e.LastName,
				Email = e.Email
			}).ToListAsync());
		}

		[Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(AddDoctor addDoctor)
        {
        

            await _context.Doctors.AddAsync(new Doctor
            {
                FirstName = addDoctor.FirstName,
                LastName = addDoctor.LastName,
                Email = addDoctor.Email
            });
            _context.SaveChanges();
            return Created($"Doctor was added",addDoctor.FirstName);
        }

        [Authorize]
        [HttpPut("{index}")]
        public async Task<IActionResult> UpdateDoctor(string index, AddDoctor addDoctor)
        {
            var existingDoc =  await _context.Doctors.FindAsync(int.Parse(index));

            if (existingDoc==null){
                return NotFound();
            }

            existingDoc.FirstName = addDoctor.FirstName;
            existingDoc.LastName = addDoctor.LastName;
            existingDoc.Email = addDoctor.Email;

            _context.SaveChanges();
            return Ok(existingDoc);
            
        }

        [Authorize]
        [HttpDelete("{index}")]
        public async Task<IActionResult> DeleteDoctor(string index)
        {
            var existingDoc = await _context.Doctors.FindAsync(int.Parse(index));

            if (existingDoc == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(existingDoc);
            _context.SaveChanges();
            return Ok();
        }

        
    }
}
