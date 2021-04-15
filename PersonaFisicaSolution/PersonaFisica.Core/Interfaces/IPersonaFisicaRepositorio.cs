using PersonaFisica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaFisica.Core.Interfaces
{
    public interface IPersonaFisicaRepositorio
    {
        Task<IEnumerable<TbPersonasFisica>> GetPersonasFisicas();
        Task<TbPersonasFisica> GetPersonaFisicaPorID(int IdPersonaFisica);
        Task PostPersonaFisica(TbPersonasFisica Persona);
        Task<bool> PutPersonaFisica(TbPersonasFisica Persona);
        Task<bool> DeletePersonaFisica(int IdPersonaFisica);
        Task<sp_Response> PostPersonaFisicaSP(TbPersonasFisica Persona);
        Task<sp_Response> PutPersonaFisicaSP(TbPersonasFisica Persona);
        Task<sp_Response> DeletePersonaFisicaSP(int IdPersonaFisica);
    }
}
