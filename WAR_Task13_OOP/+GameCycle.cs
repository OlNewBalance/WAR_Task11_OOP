namespace WAR_Task13_OOP;

public static class GameCycle
{
    public static void GameMenu()
    {
        Console.WriteLine("Чтобы начать, нажмите ENTER...");
        string input = Console.ReadLine();
        while (input == "")
        {
            Console.Clear();
            Console.WriteLine("\nМеню.");
            Console.WriteLine("\n+ 1. Играть.");
            Console.WriteLine("\n+ 2. Просмотреть бой.");
            Console.WriteLine("\n+ 3. Выход.");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    GameSettings();
                    break;
                case ConsoleKey.D2:
                    //ShowBattleChronicle();
                    break;
                case ConsoleKey.D3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неправильный выбор!");
                    break;
            }
        }
    }

    private static void GameSettings()
    {
        Console.Clear();
        Console.WriteLine("\nВыберите командующего:");
        Console.WriteLine("\n+ 1. Атакующий.");
        Console.WriteLine("\n+ 2. Защищающий.");
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        switch (keyInfo.Key)
        {
            case ConsoleKey.D1:
                Data.GeneralIsAttack = true;
                AttackGeneral.AttackBuff();
                break;
            case ConsoleKey.D2:
                Data.GeneralIsDeff = true;
                DeffGeneral.DeffenseBuff();
                break;
            default:
                Console.WriteLine("Неправильный выбор!");
                break;
        }
        
        if (Data.GeneralIsAttack == true || Data.GeneralIsDeff == true)
        {
            Console.WriteLine("\nНазовите командующего:");
            string input = Console.ReadLine()?.Trim();
            Data.PlayerGeneralNameInput = string.Join(" ", input);
            if (Data.PlayerGeneralNameInput != null || Data.PlayerGeneralNameInput != null)
            {
                Console.Clear();
                Console.WriteLine("\nВыберите локацию:");
                Console.WriteLine("\n+ 1. Поле.");
                Console.WriteLine("\n+ 2. Лес.");
                Console.WriteLine("\n+ 3. Возвышенности.");
                Console.WriteLine("\n+ 4. Город.");
                ConsoleKeyInfo keyInfo2 = Console.ReadKey(true);
                switch (keyInfo2.Key)
                {
                    case ConsoleKey.D1:
                        LocationsMethods.Plane();
                        GameMethods.FillPlayerArmyFromTemplates(Data.NumberOfInfantry, Data.NumberOfGuard,
                            Data.NumberOfCavalry, Data.NumberOfArtillery);
                        GameMethods.FillEnemyArmyFromTemplates(Data.NumberOfInfantry, Data.NumberOfGuard,
                            Data.NumberOfCavalry, Data.NumberOfArtillery);
                        GameBattle();
                        break;
                    case ConsoleKey.D2:
                        LocationsMethods.Forest();
                        GameMethods.FillPlayerArmyFromTemplates(Data.NumberOfInfantry, Data.NumberOfGuard,
                            Data.NumberOfCavalry, Data.NumberOfArtillery);
                        GameMethods.FillEnemyArmyFromTemplates(Data.NumberOfInfantry, Data.NumberOfGuard,
                            Data.NumberOfCavalry, Data.NumberOfArtillery);
                        GameBattle();
                        break;
                    case ConsoleKey.D3:
                        LocationsMethods.HighGrounds();
                        GameMethods.FillPlayerArmyFromTemplates(Data.NumberOfInfantry, Data.NumberOfGuard,
                            Data.NumberOfCavalry, Data.NumberOfArtillery);
                        GameMethods.FillEnemyArmyFromTemplates(Data.NumberOfInfantry, Data.NumberOfGuard,
                            Data.NumberOfCavalry, Data.NumberOfArtillery);
                        GameBattle();
                        break;
                    case ConsoleKey.D4:
                        LocationsMethods.City();
                        GameMethods.FillPlayerArmyFromTemplates(Data.NumberOfInfantry, Data.NumberOfGuard,
                            Data.NumberOfCavalry, Data.NumberOfArtillery);
                        GameMethods.FillEnemyArmyFromTemplates(Data.NumberOfInfantry, Data.NumberOfGuard,
                            Data.NumberOfCavalry, Data.NumberOfArtillery);
                        GameBattle();
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор!");
                        break;
                }
            }
        }
    }

    public static void GameBattle()
    {
        Console.Clear();
        while (Data.playerArmy.Count > 0 && Data.enemyArmy.Count > 0)
        {
            while (!Data.PlayerIsSurrender && Data.playerArmy.Count != 0 && Data.enemyArmy.Count != 0)
            {

                Console.WriteLine("\nБоевое поле:");
                BattleInterface.DrawBattleVisor(Data.playerArmy, Data.enemyArmy);
                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("\nВыберите действие, командир:");
                Console.WriteLine("\n+ 1. Атака.");
                Console.WriteLine("\n+ 2. Отчаянная атака.");
                Console.WriteLine("\n+ 3. Окопаться.");
                Console.WriteLine("\n+ 4. Вызвать МедСанБат.");
                Console.WriteLine("\n+ 5. Нарушить логистику противника.");
                Console.WriteLine("\n+ 6. Отступить.");
                ConsoleKeyInfo keyInfo2 = Console.ReadKey(true);
                switch (keyInfo2.Key)
                {
                    case ConsoleKey.D1:
                        Data.DefenderIsEnemy = true;
                        GameMethods.Attacking(Data.playerArmy, Data.enemyArmy);
                        int killed = GameMethods.Attacking(Data.playerArmy, Data.enemyArmy);
                        Console.WriteLine($"Ваша армия наступает на позиции противника! " +
                                          $"Потери противника: {killed} чел.");
                        Data.PlayerHasActed = true;
                        break;
                    case ConsoleKey.D2:
                        Data.DefenderIsEnemy = true;
                        GameMethods.SuperAttacking(Data.playerArmy, Data.enemyArmy);
                        int killed2 = GameMethods.SuperAttacking(Data.playerArmy, Data.enemyArmy);
                        Console.WriteLine($"Ваша армия проводит отчаянную атаку на позиции противника! " +
                                          $"Потери противника: {killed2} чел.");
                        Data.PlayerHasActed = true;
                        break;
                    case ConsoleKey.D3:
                        Data.DefenderIsEnemy = true;
                        GameMethods.Defending(Data.playerArmy);
                        int perUnit = GameMethods.Defending(Data.playerArmy);
                        Console.WriteLine($"Ваша армия проводит укрепление траншей! " +
                                          $"Укрепленность увеличилась на: {perUnit}, на бойца, единиц на ход.");
                        Data.PlayerHasActed = true;
                        break;
                    case ConsoleKey.D4:
                        Data.DefenderIsEnemy = true;
                        GameMethods.MedicalUnitRemoval(Data.playerArmy);
                        int healed = GameMethods.MedicalUnitRemoval(Data.playerArmy);
                        Console.WriteLine($"МедСанБат прибыл, и вылечил раненных солдат! " +
                                          $"Вылечено бойцов: {healed}.");
                        Data.PlayerHasActed = true;
                        break;
                    case ConsoleKey.D5:
                        Data.DefenderIsEnemy = true;
                        GameMethods.DefendingDebaff(Data.enemyArmy);
                        Console.WriteLine($"Ваша разведка провела диверсию в логистических цепочках противника! " +
                                          $"Обороноспособность противника упала на: {Data.DefenseDebaff} единиц.");
                        break;
                    case ConsoleKey.D6:
                        Data.DefenderIsEnemy = true;
                        if (Data.playerArmy.Count < 60)
                        {
                            Console.WriteLine("Ваша армия понесла большие потери! Вы командуете ей отступить" +
                                              "и сдать позиции врагу!");
                            Data.PlayerIsSurrender = true;
                        }
                        else if (Data.playerArmy.Count > 60)
                        {
                            Console.WriteLine("Вы не можете отступить! У вас ещё есть все ресурсы чтобы переломить " +
                                              "ход боя в свою пользу! Высшее командование не одобрит сдачу позиций!");
                            return;
                        }
                            break;
                    default:
                        Console.WriteLine("Неправильный выбор!");
                        return;
                        break;
                }
                Data.playerArmy.RemoveAll(s => !s.IsAlive);
                Data.enemyArmy.RemoveAll(s => !s.IsAlive);
                Console.WriteLine("Чтобы продолжить нажмите ENTER.");
                string input = Console.ReadLine();
                if (Data.PlayerIsSurrender == true || Data.EnemyIsSurrender == true)
                {
                    GameMethods.Surrender();
                }
                if (Data.playerArmy.Count <= 0)
                {
                    Console.WriteLine($"Генерал {Data.EnemyGeneralNameInput} (враг) со своим войском молниеносно разгромил " +
                                      $"войско вражеского генерала {Data.PlayerGeneralNameInput}!!!");
                    GameMenu();
                }
                else if (Data.enemyArmy.Count <= 0)
                {
                    Console.WriteLine($"Генерал {Data.PlayerGeneralNameInput} (вы) со своим войском молниеносно разгромил " +
                                      $"войско вражеского генерала {Data.EnemyGeneralNameInput}!!!");
                    GameMenu();
                }
                if (Data.PlayerHasActed == true && input == "")
                {
                    Console.WriteLine("Ход противника.");
                    Data.DefenderIsEnemy = false;
                    GameMethods.EnemyTurn();
                }
            }
        }
    }
}
