namespace WAR_Task13_OOP;

public static class Data
{
    public static bool GeneralIsSelected = false;
    public static bool GeneralIsAttack = false;
    public static bool GeneralIsDeff = false;
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    public static List<Soldier> playerArmy = new List<Soldier>();
    public static List<Soldier> enemyArmy = new List<Soldier>();
    public static Artillery myArtillery = new Artillery(); 
    public static Cavalry myCavalry = new Cavalry();
    public static Infantry myInfantry = new Infantry();
    public static Guard myGuard = new Guard();
    
}