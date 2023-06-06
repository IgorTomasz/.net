using Exercise3.Models;

namespace Exercise3.Services
{
    public interface IFileDbService
    {
        public IEnumerable<Student> Students { get; set; }
        Task SaveChanges();
    }

    public class FileDbService : IFileDbService
    {
        private readonly string _pathToFileDatabase;
        public IEnumerable<Student> Students { get; set; } = new List<Student>();
        public FileDbService(IConfiguration configuration)
        {
            _pathToFileDatabase = configuration.GetConnectionString("Default") ?? throw new ArgumentNullException(nameof(configuration));
            Initialize();
        }

        private void Initialize()
        {
            if (!File.Exists(_pathToFileDatabase))
            {
                return;
            }
            var lines = File.ReadLines(_pathToFileDatabase);

            var students = new List<Student>();

            lines.ToList().ForEach(line =>
            {
                var splittedLine = line.Split(',');
                if (splittedLine.Length != 9)
                {
                    //logs.WriteLine($"Wiersz nie posiada odpowiedniej ilości kolumn: {line}");
                    return;
                }

                if (splittedLine.Any(e => e.Trim() == ""))
                {
                    //logs.WriteLine($"Wiersz nie może posiadać pustych kolumn: {line}");
                    return;
                }


                var newStudent = new Student
                    {
                        IndexNumber = splittedLine[2],
                        FirstName = splittedLine[0],
                        LastName = splittedLine[1],
                        BirthDate = DateTime.Parse(splittedLine[3]).ToString("dd.MM.yyyy"),
                        Email = splittedLine[6],
                        MothersName = splittedLine[8],
                        FathersName = splittedLine[7],
                        StudyName = splittedLine[4],
                        StudyMode = splittedLine[5]
                    };

                    if (students.Any(e => e.IndexNumber == newStudent.IndexNumber && e.FirstName == newStudent.FirstName && e.LastName == newStudent.LastName))
                    {
                        return;
                    }
                Console.WriteLine("elo");
                students.Add(newStudent);
            });

            //Tutaj należy przeparsować dane ze zmiennej lines, tak jak w drugim zadaniu

            Students = students;
        }

        public async Task SaveChanges()
        {
            await File.WriteAllLinesAsync(
                _pathToFileDatabase, 
                Students.Select(e => $"{e.FirstName},{e.LastName},{e.IndexNumber},{e.BirthDate},{e.StudyName},{e.StudyMode},{e.Email},{e.FathersName},{e.MothersName}") //dokonczyc
                 //tutaj należy zapewnić listę stringów zawierającą odpowiednio sformatowane dane studentów
                     // np. Jan,Kowalski,s1234,3/20/1991,Informatyka,Dzienne,kowalski@wp.pl,Jan,Anna
                );
        }

    }
}
