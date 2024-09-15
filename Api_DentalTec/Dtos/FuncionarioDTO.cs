using System.ComponentModel.DataAnnotations;

namespace Api_DentalTec.Dtos
{
    public class FuncionarioDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")]//formato = 000.000.000-00
        public string Cpf { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Cargo { get; set; }
        [Required]
        public double Salario { get; set; }
        [Required]
        public string Rg { get; set; }
        [Required]
        public string Expedidor { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string Ctps { get; set; }
        [Required]
        public string EstadoCivil { get; set; }
        [Required]
        public string Sexo { get; set; }
        [Required]
        public DateTime DataEmissao { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Cnh { get; set; }
        [Required]
        public string Cep { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Rua { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public string Bairro { get; set; }
    }
}
