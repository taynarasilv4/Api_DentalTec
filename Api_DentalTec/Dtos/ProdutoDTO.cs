using System.ComponentModel.DataAnnotations;

namespace Api_DentalTec.Dtos
{
    public class ProdutoDTO
    {
        [Required]
        public string Nomeproduto { get; set; }
        [Required]
        public long CodigoBarra { get; set; }
        [Required]
        public DateTime DataFabricacao { get; set; }
        [Required]
        public DateTime DataValidade { get; set; }
        [Required]
        public double Valor { get; set; }

    }
}
