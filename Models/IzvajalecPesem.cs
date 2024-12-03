namespace web.Models{
    public class IzvajalecPesem{
        public int ID { get; set; }
        public int IzvajalecID {get; set; }
        public int PesemID {get; set; }
        
        public Izvajalec izvajalec {get; set;}
        public Pesem pesem {get; set;}
    }
}