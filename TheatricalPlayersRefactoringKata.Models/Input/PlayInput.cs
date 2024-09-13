using TheatricalPlayersRefactoringKata.Models.Enums;

namespace TheatricalPlayersRefactoringKata;

public class PlayInput
{
    private string _name;
    private int _lines;
    private PlayType _type;

    public string Name { get => _name; set => _name = value; }
    public int Lines { get => _lines; set => _lines = value; }
    public PlayType Type { get => _type; set => _type = value; }

    public PlayInput(string name, int lines, PlayType type) {
        this._name = name;
        this._lines = lines;
        this._type = type;
    }
}
