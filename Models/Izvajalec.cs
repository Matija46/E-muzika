namespace web.Models{
    public class Izvajalec{
        public int ID { get; set; }
        public string Ime {get; set; }
        public string Opis {get; set; }
        public int poslusalci {get; set;}
        public ICollection<IzvajalecPesem> izvajalecPesems {get; set;}
        
    }
}