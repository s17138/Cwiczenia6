using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zad8.Models.dto;

namespace Zad8.Services
{
    public interface IDbService
    {
        public Task<bool> AddDoctor(ResponseDoctor doctor);
        public Task<bool> UpdateDoctor(int id, ResponseDoctor doctor);
        public Task<bool> DeleteDoctor(int id);
        public Task<ResponseDoctor?> GetDoctor(int id);
        public Task<IEnumerable<ResponseDoctor>> GetAllDoctors();
        public Task<ResponsePrescription> GetPrescription(int id);

    }
}
