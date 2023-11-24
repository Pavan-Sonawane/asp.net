using System.ComponentModel.DataAnnotations;

namespace sports.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name_of_candidate { get; set; }
        public string Name_of_game { get; set; }
        public string Type_of_game { get; set; }
        public string Coach_name { get; set;}
        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
