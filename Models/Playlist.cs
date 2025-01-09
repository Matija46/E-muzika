namespace web.Models{
    public class Playlist{
        public int ID { get; set; }
        public string Ime {get; set; }
        public string Opis {get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }

        public ApplicationUser Owner {get; set; }
        public ICollection<PlaylistSong> playlistSongs {get; set;}

    }
}