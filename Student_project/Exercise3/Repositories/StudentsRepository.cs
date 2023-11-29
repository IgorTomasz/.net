using Exercise3.Models;
using Exercise3.Services;

namespace Exercise3.Repositories
{
    public interface IStudentsRepository
    {
        IEnumerable<Student> GetStudents();
        Task DeleteStudent (Student student);
        Task AddStudent(Student student);
        Task UpdateStudent(Student student, Student newData);
    }

    public class StudentsRepository : IStudentsRepository
    {

        private readonly IFileDbService _fileDbService;

        public StudentsRepository(IFileDbService fileDbService)
        {
            _fileDbService = fileDbService;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _fileDbService.Students;
            //throw new NotImplementedException();
        }

        public async Task DeleteStudent(Student student)
        {
            ((List<Student>)_fileDbService.Students).Remove(student);
            await _fileDbService.SaveChanges();
            //throw new NotImplementedException();
        }

        public async Task AddStudent(Student student)
        {
            ((List<Student>)_fileDbService.Students).Add(student);
            await _fileDbService.SaveChanges();
            //throw new NotImplementedException();
        }

        public async Task UpdateStudent(Student student, Student newData)
        {
            student.BirthDate = newData.BirthDate;
            student.Email = newData.Email;
            student.FirstName = newData.FirstName;
            student.StudyName = newData.StudyName;
            student.LastName = newData.LastName;
            student.FathersName = newData.FathersName;
            student.MothersName= newData.MothersName; 
            student.StudyMode= newData.StudyMode;
            await _fileDbService.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
