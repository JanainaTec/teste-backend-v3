using TheatricalPlayersRefactoringKata.Database.Interface;
using TheatricalPlayersRefactoringKata.Database.Models;
using TheatricalPlayersRefactoringKata.Models.Dto;

namespace TheatricalPlayersRefactoringKata.Database.Repository
{
    public class StatementRepository : IStatemnetRepository
    {
        protected readonly ApplicationDbContext _db;

        public StatementRepository(ApplicationDbContext db) { _db = db; }

        public void AddStatement(StatementDto statement)
        {
            var statementId = Guid.NewGuid();

            foreach (var item in statement.Items)
            {
                _db.StatementItens.Add(new StatementItensModel
                {
                    Id = Guid.NewGuid(),
                    StatementId = statementId,
                    PlayId = item.Play,
                    AmountOwed = item.AmountOwed,
                    Credits = item.EarnedCredits,
                    Seats = item.Seats
                });
                _db.SaveChanges();
            }

            _db.Statements.Add(new StatementModel
            {
                Id = statementId,
                CreatedAt = DateTime.UtcNow,
                Customer = statement.Customer,
                TotalAmount = statement.AmountOwed,
                TotalCredit = statement.EarnedCredits
            });
            _db.SaveChanges();
        }


        public List<StatementDto> GetAllStatement()
        {
            List<StatementDto> statementsList = new List<StatementDto>();
            try
            {
                var query = from statement in _db.Statements
                            join statementItens in _db.StatementItens
                            on statement.Id equals statementItens.StatementId
                            select new StatementDataDto
                            {
                                StatementId = statement.Id,
                                CreatedAt = statement.CreatedAt,
                                Customer = statement.Customer,
                                PlayId = statementItens.PlayId,
                                AmountOwed = statementItens.AmountOwed,
                                ErnedCredits = statementItens.Credits,
                                Seats = statementItens.Seats,
                                TotalAmount = statement.TotalAmount,
                                TotalCredit = statement.TotalCredit,
                            };

                if (query != null)
                {
                    statementsList = query.GroupBy(x => new { x.StatementId, x.CreatedAt, x.Customer, x.TotalAmount, x.TotalCredit }).Select(x => new StatementDto()
                    {
                        Customer = x.Key.Customer,
                        AmountOwed = x.Key.TotalAmount,
                        EarnedCredits = x.Key.TotalCredit,
                        Items = query.Where(y => y.StatementId.Equals(x.Key.StatementId) && y.Customer.Equals(x.Key.Customer) && y.CreatedAt.Equals(x.Key.CreatedAt))
                        .GroupBy(y => new { y.PlayId, y.Seats, y.ErnedCredits, y.AmountOwed }).Select(y => new ItemDto()
                        {
                            Play = y.Key.PlayId,
                            Seats = y.Key.Seats,
                            AmountOwed = y.Key.AmountOwed,
                            EarnedCredits = y.Key.ErnedCredits

                        }).ToList()

                    }).ToList();
                }

                return statementsList;

            }
            catch (Exception e)
            {
                throw new Exception($"Falha ao Listar Statementes! message :{e.Message}");
            }

        }

    }
}
