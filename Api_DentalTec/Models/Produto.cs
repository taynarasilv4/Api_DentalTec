namespace Api_DentalTec.Models
{
    public class Produto
    {
        public string Nomeproduto { get; set; }
        public long CodigoBarra { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int Id { get; set; }
        public double Valor { get; set; }
    }
}
