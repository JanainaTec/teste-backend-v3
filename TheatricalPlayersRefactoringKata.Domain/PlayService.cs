using System.Collections.Generic;
using TheatricalPlayersRefactoringKata.Database.Models;
using TheatricalPlayersRefactoringKata.Database.Repository;
using TheatricalPlayersRefactoringKata.Domain.Implementation.Interface;
using TheatricalPlayersRefactoringKata.Models.Dto;

namespace TheatricalPlayersRefactoringKata.Domain
{
    public class PlayService : IPlayService
    {
        private readonly PlayRepository _playRepository;
        public PlayService(PlayRepository playRepository)
        {
            _playRepository = playRepository;
        }

        public void AddPlay(PlayModel play)
        {
            try
            {
                _playRepository.PostPlay(play);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public List<PlayModel> GetAllPlay()
        {
            try
            {
                return _playRepository.GetAllPlays();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public PlayModel GetPlay(string id)
        {
            try
            {
                return _playRepository.GetPlayById(id);
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public void RemovePlay(string id)
        {
            try
            {
                _playRepository.RemovePlay(id);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public PlayDto UpdatePlay(string id, PlayDto play)
        {
            try
            {
                return _playRepository.UpdatePlay(id, play);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
