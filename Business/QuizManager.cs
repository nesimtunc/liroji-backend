using Business.Models;
using Microsoft.Extensions.Configuration;

namespace Business
{
    public class QuizManager
    {
        private readonly DataAccess.Repository<DataAccess.Entities.Quiz> _repository;

        public QuizManager(IConfiguration config)
        {
            _repository = new DataAccess.Repository<DataAccess.Entities.Quiz>(config);
        }

        public Quiz GetARandomQuiz(string userId)
        {
            return new Quiz
            {
                SongName = "song name",
                Artist = "Admin",
                Meaning = "aaaa",
                Emoji = "",
                Genre = "Rock",
                Language = "English",
                Year = 1980
            };
        }
    }
}
