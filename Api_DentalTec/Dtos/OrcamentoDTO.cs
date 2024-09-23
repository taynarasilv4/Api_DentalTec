using System.ComponentModel.DataAnnotations;

namespace Api_DentalTec.Dtos
{
    public class OrcamentoDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime Data_Nasc { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Rua { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Contato { get; set; }
        [Required]
        public string Profissional { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public string Servico { get; set; }
        [Required]
        public string Regiao { get; set; }
        [Required]
        public string Valor_Unit { get; set; }

    }
}
