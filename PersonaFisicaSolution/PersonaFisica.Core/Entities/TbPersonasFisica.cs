using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PersonaFisica.Core.Entities
{https://www.youtube.com/watch?v=-Y6DoRujvAk&t=80s
    public partial class TbPersonasFisica
    {
        public int IdPersonaFisica { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        [Required(ErrorMessage ="El nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Apellido Paterno es requerido")]
        public string ApellidoPaterno { get; set; }
        [Required(ErrorMessage = "El Apellido Materno es requerido")]
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "El RFC es requerido"), MaxLength(13, ErrorMessage = "El RFC no puede ser mayor a 13 caracteres"), MinLength(13, ErrorMessage = "El RFC no puede ser menor a 13 caracteres")]
        public string Rfc { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime? FechaNacimiento { get; set; }
        [Required(ErrorMessage = "El usuario que agrega es requerido")]
        public int? UsuarioAgrega { get; set; }
        public bool? Activo { get; set; }
    }
}
