using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Perscription.Models;

namespace Perscription.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PrescriptionController(MyDbContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet("{name},{lastName},{docName},{docLastName},{medicament}")]
        public async Task<IActionResult> Get(string name, string lastName, string docName, string docLastName, string medicament)
        {
             var patientId = await _context.Patients.FirstOrDefaultAsync(e => e.FirstName == name &&  e.LastName == lastName);

            if (patientId == null)
            {
                return NotFound("Patient not found");
            }

            var doctorId = await _context.Doctors.FirstOrDefaultAsync(e => e.FirstName==docName && e.LastName==docLastName);
            
            if (doctorId == null)
            {
                return NotFound("Doctor not found");
            }

            var perscriptionId = await _context.Perscriptions.FirstOrDefaultAsync(e => e.IdPatient == patientId.IdPatient && e.IdDoctor == doctorId.IdDoctor);
            
            if (perscriptionId == null)
            {
                return NotFound("Perscription not found");
            }

            var medId = await _context.Medicaments.FirstOrDefaultAsync(e => e.Name== medicament);
            
            if (medId == null)
            {
                return NotFound("Medicament not found");
            }

            var res = _context.PerscriptionMedicaments.Where(e => e.IdMedicament == medId.IdMedicament && e.IdPrescription == perscriptionId.IdPrescription)
                .Select(e => new
                {
                    IdMedicament = e.IdMedicament,
                    IdPrescription = e.IdPrescription,
                    Dose = e.Dose,
                    Details = e.Details
                });

            if (res.IsNullOrEmpty())
            {
                return NoContent();
            }

            return Ok(res);


           
        }
        

        
    }
}
