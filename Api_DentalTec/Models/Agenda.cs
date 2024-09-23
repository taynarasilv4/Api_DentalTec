namespace Api_DentalTec.Models
{
    public class Agenda
    {

        public int Id { get; set; }
        public string NomeAgenda { get; set; }
        public string ProfissionalAgenda { get; set; }
        public DateTime DataAgenda { get; set; }
        public TimeSpan HoraAgenda { get; set; }

    }
}
