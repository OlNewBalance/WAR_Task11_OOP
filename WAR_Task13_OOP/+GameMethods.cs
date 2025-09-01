namespace WAR_Task13_OOP;

public class GameMethods
{
    private readonly Data _data;
    GameCycle gameCycle;
    private static readonly Random random = new Random();

    public GameMethods(Data data)
    {
        _data = data;
    }
    
    public int MedicalUnitRemoval(List<Soldier> army)
    {
        int healed = 0;
        foreach (var s in army.Where(x => x.IsAlive && x.HealthPoint < 100))
        { s.HealthPoint = Math.Min(100, s.HealthPoint + Data.MedicalSupport); healed++; }
        return healed;
    }

    public int Attacking(List<Soldier> atk, List<Soldier> def)
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


    public int SuperAttacking(List<Soldier> atk, List<Soldier> def)
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

    public int Defending(List<Soldier> army)
    {
        int affected = 0;
        foreach (var s in army.Where(x => x.IsAlive)) { s.Defense += Data.perUnit; affected++; }
        return Data.perUnit;               // печатаем прирост на одного бойца
    }

    public int DefendingDebaff(List<Soldier> army)
    {
        foreach (var s in army.Where(x => x.IsAlive))
            s.Defense = Math.Max(0, s.Defense - Data.perUnit);
        return Data.perUnit;
    }
    private void AddCopies(List<Soldier> army, Soldier template, int count)
    {
        for (int i = 0; i < count; i++)
            army.Add(template.Clone());
    }

    public void FillPlayerArmyFromTemplates(int infantryCount, int guardCount, int cavalryCount, int artilleryCount)
    {
        _data.playerArmy.Clear();

        AddCopies(_data.playerArmy, _data.myInfantry,  infantryCount);
        AddCopies(_data.playerArmy, _data.myGuard,     guardCount);
        AddCopies(_data.playerArmy, _data.myCavalry,   cavalryCount);
        AddCopies(_data.playerArmy, _data.myArtillery, artilleryCount);
    }

    public void FillEnemyArmyFromTemplates(int infantryCount, int guardCount, int cavalryCount, int artilleryCount)
    {
        _data.enemyArmy.Clear();

        AddCopies(_data.enemyArmy, _data.enemyInfantry,  infantryCount);
        AddCopies(_data.enemyArmy, _data.enemyGuard,     guardCount);
        AddCopies(_data.enemyArmy, _data.enemyCavalry,   cavalryCount);
        AddCopies(_data.enemyArmy, _data.enemyArtillery, artilleryCount);
    }

    public void EnemyTurn()
    {
        int enemyTurnRoll = random.Next(1, 14);
        switch (enemyTurnRoll)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                int killed = SuperAttacking(_data.enemyArmy, _data.playerArmy);
                Console.WriteLine($"Армия противника наступает на ваши позиции! " +
                                  $"Ваши потери: {_data.EnemyLosses} чел.");
                _data.PlayerHasActed = true;
                break;
            case 5:
            case 6:
                int killed2 = SuperAttacking(_data.enemyArmy, _data.playerArmy);
                Console.WriteLine($"Армия противника проводит отчаянную атаку на ваши позиции! " +
                                  $"Ваши потери: {killed2} чел.");
                _data.PlayerHasActed = true;
                break;
            case 7:
            case 8:
            case 9:
                int perUnit = Defending(_data.enemyArmy);
                Console.WriteLine($"Армия противника проводит укрепление траншей! " +
                                  $"Укрепленность увеличилась на: {perUnit}, на бойца, единиц на ход.");
                
                _data.PlayerHasActed = true;
                break;
            case 10:
            case 11:
                int healed = MedicalUnitRemoval(_data.enemyArmy);
                Console.WriteLine($"Вражеский МедСанБат прибыл, и вылечил раненных солдат противника! " +
                                  $"Вылечено бойцов: {healed}.");
                _data.PlayerHasActed = true;
                break;
            case 12:
            case 13:
                Console.WriteLine($"Разведка противника провела диверсию в ваших логистических цепочках! " +
                                  $"Ваша обороноспособность упала на: {Data.DefenseDebaff} единиц.");
                DefendingDebaff(_data.playerArmy);
                break;
            case 14:
                if (_data.enemyArmy.Count < 60)
                {
                    Console.WriteLine($"Армия противника отступает!");
                    _data.EnemyIsSurrender = true;
                }
                else if (_data.enemyArmy.Count > 60)
                {
                    return;
                }
                
                break;
            default:
                Console.WriteLine("Ошибка в работе метода!");
                break;
        }
    }
    
    public void SafeModifyAttack(Soldier unit, int minMod, int maxMod)
    {
        unit.MaxAttack = Math.Max(unit.MinAttack + 1, unit.MaxAttack + maxMod);
        unit.MinAttack = Math.Min(unit.MaxAttack - 1, unit.MinAttack + minMod);
    }
    public int GetSafeAttackDamage(Soldier attacker)
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

    public void Surrender()
    {
        if (_data.PlayerIsSurrender == true)
        {
            Console.WriteLine($"Генерал {_data.EnemyGeneralNameInput} (враг) вынудил ваше войско " +
                              $"{_data.PlayerGeneralNameInput} отступить!!!");
        }
        else if (_data.EnemyIsSurrender == true)
        {
            Console.WriteLine($"Вы, генерал {_data.PlayerGeneralNameInput}, вынудили вражеское войско " +
                              $"{_data.EnemyGeneralNameInput} отступить!!!");
        }
       
    }
}
