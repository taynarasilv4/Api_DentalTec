using System.ComponentModel.DataAnnotations;

namespace Api_DentalTec.Dtos
{
    public class CaixaDTO
    {
        [Required]
        public string Funcionario { get; set; }
        [Required]
        public double TotalEntrada { get; set; }
        [Required]
        public double TotalSaida { get; set; }
        [Required]
        public double ValorTotal { get; set; }
        [Required]
        public double ValorInicial { get; set; }
        [Required]
        public string TipoPagamento { get; set; }



    }

}
