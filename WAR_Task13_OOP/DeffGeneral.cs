public class DeffGeneral
{
    public static string GeneralName { get; set; }
    public static int GeneralDefenseBuff;

    public DeffGeneral(string generalName, int generalDefenseBuff)
    {
        GeneralName = generalName;
        generalName = Data.PlayerGeneralNameInput;
        GeneralDefenseBuff = generalDefenseBuff;
        generalDefenseBuff = 5;
    }

    public static void DeffenseBuff()
    {
        if (Data.GeneralIsDeff == true)
        {
            Data.myArtillery.Defense += GeneralDefenseBuff;
            Data.myArtillery.Defense += GeneralDefenseBuff;
            Data.myInfantry.Defense += GeneralDefenseBuff;
            Data.myInfantry.Defense += GeneralDefenseBuff;
            Data.myCavalry.Defense += GeneralDefenseBuff;
            Data.myCavalry.Defense += GeneralDefenseBuff;
            Data.myGuard.Defense += GeneralDefenseBuff;
            Data.myGuard.Defense += GeneralDefenseBuff;
        }

        if (Data.GeneralIsSelectedByEnemy == true)
        {
            Data.enemyArtillery.Defense += GeneralDefenseBuff;
            Data.enemyArtillery.Defense += GeneralDefenseBuff;
            Data.enemyInfantry.Defense += GeneralDefenseBuff;
            Data.enemyInfantry.Defense += GeneralDefenseBuff;
            Data.enemyCavalry.Defense += GeneralDefenseBuff;
            Data.enemyCavalry.Defense += GeneralDefenseBuff;
            Data.enemyGuard.Defense += GeneralDefenseBuff;
            Data.enemyGuard.Defense += GeneralDefenseBuff;
        }
    }
}
