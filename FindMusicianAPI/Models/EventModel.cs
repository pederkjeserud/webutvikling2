using System.ComponentModel.DataAnnotations;

namespace FindMusicianAPI.Models
{

    public class Event
    {

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string EventType { get; set; }
        public int maxPrice { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}