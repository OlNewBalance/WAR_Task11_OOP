namespace WAR_Task13_OOP;

public class LocationsMethods
{
    private readonly Data _data;
    private readonly GameMethods _gameMethods;

    public LocationsMethods(Data data, GameMethods gameMethods)
    {
        _gameMethods = gameMethods;
        _data = data;
    }
    public void HighGrounds()
    {
        _gameMethods.SafeModifyAttack(_data.myArtillery, 0, -20); // MaxAttack -=20
        _data.myCavalry.Defense -= 25;
        _gameMethods.SafeModifyAttack(_data.myCavalry, -5, -10);
    
        _data.myInfantry.Defense += 25;
        _gameMethods.SafeModifyAttack(_data.myInfantry, 5, 10);
    
        _data.myGuard.Defense += 25;
        _gameMethods.SafeModifyAttack(_data.myGuard, 5, 10);
    }

    public void City()
    {
        _gameMethods.SafeModifyAttack(_data.myArtillery, 0, -15);
        _gameMethods.SafeModifyAttack(_data.myCavalry, 10, 15);
    
        _data.myInfantry.Defense += 25;
        _gameMethods.SafeModifyAttack(_data.myInfantry, -10, -15);
    
        _data.myGuard.Defense += 25;
        _gameMethods.SafeModifyAttack(_data.myGuard, -10, -15);
    }

    public void Plane()
    {
        if (_data == null)
        {
            throw new Exception("Ошибка: _data в LocationsMethods == null");
        }
        if (_data.myGuard == null)
        {
            throw new Exception("Ошибка: _data.myGuard == null");
        }
        _gameMethods.SafeModifyAttack(_data.myArtillery, 10, 10);
        _data.myGuard.Defense -= 15;
        _data.myInfantry.Defense -= 15;
        _data.myCavalry.Defense += 15;
        _gameMethods.SafeModifyAttack(_data.myCavalry, 10, 15);
    }

    public void Forest()
    {
        // Артиллерия - только уменьшение MaxAttack
        _gameMethods.SafeModifyAttack(_data.myArtillery, 0, -10); // MaxAttack -=10, MinAttack без изменений
    
        // Кавалерия - уменьшение всех характеристик
        _data.myCavalry.Defense -= 20;
        _gameMethods.SafeModifyAttack(_data.myCavalry, -10, -20); // MinAttack -=10, MaxAttack -=20
    
        // Пехота - усиление
        _data.myInfantry.Defense += 20;
        _gameMethods.SafeModifyAttack(_data.myInfantry, 10, 15); // MinAttack +=10, MaxAttack +=15
    
        // Гвардия - усиление
        _data.myGuard.Defense += 20;
        _gameMethods.SafeModifyAttack(_data.myGuard, 10, 15); // MinAttack +=10, MaxAttack +=15
    }
}
