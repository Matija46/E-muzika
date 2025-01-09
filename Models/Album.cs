namespace web.Models{
    public class Album{
        public int ID { get; set; }
        public string Ime {get; set; }
        public string Opis {get; set; }
        public DateTime DatumIzdaje { get; set; }

        public ICollection<Pesem> Pesmi { get; set; } = new List<Pesem>();

        public int IzvajalecID { get; set; }
        public Izvajalec Izvajalec { get; set; }

    }
}