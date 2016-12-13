using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Race
    {
        public int Id { get; set; }

        public List<Snail> Participants { get; set; } 

        public int Distance { get; set; }
    }
}