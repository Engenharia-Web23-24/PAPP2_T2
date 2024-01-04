using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace PAP2T2.Models
{
    public class Inscricao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("UCId")]
        public string? UCId { get; set; }
        
        [Required]
        public string? Username { get; set;}
        
        public int Ano { get; set;}
    }
}
