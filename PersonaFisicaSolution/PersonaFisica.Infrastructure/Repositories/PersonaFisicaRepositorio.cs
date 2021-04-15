using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PersonaFisica.Core.Entities;
using PersonaFisica.Core.Interfaces;
using PersonaFisica.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonaFisica.Infrastructure.Repositories
{
    public class PersonaFisicaRepositorio : IPersonaFisicaRepositorio
    {
        private readonly ExamenContext _context;
        public PersonaFisicaRepositorio(ExamenContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TbPersonasFisica>> GetPersonasFisicas()
        {
            var Personas = await _context.TbPersonasFisicas.Where(w => w.Activo == true).ToListAsync();
            return Personas;
        }

        public async Task<TbPersonasFisica> GetPersonaFisicaPorID(int IdPersonaFisica)
        {
            var Persona = await _context.TbPersonasFisicas.FindAsync(IdPersonaFisica);
            
            return Persona;
        }


        public async Task PostPersonaFisica(TbPersonasFisica Persona)
        {
            _context.TbPersonasFisicas.Add(Persona);
            await _context.SaveChangesAsync();
        }
       
        public async Task<bool> PutPersonaFisica(TbPersonasFisica Persona)
        {            
            var Registro = await _context.TbPersonasFisicas.FindAsync(Persona.IdPersonaFisica);
            Registro.FechaActualizacion =DateTime.Now;
            Registro.Nombre = Persona.Nombre;
            Registro.ApellidoPaterno  = Persona.ApellidoPaterno;
            Registro.ApellidoMaterno = Persona.ApellidoMaterno;
            Registro.Rfc = Persona.Rfc;
            Registro.FechaNacimiento = Persona.FechaNacimiento;

            int rows =  await _context.SaveChangesAsync();
            return rows > 0;
        }

        
        public async Task<bool> DeletePersonaFisica(int IdPersonaFisica)
        {
            var Registro = await _context.TbPersonasFisicas.FindAsync(IdPersonaFisica);
            Registro.Activo = false;
            Registro.FechaActualizacion = DateTime.Now;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<sp_Response> PostPersonaFisicaSP(TbPersonasFisica Persona)
        {
            var result = await _context.sp_EliminarPersonaFisica.FromSqlRaw($@"sp_AgregarPersonaFisica @Nombre, @ApellidoPaterno, @ApellidoMaterno, @RFC, @FechaNacimiento,@UsuarioAgrega ",
                                                                            parameters: new[] {
                                                                                                new SqlParameter("@Nombre", Persona.Nombre),
                                                                                                new SqlParameter("@ApellidoPaterno", Persona.ApellidoPaterno),
                                                                                                new SqlParameter("@ApellidoMaterno", Persona.ApellidoMaterno),
                                                                                                new SqlParameter("@RFC", Persona.Rfc),
                                                                                                new SqlParameter("@FechaNacimiento", Persona.FechaNacimiento),
                                                                                                new SqlParameter("@UsuarioAgrega", Persona.UsuarioAgrega)
                                                                            }).ToListAsync();
            return result.FirstOrDefault();
        }
        public async Task<sp_Response> PutPersonaFisicaSP(TbPersonasFisica Persona)
        {
            var result = await _context.sp_EliminarPersonaFisica.FromSqlRaw($@"sp_ActualizarPersonaFisica @IdPersonaFisica, @Nombre, @ApellidoPaterno, @ApellidoMaterno, @RFC, @FechaNacimiento,@UsuarioAgrega ", 
                                                                            parameters: new[] { 
                                                                                                new SqlParameter("@IdPersonaFisica", Persona.IdPersonaFisica),
                                                                                                new SqlParameter("@Nombre", Persona.Nombre),
                                                                                                new SqlParameter("@ApellidoPaterno", Persona.ApellidoPaterno),
                                                                                                new SqlParameter("@ApellidoMaterno", Persona.ApellidoMaterno),
                                                                                                new SqlParameter("@RFC", Persona.Rfc),
                                                                                                new SqlParameter("@FechaNacimiento", Persona.FechaNacimiento),
                                                                                                new SqlParameter("@UsuarioAgrega", Persona.UsuarioAgrega)
                                                                            } ).ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<sp_Response> DeletePersonaFisicaSP(int IdPersonaFisica)
        {
            //int rows = await _context.Database.ExecuteSqlRawAsync($"EXEC [dbo].[sp_EliminarPersonaFisica] {IdPersonaFisica} ") ;
            var result = await  _context.sp_EliminarPersonaFisica.FromSqlRaw($"sp_EliminarPersonaFisica @IdPersonaFisica", new SqlParameter("@IdPersonaFisica", IdPersonaFisica)).ToListAsync();

            //await _context.SaveChangesAsync();
            return result.FirstOrDefault();
        }
    }
}
