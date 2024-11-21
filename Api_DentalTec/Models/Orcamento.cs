namespace Api_DentalTec.Models
{
    public class Orcamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data_Nasc { get; set; }
        public string Cpf { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public string Profissional { get; set; }
        public DateTime Data { get; set; }
        public string Servico { get; set; }
        public string Regiao { get; set; }
        public double Valor_Unit { get; set; }
    }
}
