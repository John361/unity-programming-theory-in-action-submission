[System.Serializable]
public class UnitLevel
{
    // Private attributes
    private string _name;
    private int _level;

    // Public/Protected/Private attributes
    public string Name
    {
        get { return this._name; }
        private set { this._name = value; }
    }

    public int Level
    {
        get { return this._level; }
        private set { this._level = value; }
    }

    // Public static methods
    public static UnitLevel Build(int level)
    {
        return level switch
        {
            3 => UnitLevel.LevelAdvanced(),
            2 => UnitLevel.LevelIntermediate(),
            _ => UnitLevel.LevelBeginner(),
        };
    }

    // Private static methods
    private static UnitLevel LevelBeginner()
    {
        return new UnitLevel
        {
            Name = "Beginner",
            Level = 1
        };
    }

    private static UnitLevel LevelIntermediate()
    {
        return new UnitLevel
        {
            Name = "Intermediate",
            Level = 2
        };
    }

    private static UnitLevel LevelAdvanced()
    {
        return new UnitLevel
        {
            Name = "Advanced",
            Level = 3
        };
    }
}
