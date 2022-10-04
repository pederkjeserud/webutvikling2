using System.ComponentModel.DataAnnotations;

namespace FindMusicianAPI.Models
{

    public class Artist
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Instrument { get; set; }
        public int PricePerHour { get; set; }

    }

}