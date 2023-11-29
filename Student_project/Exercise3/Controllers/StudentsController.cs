using Exercise3.Models;
using Exercise3.Models.DTOs;
using Exercise3.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Exercise3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;
        public StudentsController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(_studentsRepository.GetStudents());
            }catch(Exception ex)
            {
                return Problem();
            }
            
            //throw new NotImplementedException();
        }

        [HttpGet("{index}")]
        public async Task<IActionResult> Get(string index)
        {
            var student = _studentsRepository.GetStudents().Where(e => e.IndexNumber == index).FirstOrDefault();
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);

            //throw new NotImplementedException();
        }

        [HttpPut("{index}")]
        public async Task<IActionResult> Put(string index, StudentPUT newStudentData)
        {
            try
            {
                var student = _studentsRepository.GetStudents().Where(e => e.IndexNumber == index).FirstOrDefault();
                if (student is null)
                {
                    return NotFound();
                }
                await _studentsRepository.UpdateStudent(student, new Models.Student { BirthDate = newStudentData.BirthDate, 
                    Email = newStudentData.Email, FirstName=newStudentData.FirstName, LastName=newStudentData.LastName, 
                    StudyName=newStudentData.StudyName, StudyMode=newStudentData.StudyMode,FathersName=newStudentData.FathersName,
                    MothersName=newStudentData.MothersName});
                return Ok(student);
            }catch(Exception ex)
            {
                return Problem();
            }
            
            //throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentPOST newStudent)
        {

            var student = new Student
            {
                FirstName = newStudent.FirstName,
                LastName = newStudent.LastName,
                IndexNumber = newStudent.IndexNumber,
                BirthDate = newStudent.BirthDate,
                Email = newStudent.Email,
                StudyMode = newStudent.StudyMode,
                StudyName = newStudent.StudyName,
                FathersName = newStudent.FathersName,
                MothersName = newStudent.MothersName
            };

            if(newStudent == null)
            {
                return Problem();
            }

            if (_studentsRepository.GetStudents().Any(e => e.IndexNumber == newStudent.IndexNumber && e.FirstName == newStudent.FirstName && e.LastName == newStudent.LastName))
            {
                return Conflict();
            }

            await _studentsRepository.AddStudent(student);
            return Created($"/api/students/{newStudent.IndexNumber}", student);
            //throw new NotImplementedException();
        }

        [HttpDelete("{index}")]
        public async Task<IActionResult> Delete(string index)
        {
            try
            {
                var student = _studentsRepository.GetStudents().Where(e => e.IndexNumber == index).FirstOrDefault();
                if (student is null)
                {
                    return NotFound();
                }
                await _studentsRepository.DeleteStudent(student);

                return Ok();
            }catch(Exception ex)
            {
                return Problem();
            }
            //throw new NotImplementedException();
        }

    }
}
