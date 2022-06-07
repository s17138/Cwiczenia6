using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zad8.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        protected MainDbContext()
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseIdentityColumns(1, 1);
            modelBuilder.Entity<Prescription_Medicament>(p =>
                {
                    p.HasKey(e => new
                    {
                        e.IdPrescription,
                        e.IdMecicament
                    });
                }
            );
            modelBuilder.Entity<Patient>(p =>
               {
                   p.HasData(new Patient()
                   {
                       IdPatient = 1,
                       FirstName = "Paul",
                       LastName = "Rodriguez",
                       BirthDate = new DateTime(1992, 2, 26),
                   }
                   );
                   p.HasData(new Patient()
                   {
                       IdPatient = 2,
                       FirstName = "Eric",
                       LastName = "Gomez",
                       BirthDate = new DateTime(1985, 11, 26),
                   }
                 );
                   p.HasData(new Patient()
                   {
                       IdPatient = 3,
                       FirstName = "Julie",
                       LastName = "Robertson",
                       BirthDate = new DateTime(1989, 8, 24),
                   }
                 );
                   p.HasData(new Patient()
                   {
                       IdPatient = 4,
                       FirstName = "Tracy",
                       LastName = "Kelly",
                       BirthDate = new DateTime(1989, 11, 30),
                   }
                   );
                   p.HasData(new Patient()
                   {
                       IdPatient = 5,
                       FirstName = "Jordan",
                       LastName = "Green",
                       BirthDate = new DateTime(1984, 2, 13),
                   }
                 );
               }
           );
            modelBuilder.Entity<Doctor>(p =>
           {
               p.HasData(new Doctor()
               {
                   IdDoctor = 1,
                   FirstName = "Angel",
                   LastName = "Henderson",
                   Email = "henderson@doctor.com"
               });
               p.HasData(new Doctor()
               {
                   IdDoctor = 2,
                   FirstName = "Bridget",
                   LastName = "Curtis",
                   Email = "bridgetcurtis@doctor.com"
               });
               p.HasData(new Doctor()
               {
                   IdDoctor =3,
                   FirstName = "Michael",
                   LastName = "Silva",
                   Email = "michaelsilva@doctor.com"
               });
               p.HasData(new Doctor()
               {
                   IdDoctor = 4,
                   FirstName = "Jennifer",
                   LastName = "Wilson",
                   Email = "jenniferwilson@doctor.com"
               });
           }
           );
            modelBuilder.Entity<Medicament>(p => {
                p.HasData(new Medicament() { 
                    IdMecicament = 1,
                    Name = "Apap",
                    Description = "Lek na ból głowy",
                    Type = "Tabletki"
                });
                p.HasData(new Medicament()
                {
                    IdMecicament = 2,
                    Name = "Flegamina",
                    Description = "Syrop na kaszel",
                    Type = "Syrop"
                });
                p.HasData(new Medicament()
                {
                    IdMecicament = 3,
                    Name = "Płyn Lugola",
                    Description = "Na skarzenia radioaktywne",
                    Type = "Syrop"
                });
                p.HasData(new Medicament()
                {
                    IdMecicament = 4,
                    Name = "Voltaren",
                    Description = "Maść na ból stawów",
                    Type = "Maść"
                });
                p.HasData(new Medicament()
                {
                    IdMecicament = 5,
                    Name = "Ibuprom",
                    Description = "Lek przeciwbólowy",
                    Type = "Tabletki"
                });
                p.HasData(new Medicament()
                {
                    IdMecicament = 6,
                    Name = "Nospa",
                    Description = "Lek na ból brzucha",
                    Type = "Tabletki"
                });
            });
            modelBuilder.Entity<Prescription>(p =>
            {
                p.HasData(new Prescription()
                {
                    IdPrescription = 1,
                    IdDoctor = 1,
                    IdPatient = 1,
                    Date = new DateTime(2022, 4, 5),
                    DueDate = new DateTime(2022, 6, 5)
                });
                p.HasData(new Prescription()
                {
                    IdPrescription = 2,
                    IdDoctor = 2,
                    IdPatient = 1,
                    Date = new DateTime(2022, 2, 1),
                    DueDate = new DateTime(2022, 4, 1)
                });
                p.HasData(new Prescription()
                {
                    IdPrescription = 3,
                    IdDoctor = 2,
                    IdPatient = 3,
                    Date = new DateTime(2022, 5, 11),
                    DueDate = new DateTime(2022, 6, 11)
                });
            });
            modelBuilder.Entity<Prescription_Medicament>(p =>
            {
                p.HasData(new Prescription_Medicament()
                {
                    IdPrescription = 1,
                    IdMecicament = 1,
                    Dose = 2,
                    Details = "W przypadku gorączki powyżej 40 stopni"
                });
                p.HasData(new Prescription_Medicament()
                {
                    IdPrescription = 1,
                    IdMecicament = 2,
                    Dose = 3,
                    Details = "Najpóźniej o 18"
                });
                p.HasData(new Prescription_Medicament()
                {
                    IdPrescription = 2,
                    IdMecicament = 4,
                    Dose = 3,
                    Details = "Bezpośrednio po treningu"
                });
                p.HasData(new Prescription_Medicament()
                {
                    IdPrescription = 3,
                    IdMecicament = 6,
                    Dose = 2,
                    Details = "W przypadku silnego bólu brzucha"
                });
                p.HasData(new Prescription_Medicament()
                {
                    IdPrescription = 3,
                    IdMecicament = 5,
                    Dose = 1,
                    Details = "W przypadku wystąpienia bólu głowy"
                });
            });



            /* 
          modelBuilder.Entity<Patient>(p =>
         {
             p.HasData(
                 new Patient() { IdPatient = 1, FirstName = "Jan", LastName = "Kowalski"}//i tak pododawać rekordy do bazy danych
                 );
         });*/
            /*
                        modelBuilder.Entity<Prescription>(p =>
                        {
                            p.HasKey(e => e.IdPrescription);
                            p.Property(e => e.Date).IsRequired();
                            p.HasOne(e => e.Patient).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdPatient);
                        });*/
        }
    }
}
