using Microsoft.EntityFrameworkCore;
using Perscription.Controllers;
using System.Text;

namespace Perscription.Models
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions options) : base(options)
        {}

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Perscriptions { get; set; }
        public DbSet<PrescriptionMedicament> PerscriptionMedicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(e =>
            {
                e.HasData(new List<Patient>
                {
                    new Patient {IdPatient=1,FirstName="Adam",LastName="Kowalski",BirthDate=DateTime.Now},
                    new Patient {IdPatient=2,FirstName="Jan",LastName="Kabacki",BirthDate=DateTime.Now}
                });
            });

            modelBuilder.Entity<AppUser>(e =>
            {
                var salt = Guid.NewGuid().ToString();
                var data = AccountsController.HashPassw("123123123",salt);
                e.HasData(new List<AppUser>
                {
                    new AppUser{IdUser=1,Login="Adam",Password=data,Salt=salt,RefToken=null, ExpiresAt=null},
                });
               
            });

            modelBuilder.Entity<Doctor>(e =>
            {
                e.HasData(new List<Doctor>
                {
                    new Doctor {IdDoctor=1,FirstName="Dominik",LastName="Babacki",Email="d.bab@gmail.com"},
                    new Doctor {IdDoctor=2,FirstName="Emil",LastName="Janacki",Email="e.jan@gmail.com"}
                });
            });

            modelBuilder.Entity<Medicament>(e =>
            {
                e.HasData(new List<Medicament>
                {
                    new Medicament {IdMedicament=1,Name="Aspiryna",Description="Lek przeciwbólowy",Type="Przeciwbólowy"},
                    new Medicament { IdMedicament=2,Name="Zyrtec",Description="Używać zgodnie z zaleceniami lekarza", Type="Przeciwalergiczny"}
                });
            });

            modelBuilder.Entity<Prescription>(e =>
            {
                e.HasData(new List<Prescription>
                {
                    new Prescription {IdPrescription=1,Date=DateTime.Now,DueDate=DateTime.Now,
                    IdDoctor=2,IdPatient=1},
                    new Prescription {IdPrescription=2,Date=DateTime.Now,DueDate=DateTime.Now,
                    IdDoctor=2,IdPatient=2}
                });


            });

            modelBuilder.Entity<PrescriptionMedicament>(e =>
            {
                e.HasData(new List<PrescriptionMedicament>
                {
                    new PrescriptionMedicament {IdMedicament=2,IdPrescription=1,Dose=3,Details="Dwa razy dziennie, jedna tabletka"},
                    new PrescriptionMedicament {IdMedicament=1,IdPrescription=2,Dose=null,Details="Stosować przez 2 tygodnie"}
                });

                e.ToTable("Perscription_Medicament");
            });
        }
    }
}
