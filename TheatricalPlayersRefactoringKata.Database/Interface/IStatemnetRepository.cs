using TheatricalPlayersRefactoringKata.Models.Dto;

namespace TheatricalPlayersRefactoringKata.Database.Interface
{
    public interface IStatemnetRepository
    {
        void AddStatement(StatementDto statement);

        List<StatementDto> GetAllStatement();
    }
}
