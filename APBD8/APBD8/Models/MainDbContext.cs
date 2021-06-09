using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD8.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
        {

        }

        public MainDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Doctor> Doctor{get;set;}
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s20872;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Doctor>(opt =>
            {
                opt.HasData(
                    new Doctor { IdDoctor = 1, FirstName = "Marcel", LastName = "Jaworski", Email = "mjaworski@gmail.com" },
                    new Doctor { IdDoctor = 2, FirstName = "Marika", LastName = "Adamczyk", Email = "madamczyk@gmail.com" },
                    new Doctor { IdDoctor = 3, FirstName = "Eryk", LastName = "Walczak", Email = "ewalczak@gmail.com" },
                    new Doctor { IdDoctor = 4, FirstName = "Kamila", LastName = "Szulc", Email = "kszulc@gmail.com" },
                    new Doctor { IdDoctor = 5, FirstName = "Adrianna", LastName = "Szewczyk", Email = "aszewczyk@gmail.com" }
                );
            });

            modelBuilder.Entity<Patient>(opt =>
            {
                opt.HasData(
                    new Patient { IdPatient = 1, FirstName = "Paweł", LastName = "Maciejewski", Birthdate = new DateTime(1999,4,8)},
                    new Patient { IdPatient = 2, FirstName = "Oliwia", LastName = "Zielińska", Birthdate = new DateTime(1967, 10, 27)},
                    new Patient { IdPatient = 3, FirstName = "Juliusz", LastName = "Król", Birthdate = new DateTime(1977, 1, 25)},
                    new Patient { IdPatient = 4, FirstName = "Bartek", LastName = "Jaworski", Birthdate = new DateTime(1976, 12, 31) },
                    new Patient { IdPatient = 5, FirstName = "Bartek", LastName = "Kubiak", Birthdate = new DateTime(2017, 3, 29) }
                    //DateTime.Parse("Sep 12, 1971")
                   
                    );
            });

            modelBuilder.Entity<Medicament>(opt =>
            {
                opt.HasData(
                    new Medicament { IdMedicament = 1, Name = "HealthLabs 4Us", Description = "Opis w trakcie budowy", Type = "Witamina C"},
                    new Medicament { IdMedicament = 2, Name = "Starazolin", Description = "Opis w trakcie budowy", Type = "Krople do oczu" },
                    new Medicament { IdMedicament = 3, Name = "Vigalex Forte", Description = "Opis w trakcie budowy", Type = "Środek na odporność" },
                    new Medicament { IdMedicament = 4, Name = "Solgar", Description = "Opis w trakcie budowy", Type = "Preparat na stawy" },
                    new Medicament { IdMedicament = 5, Name = "Hyal-Drop Multi", Description = "Opis w trakcie budowy", Type = "Krople do oczu" }
                    );
            });

            modelBuilder.Entity<Prescription>(opt =>
            {
                opt.HasData(
                    new Prescription {IdPrescription = 1, Date = new DateTime(2000,8,11), DueDate = new DateTime(2021,3,13), IdPatient = 4, IdDoctor = 1 },
                    new Prescription { IdPrescription = 2, Date = new DateTime(2021,3,14), DueDate = new DateTime(2021,4,9), IdPatient = 4, IdDoctor = 3 },
                    new Prescription { IdPrescription = 3, Date = new DateTime(2021,1,19), DueDate = new DateTime(2021,2,17), IdPatient = 5, IdDoctor = 1 },
                    new Prescription { IdPrescription = 4, Date = new DateTime(2020,4,24), DueDate = new DateTime(2021,7,27), IdPatient = 5, IdDoctor = 5 },
                    new Prescription { IdPrescription = 5, Date = new DateTime(2021,4,7), DueDate = new DateTime(2021,8,26), IdPatient = 4, IdDoctor = 3 }
                    
                    );
            }
            );

            modelBuilder.Entity<Prescription_Medicament>(opt =>
            {
                opt.HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });

                opt.HasData(
                    new Prescription_Medicament { IdMedicament = 2, IdPrescription = 4, Dose = 1, Details = "Przykładowe detale" },
                    new Prescription_Medicament { IdMedicament = 5, IdPrescription = 2, Dose = 5, Details = "Przykładowe detale" },
                    new Prescription_Medicament { IdMedicament = 1, IdPrescription = 1, Dose = 10, Details = "Przykładowe detale" },
                    new Prescription_Medicament { IdMedicament = 3, IdPrescription = 5, Dose = 1, Details = "Przykładowe detale" },
                    new Prescription_Medicament { IdMedicament = 1, IdPrescription = 3, Dose = 5, Details = "Przykładowe detale" }
                    );
            });
        }



    }
}
