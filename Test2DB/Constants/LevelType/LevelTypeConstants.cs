namespace ConsoleApp1.Constants.LevelType;

public static class LevelTypeConstants
{

    public const int CriticalIdLevelType = 1;

    public const int HighIdLevelType = 2;

    public const int MediumIdLevelType = 3;

    public const int LowIdLevelType = 4;


    public const string CriticalNameLevelType = "Критический";

    public const string HighNameLevelType = "Высокий";

    public const string MediumNameLevelType = "Средний";

    public const string LowNameLevelType = "Низкий";


    public static readonly Dictionary<string, int> LevelTypeIdByName = new()
    {
        [CriticalNameLevelType] = CriticalIdLevelType,
        [HighNameLevelType] = HighIdLevelType,
        [MediumNameLevelType] = MediumIdLevelType,
        [LowNameLevelType] = LowIdLevelType,
    };

    public static readonly Dictionary<string, int> LevelTypeIdByTableName = new()
    {
        ["Риск:Критический"] = CriticalIdLevelType,
        ["Риск:Высокий"] = HighIdLevelType,
        ["Риск:Средний"] = MediumIdLevelType,
        ["Риск:Низкий"] = LowIdLevelType,
    };
}