using System;
namespace Business.Models
{
    public class Quiz
    {
        public Quiz()
        {
        }
                
        public string Emoji { get; set; }
        public string Meaning { get; set; }
        public string Artist { get; set; }
        public string SongName { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Language { get; set; }

    }
}
