using TheatricalPlayersRefactoringKata.Database.Models;
using TheatricalPlayersRefactoringKata.Models.Dto;

namespace TheatricalPlayersRefactoringKata.Database.Repository
{
    public class PlayRepository
    {
        protected readonly ApplicationDbContext _db;

        public PlayRepository(ApplicationDbContext db) { _db = db; }

        public void PostPlay(PlayModel newPlay)
        {
            try
            {
                var play = _db.Plays.Where(x => x.Id.Equals(newPlay.Id.ToLower())).FirstOrDefault();
                if (play != null)
                {
                    throw new Exception($"ID {play.Id} já utilizado para a peça {play.Name} !");
                }

                _db.Plays.Add(new Models.PlayModel
                {
                    Id = newPlay.Id,
                    Name = newPlay.Name,
                    Lines = newPlay.Lines,
                    Type = newPlay.Type
                });
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Falha ao adicionar uma nova Peça! message :{e.Message}");
            }
        }

        public List<PlayModel> GetAllPlays()
        {
            try
            {
                return _db.Plays.ToList();
            }
            catch (Exception e)
            {
                throw new Exception($"Falha ao Listar Peça! message :{e.Message}");
            }
        }

        public PlayModel GetPlayById(string id)
        {
            try
            {
                var play = _db.Plays.Where(x => x.Id.Equals(id.ToLower())).FirstOrDefault();
                if (play == null)
                {
                    throw new Exception($"Id {id} não encontrado!");
                }
                return play;
            }
            catch (Exception e)
            {
                throw new Exception($"Falha ao buscar Peça! message :{e.Message}");
            }
        }

        public void RemovePlay(string id)
        {
            try
            {
                var play = _db.Plays.Where(x => x.Id.Equals(id.ToLower())).FirstOrDefault();
                if (play == null)
                {
                    throw new Exception($"Id {id} não encontrado!");
                }

                _db.Plays.Remove(play);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Falha ao remover a Peça! message :{e.Message}");
            }
        }

        public PlayDto UpdatePlay(string id , PlayDto newPlay)
        {
            try
            {
                var play = _db.Plays.Where(x => x.Id.Equals(id.ToLower())).FirstOrDefault();
                if (play == null)
                {
                    throw new Exception($"Id {id} não encontrado!");
                }
                play.Name = newPlay.Name;
                play.Lines = newPlay.Lines;
                play.Type = newPlay.Type;

                _db.Update(play);
                _db.SaveChanges();

                return newPlay;
            }
            catch (Exception e)
            {
                throw new Exception($"Falha ao atualizar a Peça! message :{e.Message}");
            }
        }
    }
}
