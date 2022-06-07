using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zad8.Models;
using Zad8.Models.dto;

namespace Zad8.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;

        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddDoctor(ResponseDoctor doctor)
        {
            _dbContext.Doctors.Add(new Doctor()
            {
                Email = doctor.Email,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName
            });
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDoctor(int id)
        {
           var doctor = await _dbContext.Doctors.Where(e=> e.IdDoctor == id).FirstOrDefaultAsync();
            if (doctor == null)
            {
                return false;
            }
            _dbContext.Doctors.Remove(doctor);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ResponseDoctor>> GetAllDoctors()
        {
            return await _dbContext.Doctors.Select( e=> new ResponseDoctor()
            {
                Id = e.IdDoctor,
                Email = e.Email,
                FirstName = e.FirstName,
                LastName = e.LastName
            }).ToListAsync();
        }

        public async Task<ResponseDoctor> GetDoctor(int id)
        {
            return await _dbContext.Doctors.Where(e=> e.IdDoctor == id)
                .Select(doctor => new ResponseDoctor()
                {
                    Id = doctor.IdDoctor,
                    Email = doctor.Email,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ResponsePrescription> GetPrescription(int id)
        {
            return await _dbContext.Prescriptions
                .Where(e => e.IdPrescription == id)
                .Select(prescription => new ResponsePrescription()
                {
                    IdPrescription = prescription.IdPrescription,
                    Date = prescription.Date,
                    DueDate = prescription.DueDate,
                    Doctor = new ResponseDoctor()
                    {
                        Id = prescription.Doctor.IdDoctor,
                        Email = prescription.Doctor.Email,
                        FirstName = prescription.Doctor.FirstName,
                        LastName = prescription.Doctor.LastName
                    },
                    Patient = new ResponsePatient()
                    {
                        FirstName = prescription.Patient.FirstName,
                        LastName = prescription.Patient.FirstName,
                        BirthDate = prescription.Patient.BirthDate
                    },
                    Medicaments = prescription.Prescription_Medicaments.Select(e => new ResponseMedicament()
                    {
                        Name = e.Medicament.Name,
                        Description = e.Medicament.Description,
                        Details = e.Details,
                        Dose = e.Dose,
                        Type = e.Medicament.Type
                    })
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateDoctor(int id, ResponseDoctor doctor)
        {
            if (id != doctor.Id)
            {
                return false;
            }
            _dbContext.Entry(new Doctor
            {
                IdDoctor = id,
                Email = doctor.Email,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName
            }).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
