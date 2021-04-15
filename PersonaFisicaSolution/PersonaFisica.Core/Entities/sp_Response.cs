using System.ComponentModel.DataAnnotations;

namespace PersonaFisica.Core.Entities
{
    public partial class sp_Response
    {
        [Key]
        public int? Error { get; set; }
        public string MENSAJEERROR { get; set; }
    }
}
