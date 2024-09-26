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

        public string HistoricoSaude { get; set; }

        public string Sintomas { get; set; }

        public string ExameFisico { get; set; }

        public string Diagnostico { get; set; }

        public string TratamentoOrientacoes { get; set; }

        public string Observacoes { get; set; }
    }
}
