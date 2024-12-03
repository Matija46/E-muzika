namespace web.Models{
    public class Pesem{
        public int ID { get; set; }
        public string Naslov {get; set; }
        public string Album {get; set; }
        public int Dolzina {get; set; }
        public int Ocena {get; set; }
        
        public ICollection<IzvajalecPesem> izvajalecPesems {get; set;}
        
    }
}