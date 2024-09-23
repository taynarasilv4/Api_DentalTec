namespace Api_DentalTec.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public string NomePaciente { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public DateTime DataConsulta { get; set; }
        public TimeSpan HoraConsulta { get; set; }
        public string NomeMedico { get; set; }
        public string Especialidade { get; set; }
        public string MotivoConsulta { get; set; }
        public string HistoricoSaude { get; set; }
        public string Sintomas { get; set; }
        public string ExameFisico { get; set; }
        public string Diagnostico { get; set; }
        public string TratamentoOrientacoes { get; set; }
        public string Observacoes { get; set; }

    }
}
