namespace WAR_Task13_OOP;

public class BattleInterface
{
    public string GetBar(int value, int max, int width)
    {
        int filled = (int)Math.Round((double)value / max * width);
        return new string('/', filled).PadRight(width, '_');
    }
    public void DrawBattleVisor(List<Soldier> playerArmy, List<Soldier> enemyArmy)
    {

        string[] types = { "Infantry", "Guard", "Cavalry", "Artillery" };
        int[] maxCounts = { 40, 20, 25, 15 };

        Console.WriteLine("== ВИЗОР БОЯ ==");
        Console.WriteLine();

        for (int i = 0; i < types.Length; i++)
        {
            string type = types[i];
            int max = maxCounts[i];

            int playerCount = playerArmy.Count(s => s.Type == type && s.IsAlive);
            int enemyCount = enemyArmy.Count(s => s.Type == type && s.IsAlive);

            string playerBar = GetBar(playerCount, max, 20);
            string enemyBar = GetBar(enemyCount, max, 20);

            string label = type.PadRight(10);
            Console.WriteLine(
                $"{label} | {playerBar} {playerCount.ToString().PadLeft(2)} || {enemyCount.ToString().PadRight(2)} {enemyBar} | {label}");
        }

        Console.WriteLine("\n(<- Войска игрока)       (Войска противника ->)");
    }
}
