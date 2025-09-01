namespace WAR_Task13_OOP;

public class Data
{
    private static readonly Random random = new Random();

    public List<Soldier> playerArmy { get; set; }
    public List<Soldier> enemyArmy { get; set; }

    public Artillery myArtillery { get; private set; }
    public Cavalry myCavalry { get; private set; }
    public Infantry myInfantry { get; private set; }
    public Guard myGuard = new Guard();

    public Artillery enemyArtillery { get; private set; }
    public Cavalry enemyCavalry { get; private set; }
    public Infantry enemyInfantry { get; private set; }
    public Guard enemyGuard { get; private set; }

    public const int NumberOfInfantry = 40;
    public const int NumberOfGuard = 20;
    public const int NumberOfCavalry = 25;
    public const int NumberOfArtillery = 15;
    public const int MedicalSupport = 15;
    public const int DefenseDebaff = 15;
    public const int UltimateAttack = 10;
    public const int perUnit = 5;
    public const int GeneralDefenseBuff = 5;
    public const int GeneralAttackBuff = 5;

    public int EndOfGame { get; set; }
    public int EnemyLosses { get; set; }
    public int PlayerLosses { get; set; }
    public bool DefenderIsEnemy { get; set; }
    public bool PlayerIsSurrender { get; set; }
    public bool EnemyIsSurrender { get; set; }
    public bool AnyoneIsSurrender { get; set; }
    public bool PlayerHasActed { get; set; }
    public bool GeneralIsSelectedByEnemy = random.Next(2) == 1;
    public bool GeneralIsAttack { get; set; }
    public bool GeneralIsDeff { get; set; }
    public string PlayerGeneralNameInput { get; set; }
    public string EnemyGeneralNameInput { get; set; }

    public Data()
    {
        playerArmy = new List<Soldier>();
        enemyArmy = new List<Soldier>();

        // Шаблоны игрока
        myArtillery = new Artillery();
        myCavalry = new Cavalry();
        myInfantry = new Infantry();
        myGuard = new Guard();

        // Шаблоны врага
        enemyArtillery = new Artillery();
        enemyCavalry = new Cavalry();
        enemyInfantry = new Infantry();
        enemyGuard = new Guard();

        // Прочее
        PlayerIsSurrender = false;
        EnemyIsSurrender = false;
        PlayerHasActed = false;
        PlayerGeneralNameInput = string.Empty;
        EnemyGeneralNameInput = "Жмыхайко Альберт Фон Густаф-Цербстский-Минамото-Ходзё-Наполеон XIX-й";
    }
}
