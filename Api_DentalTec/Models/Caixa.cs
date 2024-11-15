namespace Api_DentalTec.Models
{
    public class Caixa
    {
        public int Id { get; set; }
        public string Funcionario { get; set; }
        public double TotalEntrada { get; set; }
        public double TotalSaida { get; set; }
        public double ValorTotal { get; set; }
        public double ValorInicial { get; set; }
        public string TipoPagamento { get; set; }

    }

}
