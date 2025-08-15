namespace WAR_Task13_OOP;

public static class GameMethods
{
    private static readonly Random random = new Random();

    public static int MedicalUnitRemoval(List<Soldier> army)
    {
        int healed = 0;
        foreach (var s in army.Where(x => x.IsAlive && x.HealthPoint < 100))
        { s.HealthPoint = Math.Min(100, s.HealthPoint + Data.MedicalSupport); healed++; }
        return healed;
    }

    public static int Attacking(List<Soldier> atk, List<Soldier> def)
    {
        int kills = 0;
        foreach (var a in atk.Where(x => x.IsAlive))
        {
            var target = def.Where(x => x.IsAlive).OrderBy(_ => Guid.NewGuid()).FirstOrDefault();
            if (target == null) break;

            int dmg = Math.Max(1, GetSafeAttackDamage(a) / 2 - target.Defense / 3);
            target.HealthPoint -= dmg;
            if (target.HealthPoint <= 0 && target.IsAlive)
            {
                target.IsAlive = false;
                kills++;
            }
        }
        def.RemoveAll(x => !x.IsAlive);
        return kills;
    }


    public static int SuperAttacking(List<Soldier> atk, List<Soldier> def)
    {
        int kills = 0;
        foreach (var a in atk.Where(x => x.IsAlive))
        {
            var t = def.Where(x => x.IsAlive).OrderBy(_ => Guid.NewGuid()).FirstOrDefault();
            if (t == null) break;

            int baseDmg = random.Next(a.MinAttack, a.MaxAttack + 1);
            int dmg = Math.Max(1, baseDmg - t.Defense / 2) + Data.UltimateAttack;
            t.HealthPoint -= dmg;
            if (t.HealthPoint <= 0 && t.IsAlive) { t.IsAlive = false; kills++; }
        }
        def.RemoveAll(x => !x.IsAlive);
        return kills;
    }

    public static int Defending(List<Soldier> army)
    {
        int affected = 0;
        foreach (var s in army.Where(x => x.IsAlive)) { s.Defense += Data.perUnit; affected++; }
        return Data.perUnit;               // печатаем прирост на одного бойца
    }

    public static int DefendingDebaff(List<Soldier> army)
    {
        foreach (var s in army.Where(x => x.IsAlive))
            s.Defense = Math.Max(0, s.Defense - Data.perUnit);
        return Data.perUnit;
    }
    private static void AddCopies(List<Soldier> army, Soldier template, int count)
    {
        for (int i = 0; i < count; i++)
            army.Add(template.Clone());
    }

    public static void FillPlayerArmyFromTemplates(int infantryCount, int guardCount, int cavalryCount, int artilleryCount)
    {
        Data.playerArmy.Clear();

        AddCopies(Data.playerArmy, Data.myInfantry,  infantryCount);
        AddCopies(Data.playerArmy, Data.myGuard,     guardCount);
        AddCopies(Data.playerArmy, Data.myCavalry,   cavalryCount);
        AddCopies(Data.playerArmy, Data.myArtillery, artilleryCount);
    }

    public static void FillEnemyArmyFromTemplates(int infantryCount, int guardCount, int cavalryCount, int artilleryCount)
    {
        Data.enemyArmy.Clear();

        AddCopies(Data.enemyArmy, Data.enemyInfantry,  infantryCount);
        AddCopies(Data.enemyArmy, Data.enemyGuard,     guardCount);
        AddCopies(Data.enemyArmy, Data.enemyCavalry,   cavalryCount);
        AddCopies(Data.enemyArmy, Data.enemyArtillery, artilleryCount);
    }

    public static void EnemyTurn()
    {
        int enemyTurnRoll = random.Next(1, 14);
        switch (enemyTurnRoll)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                GameMethods.Attacking(Data.enemyArmy, Data.playerArmy);
                int killed = GameMethods.SuperAttacking(Data.enemyArmy, Data.playerArmy);
                Console.WriteLine($"Армия противника наступает на ваши позиции! " +
                                  $"Ваши потери: {Data.EnemyLosses} чел.");
                Data.PlayerHasActed = true;
                break;
            case 5:
            case 6:
                GameMethods.SuperAttacking(Data.enemyArmy, Data.playerArmy);
                int killed2 = GameMethods.SuperAttacking(Data.enemyArmy, Data.playerArmy);
                Console.WriteLine($"Армия противника проводит отчаянную атаку на ваши позиции! " +
                                  $"Ваши потери: {killed2} чел.");
                Data.PlayerHasActed = true;
                break;
            case 7:
            case 8:
            case 9:
                GameMethods.Defending(Data.enemyArmy);
                int perUnit = GameMethods.Defending(Data.enemyArmy);
                Console.WriteLine($"Армия противника проводит укрепление траншей! " +
                                  $"Укрепленность увеличилась на: {perUnit}, на бойца, единиц на ход.");
                
                Data.PlayerHasActed = true;
                break;
            case 10:
            case 11:
                GameMethods.MedicalUnitRemoval(Data.enemyArmy);
                int healed = GameMethods.MedicalUnitRemoval(Data.enemyArmy);
                Console.WriteLine($"Вражеский МедСанБат прибыл, и вылечил раненных солдат противника! " +
                                  $"Вылечено бойцов: {healed}.");
                Data.PlayerHasActed = true;
                break;
            case 12:
            case 13:
                Console.WriteLine($"Разведка противника провела диверсию в ваших логистических цепочках! " +
                                  $"Ваша обороноспособность упала на: {Data.DefenseDebaff} единиц.");
                DefendingDebaff(Data.playerArmy);
                break;
            case 14:
                if (Data.enemyArmy.Count < 60)
                {
                    Console.WriteLine($"Армия противника отступает!");
                    Data.EnemyIsSurrender = true;
                }
                else if (Data.enemyArmy.Count > 60)
                {
                    return;
                }
                
                break;
            default:
                Console.WriteLine("Ошибка в работе метода!");
                break;
        }
    }
    
    public static void SafeModifyAttack(Soldier unit, int minMod, int maxMod)
    {
        unit.MaxAttack = Math.Max(unit.MinAttack + 1, unit.MaxAttack + maxMod);
        unit.MinAttack = Math.Min(unit.MaxAttack - 1, unit.MinAttack + minMod);
    }
    public static int GetSafeAttackDamage(Soldier attacker)
    {
        // Гарантируем корректные значения
        int min = Math.Min(attacker.MinAttack, attacker.MaxAttack - 1);
        int max = Math.Max(attacker.MaxAttack, attacker.MinAttack + 1);
    
        // Если значения всё равно некорректны (например, оба = 0)
        if (min >= max)
        {
            min = 0;
            max = 1;
            Console.WriteLine($"Warning: Invalid attack values for {attacker.GetType().Name}");
        }
    
        return random.Next(min, max + 1);
    }

    public static void Surrender()
    {
        if (Data.PlayerIsSurrender == true)
        {
            Console.WriteLine($"Генерал {Data.EnemyGeneralNameInput} (враг) вынудил ваше войско " +
                              $"{Data.PlayerGeneralNameInput} отступить!!!");
            GameCycle.GameMenu();
        }
        else if (Data.EnemyIsSurrender == true)
        {
            Console.WriteLine($"Вы, генерал {Data.PlayerGeneralNameInput}, вынудили вражеское войско " +
                              $"{Data.EnemyGeneralNameInput} отступить!!!");
            GameCycle.GameMenu();
        }
       
    }
}
