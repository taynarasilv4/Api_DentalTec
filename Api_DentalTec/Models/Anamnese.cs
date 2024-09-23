namespace Api_DentalTec.Models
{
    public class Anamnese
    {
        public int Id { get; set; }
        public bool Febre { get; set; }
        public bool Tratamento { get; set; }
        public bool Cicatrizacao { get; set; }
        public bool Anestesia { get; set; }
        public bool Drogas { get; set; }
        public bool Diabetes { get; set; }
        public bool Doencas_Familiares { get; set; }
        public string Doencas_Familiares_Texto { get; set; }
        public bool Alergia { get; set; }
        public string Alergia_Texto { get; set; }
        public bool Doencas_Art_Reu { get; set; }
        public bool Hipertensao { get; set; }
        public bool Dst { get; set; }
        public bool Doenca_Cardiaca { get; set; }
        public bool Gravidez { get; set; }
        public string Observacoes { get; set; }

    }
}
