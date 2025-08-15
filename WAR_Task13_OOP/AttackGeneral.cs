namespace WAR_Task13_OOP;

public class AttackGeneral
{
    public static string GeneralName { get; set; }
    public static int GeneralAttackBuff;

    public AttackGeneral(string generalName, int generalAttackBuff)
    {
        GeneralName = generalName;
        generalName = Data.PlayerGeneralNameInput;
        GeneralAttackBuff = generalAttackBuff;
        generalAttackBuff = 5;
    }

    public static void AttackBuff()
    {
        if (Data.GeneralIsAttack == true)
        {
            Data.myArtillery.MaxAttack += GeneralAttackBuff;
            Data.myArtillery.MinAttack += GeneralAttackBuff;
            Data.myInfantry.MaxAttack += GeneralAttackBuff;
            Data.myInfantry.MinAttack += GeneralAttackBuff;
            Data.myCavalry.MaxAttack += GeneralAttackBuff;
            Data.myCavalry.MinAttack += GeneralAttackBuff;
            Data.myGuard.MaxAttack += GeneralAttackBuff;
            Data.myGuard.MinAttack += GeneralAttackBuff;
        }

        if (Data.GeneralIsSelectedByEnemy == true)
        {
            Data.enemyArtillery.MaxAttack += GeneralAttackBuff;
            Data.enemyArtillery.MinAttack += GeneralAttackBuff;
            Data.enemyInfantry.MaxAttack += GeneralAttackBuff;
            Data.enemyInfantry.MinAttack += GeneralAttackBuff;
            Data.enemyCavalry.MaxAttack += GeneralAttackBuff;
            Data.enemyCavalry.MinAttack += GeneralAttackBuff;
            Data.enemyGuard.MaxAttack += GeneralAttackBuff;
            Data.enemyGuard.MinAttack += GeneralAttackBuff;
        }
    }
}
