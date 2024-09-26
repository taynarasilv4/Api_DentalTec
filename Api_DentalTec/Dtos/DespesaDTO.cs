using System.ComponentModel.DataAnnotations;

namespace Api_DentalTec.Dtos
{
    public class DespesaDTO
    {
        
        [Required]
        public string Funcionario { get; set; }
        [Required]
        public string Caixa { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public string Descricao { get; set; }
    }
}
