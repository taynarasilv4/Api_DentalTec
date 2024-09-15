namespace Api_DentalTec.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public string Funcionario { get; set; }
        public string Caixa { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }

    }
}
