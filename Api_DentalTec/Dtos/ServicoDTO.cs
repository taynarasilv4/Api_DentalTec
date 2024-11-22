using System.ComponentModel.DataAnnotations;

namespace Api_DentalTec.Dtos
{
    public class ServicoDTO
    {
        [Required]
        public string NomeServico { get; set; }
        [Required]
        public string ProfissionalEspecializado { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int IdOrcamento { get; set; } 
    }
}

