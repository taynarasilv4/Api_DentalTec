namespace Api_DentalTec.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nomeproduto { get; set; }
        public long CodigoBarra { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public double Valor { get; set; }
    }
}
