using System.ComponentModel.DataAnnotations;

namespace Api_DentalTec.Dtos
{
    public class ConsultaDTO
    {
        [Required]
        public string NomePaciente { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string Sexo { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public DateTime DataConsulta { get; set; }

        [Required]
        public TimeSpan HoraConsulta { get; set; }

        [Required]
        public string NomeMedico { get; set; }

        [Required]
        public string Especialidade { get; set; }

        [Required]
        public string MotivoConsulta { get; set; }
        [Required]
        public string HistoricoSaude { get; set; }
        [Required]
        public string Sintomas { get; set; }
        [Required]
        public string ExameFisico { get; set; }
        [Required]
        public string Diagnostico { get; set; }
        [Required]
        public string TratamentoOrientacoes { get; set; }
        [Required]
        public string Observacoes { get; set; }
    }
}
