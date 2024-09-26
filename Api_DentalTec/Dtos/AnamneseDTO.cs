using System.ComponentModel.DataAnnotations;

namespace Api_DentalTec.Dtos
{
    public class AnamneseDTO
    {
        [Required]
        public bool Febre { get; set; }
        [Required]
        public bool Tratamento { get; set; }
        [Required]
        public bool Cicatrizacao { get; set; }
        [Required]
        public bool Anestesia { get; set; }
        [Required]
        public bool Drogas { get; set; }
        [Required]
        public bool Diabetes { get; set; }
        [Required]
        public bool Doencas_Familiares { get; set; }
        [Required]
        public string Doencas_Familiares_Texto { get; set; }
        [Required]
        public bool Alergia { get; set; }
        [Required]
        public string Alergia_Texto { get; set; }
        [Required]
        public bool Doencas_Art_Reu { get; set; }
        [Required]
        public bool Hipertensao { get; set; }
        [Required]
        public bool Dst { get; set; }
        [Required]
        public bool Doenca_Cardiaca { get; set; }
        [Required]
        public bool Gravidez { get; set; }
        [Required]
        public string Observacoes { get; set; }

    }
}
