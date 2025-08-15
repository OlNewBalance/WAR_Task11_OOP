namespace WAR_Task13_OOP;

public static class Data
{
    private static readonly Random random = new Random();
    
    public static List<Soldier> playerArmy = new List<Soldier>();
    public static List<Soldier> enemyArmy = new List<Soldier>();
    
    public static Artillery myArtillery = new Artillery();
    public static Cavalry myCavalry = new Cavalry();
    public static Infantry myInfantry = new Infantry();
    public static Guard myGuard = new Guard();
    
    public static Artillery enemyArtillery = new Artillery();
    public static Cavalry enemyCavalry = new Cavalry();
    public static Infantry enemyInfantry = new Infantry();
    public static Guard enemyGuard = new Guard();

    public const int NumberOfInfantry  = 40;
    public const int NumberOfGuard     = 20;
    public const int NumberOfCavalry   = 25;
    public const int NumberOfArtillery = 15;
    public const int MedicalSupport = 15;
    public const int DefenseDebaff = 15;
    public const int UltimateAttack = 10;
    public const int perUnit = 5;
    
    public static int EndOfGame = 0;
    public static int EnemyLosses = 0;
    public static int PlayerLosses = 0;
    public static bool DefenderIsEnemy = false;
    public static bool PlayerIsSurrender = false;
    public static bool EnemyIsSurrender = false;
    public static bool AnyoneIsSurrender = false;
    public static bool PlayerHasActed = false;
    public static bool GeneralIsSelectedByEnemy = random.Next(2) == 1;
    public static bool GeneralIsAttack = false;
    public static bool GeneralIsDeff = false;
    public static string PlayerGeneralNameInput { get; set; }
    public static string EnemyGeneralNameInput = "Жмыхайко Альберт Фон Густаф-Цербстский-Минамото-Ходзё-Наполеон XIX-й";
}
