using MediaPlayer.DAL.Interfaces;

namespace MediaPlayer.DAL.Entities
{
    public class MusicGenre : IEntity
    {
        public int Id { get; set; }

        public int MusicId { get; set; }
        public virtual Music Music { get; set; }

        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
