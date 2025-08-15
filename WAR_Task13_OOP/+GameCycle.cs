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
                    Console.WriteLine("Неверный выбор!");
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
                    //
                    Data.GeneralIsSelected = true;
                    Data.GeneralIsAttack = true;
                    break;
                case ConsoleKey.D2:
                    //
                    Data.GeneralIsSelected = true;
                    Data.GeneralIsDeff = true;
                    break;
                default:
                    break;
            }

            if (Data.GeneralIsSelected == true)
            {
                Console.WriteLine("\nНазовите командующего:");
                Console.ReadLine();
                string GeneralNameInput = Console.ReadLine();
                if (GeneralNameInput != null && Data.GeneralIsAttack == true)
                {
                    AttackGeneral.GeneralName = GeneralNameInput;
                }

                if (GeneralNameInput != null && Data.GeneralIsDeff == true)
                {
                    DeffGeneral.GeneralName = GeneralNameInput;
                }
            }

            if (AttackGeneral.GeneralName != null || DeffGeneral.GeneralName != null)
            {
                Console.WriteLine("\nВыберите локацию:");
                Console.WriteLine("\n+ 1. Поле.");
                Console.WriteLine("\n+ 2. Лес.");
                Console.WriteLine("\n+ 3. Возвышенности.");
                Console.WriteLine("\n+ 4. Город.");
                ConsoleKeyInfo keyInfo2 = Console.ReadKey(true);
                switch (keyInfo2.Key)
                {
                    case ConsoleKey.D1:
                        Data.myArtillery.MaxAttack += 10;             
                        Data.myArtillery.MinAttack += 10;
                        Data.myGuard.Defense -= 15;
                        Data.myInfantry.Defense -= 15;
                        Data.myCavalry.Defense += 15;
                        Data.myCavalry.MaxAttack += 15;
                        Data.myCavalry.MinAttack += 10;
                        GameBattle();
                        break;
                    case ConsoleKey.D2:
                        Data.myArtillery.MaxAttack -= 10;
                        Data.myCavalry.Defense -= 20;
                        Data.myCavalry.MaxAttack -= 20;
                        Data.myCavalry.MinAttack -= 10;
                        Data.myInfantry.Defense += 20;
                        Data.myInfantry.MaxAttack += 15;
                        Data.myInfantry.MinAttack += 10;
                        Data.myGuard.Defense += 20;
                        Data.myGuard.MaxAttack += 15;
                        Data.myGuard.MinAttack += 10;
                        GameBattle();
                        break; 
                    case ConsoleKey.D3:
                        Data.myArtillery.MaxAttack -= 20;             
                        Data.myCavalry.Defense -= 25;
                        Data.myCavalry.MaxAttack -= 10;
                        Data.myCavalry.MinAttack -= 5;
                        Data.myInfantry.Defense += 25;
                        Data.myInfantry.MaxAttack += 10;
                        Data.myInfantry.MinAttack += 5;
                        Data.myGuard.Defense += 25;
                        Data.myGuard.MaxAttack += 10;
                        Data.myGuard.MinAttack += 5;
                        GameBattle();
                        break; 
                    case ConsoleKey.D4:
                        Data.myArtillery.MaxAttack -= 15;  
                        Data.myCavalry.MaxAttack += 15;
                        Data.myCavalry.MinAttack += 10;
                        Data.myInfantry.Defense += 25;
                        Data.myInfantry.MaxAttack -= 15;
                        Data.myInfantry.MinAttack -= 10;
                        Data.myGuard.Defense += 25;
                        Data.myGuard.MaxAttack -= 15;
                        Data.myGuard.MinAttack -= 10;
                        GameBattle();
                        break; 
                    default:
                        break;
                }
                
            }
            
        }
    public static void GameBattle()
    {
        Console.Clear();
        Console.WriteLine("\nБоевое поле:");
            
    }
}