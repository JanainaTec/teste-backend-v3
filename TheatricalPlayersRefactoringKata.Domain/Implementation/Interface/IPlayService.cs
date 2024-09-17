using System.Collections.Generic;
using TheatricalPlayersRefactoringKata.Database.Models;
using TheatricalPlayersRefactoringKata.Models.Dto;

namespace TheatricalPlayersRefactoringKata.Domain.Implementation.Interface
{
    public interface IPlayService
    {
        void AddPlay(PlayModel play);
        List<PlayModel> GetAllPlay();
        PlayModel GetPlay(string id);
        void RemovePlay(string id);
        PlayDto UpdatePlay(string id, PlayDto play);
    }
}
