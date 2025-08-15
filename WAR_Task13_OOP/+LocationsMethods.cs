namespace WAR_Task13_OOP;

public static class LocationsMethods
{
    public static void HighGrounds()
    {
        GameMethods.SafeModifyAttack(Data.myArtillery, 0, -20); // MaxAttack -=20
        Data.myCavalry.Defense -= 25;
        GameMethods.SafeModifyAttack(Data.myCavalry, -5, -10);
    
        Data.myInfantry.Defense += 25;
        GameMethods.SafeModifyAttack(Data.myInfantry, 5, 10);
    
        Data.myGuard.Defense += 25;
        GameMethods.SafeModifyAttack(Data.myGuard, 5, 10);
    }

    public static void City()
    {
        GameMethods.SafeModifyAttack(Data.myArtillery, 0, -15);
        GameMethods.SafeModifyAttack(Data.myCavalry, 10, 15);
    
        Data.myInfantry.Defense += 25;
        GameMethods.SafeModifyAttack(Data.myInfantry, -10, -15);
    
        Data.myGuard.Defense += 25;
        GameMethods.SafeModifyAttack(Data.myGuard, -10, -15);
    }

    public static void Plane()
    {
        GameMethods.SafeModifyAttack(Data.myArtillery, 10, 10);
        Data.myGuard.Defense -= 15;
        Data.myInfantry.Defense -= 15;
        Data.myCavalry.Defense += 15;
        GameMethods.SafeModifyAttack(Data.myCavalry, 10, 15);
    }

    public static void Forest()
    {
        // Артиллерия - только уменьшение MaxAttack
        GameMethods.SafeModifyAttack(Data.myArtillery, 0, -10); // MaxAttack -=10, MinAttack без изменений
    
        // Кавалерия - уменьшение всех характеристик
        Data.myCavalry.Defense -= 20;
        GameMethods.SafeModifyAttack(Data.myCavalry, -10, -20); // MinAttack -=10, MaxAttack -=20
    
        // Пехота - усиление
        Data.myInfantry.Defense += 20;
        GameMethods.SafeModifyAttack(Data.myInfantry, 10, 15); // MinAttack +=10, MaxAttack +=15
    
        // Гвардия - усиление
        Data.myGuard.Defense += 20;
        GameMethods.SafeModifyAttack(Data.myGuard, 10, 15); // MinAttack +=10, MaxAttack +=15
    }
}
