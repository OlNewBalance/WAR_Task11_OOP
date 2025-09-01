namespace WAR_Task13_OOP;

public class GameCycle
{
    private Data _data;
    private GameMethods _gameMethods;
    private LocationsMethods _locationsMethods;
    private BattleInterface _battleInterface;
    private AttackGeneral _attackGeneral;
    private DeffGeneral _deffGeneral;

    public GameCycle()
    {
        _data = new Data();
        _gameMethods = new GameMethods(_data);
        _locationsMethods = new LocationsMethods(_data, _gameMethods);
        _attackGeneral = new AttackGeneral(_data.PlayerGeneralNameInput, Data.GeneralAttackBuff, _data);
        _deffGeneral = new DeffGeneral(_data.PlayerGeneralNameInput, Data.GeneralDefenseBuff, _data);
        _battleInterface = new BattleInterface();
    }

    public void GameMenu()
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

    private void GameSettings()
    {
        Console.Clear();
        Console.WriteLine("\nВыберите командующего:");
        Console.WriteLine("\n+ 1. Атакующий.");
        Console.WriteLine("\n+ 2. Защищающий.");
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        switch (keyInfo.Key)
        {
            case ConsoleKey.D1:
                _data.GeneralIsAttack = true;
                _attackGeneral.AttackBuff();
                break;
            case ConsoleKey.D2:
                _data.GeneralIsDeff = true;
                _deffGeneral.DeffenseBuff();
                break;
            default:
                Console.WriteLine("Неправильный выбор!");
                break;
        }

        if (_data.GeneralIsAttack == true || _data.GeneralIsDeff == true)
        {
            Console.WriteLine("\nНазовите командующего:");
            string input = Console.ReadLine()?.Trim();
            _data.PlayerGeneralNameInput = string.Join(" ", input);
            if (_data.PlayerGeneralNameInput != null || _data.PlayerGeneralNameInput != null)
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
                        _locationsMethods.Plane();
                        _gameMethods.FillPlayerArmyFromTemplates(Data.NumberOfInfantry, Data.NumberOfGuard,
                            Data.NumberOfCavalry, Data.NumberOfArtillery);
                        _gameMethods.FillEnemyArmyFromTemplates(Data.NumberOfInfantry, Data.NumberOfGuard,
                            Data.NumberOfCavalry, Data.NumberOfArtillery);
                        GameBattle();
                        break;
                    case ConsoleKey.D2:
                        _locationsMethods.Forest();
                        _gameMethods.FillPlayerArmyFromTemplates(Data.NumberOfInfantry, Data.NumberOfGuard,
                            Data.NumberOfCavalry, Data.NumberOfArtillery);
                        _gameMethods.FillEnemyArmyFromTemplates(Data.NumberOfInfantry, Data.NumberOfGuard,
                            Data.NumberOfCavalry, Data.NumberOfArtillery);
                        GameBattle();
                        break;
                    case ConsoleKey.D3:
                        _locationsMethods.HighGrounds();
                        _gameMethods.FillPlayerArmyFromTemplates(Data.NumberOfInfantry, Data.NumberOfGuard,
                            Data.NumberOfCavalry, Data.NumberOfArtillery);
                        _gameMethods.FillEnemyArmyFromTemplates(Data.NumberOfInfantry, Data.NumberOfGuard,
                            Data.NumberOfCavalry, Data.NumberOfArtillery);
                        GameBattle();
                        break;
                    case ConsoleKey.D4:
                        _locationsMethods.City();
                        _gameMethods.FillPlayerArmyFromTemplates(Data.NumberOfInfantry, Data.NumberOfGuard,
                            Data.NumberOfCavalry, Data.NumberOfArtillery);
                        _gameMethods.FillEnemyArmyFromTemplates(Data.NumberOfInfantry, Data.NumberOfGuard,
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

    public void GameBattle()
    {
        //Console.Clear();
        while (_data.playerArmy.Count > 0 && _data.enemyArmy.Count > 0)
        {
            while (!_data.PlayerIsSurrender && _data.playerArmy.Count != 0
                                            && _data.enemyArmy.Count != 0)
            {
                Console.WriteLine("\nБоевое поле:");
                _battleInterface.DrawBattleVisor(_data.playerArmy, _data.enemyArmy);
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
                        _data.DefenderIsEnemy = true;
                        int killed = _gameMethods.Attacking(_data.playerArmy,
                            _data.enemyArmy);
                        Console.WriteLine($"Ваша армия наступает на позиции противника! " +
                                          $"Потери противника: {killed} чел.");
                        _data.PlayerHasActed = true;
                        break;
                    case ConsoleKey.D2:
                        _data.DefenderIsEnemy = true;
                        int killed2 = _gameMethods.SuperAttacking(_data.playerArmy,
                            _data.enemyArmy);
                        Console.WriteLine($"Ваша армия проводит отчаянную атаку на позиции противника! " +
                                          $"Потери противника: {killed2} чел.");
                        _data.PlayerHasActed = true;
                        break;
                    case ConsoleKey.D3:
                        _data.DefenderIsEnemy = true;
                        int perUnit = _gameMethods.Defending(_data.playerArmy);
                        Console.WriteLine($"Ваша армия проводит укрепление траншей! " +
                                          $"Укрепленность увеличилась на: {perUnit}, на бойца, единиц на ход.");
                        _data.PlayerHasActed = true;
                        break;
                    case ConsoleKey.D4:
                        _data.DefenderIsEnemy = true;

                        int healed = _gameMethods.MedicalUnitRemoval(_data.playerArmy);
                        Console.WriteLine($"МедСанБат прибыл, и вылечил раненных солдат! " +
                                          $"Вылечено бойцов: {healed}.");
                        _data.PlayerHasActed = true;
                        break;
                    case ConsoleKey.D5:
                        _data.DefenderIsEnemy = true;
                        _gameMethods.DefendingDebaff(_data.enemyArmy);
                        Console.WriteLine($"Ваша разведка провела диверсию в логистических цепочках противника! " +
                                          $"Обороноспособность противника упала на: {Data.DefenseDebaff} единиц.");
                        break;
                    case ConsoleKey.D6:
                        _data.DefenderIsEnemy = true;
                        if (_data.playerArmy.Count < 60)
                        {
                            Console.WriteLine("Ваша армия понесла большие потери! Вы командуете ей отступить" +
                                              "и сдать позиции врагу!");
                            _data.PlayerIsSurrender = true;
                            GameMenu();
                        }
                        else if (_data.playerArmy.Count > 60)
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

                Console.WriteLine("Чтобы продолжить нажмите ENTER.");
                string input = Console.ReadLine();
                if (_data.PlayerIsSurrender == true || _data.EnemyIsSurrender == true)
                {
                    _gameMethods.Surrender();
                }

                if (_data.playerArmy.Count <= 0)
                {
                    Console.WriteLine(
                        $"Генерал {_data.EnemyGeneralNameInput} (враг) со своим войском молниеносно разгромил " +
                        $"войско вражеского генерала {_data.PlayerGeneralNameInput}!!!");
                    GameMenu();
                }
                else if (_data.enemyArmy.Count <= 0)
                {
                    Console.WriteLine(
                        $"Генерал {_data.PlayerGeneralNameInput} (вы) со своим войском молниеносно разгромил " +
                        $"войско вражеского генерала {_data.EnemyGeneralNameInput}!!!");
                    GameMenu();
                }

                if (_data.PlayerHasActed == true && input == "")
                {
                    Console.WriteLine("Ход противника.");
                    _data.DefenderIsEnemy = false;
                    _gameMethods.EnemyTurn();
                }

                _data.playerArmy.RemoveAll(s => !s.IsAlive);
                _data.enemyArmy.RemoveAll(s => !s.IsAlive);
            }
        }
    }
}
