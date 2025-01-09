namespace web.Models{
    public class PlaylistSong{
        public int ID { get; set; }
        public int PlaylistID {get; set; }
        public int PesemID {get; set; }
        
        public Playlist playlist {get; set;}
        public Pesem pesem {get; set;}
    }
}