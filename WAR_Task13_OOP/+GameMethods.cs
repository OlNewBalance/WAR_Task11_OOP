namespace WAR_Task13_OOP;

public static class GameMethods
{
    private static readonly Random random = new Random();
    
    public static void MedicalUnitRemoval(List<Soldier> healingArmy)
    {
        if (Data.playerArmy.Count != 0 || Data.enemyArmy.Count != 0)
        {
            foreach (Soldier wounded in healingArmy)
            {
                if (wounded.HP <= 0) continue;
                
                var aliveWounders = healingArmy.Where(d => d.HP > 0).ToList();
        
                if (aliveWounders.Count == 0)
                {
                    Console.WriteLine("Все защитники мертвы!");
                    return;
                }

                int MedicalSupport = 15;
                Soldier wounder = aliveWounders[random.Next(aliveWounders.Count)];
                wounder.HP += MedicalSupport;
                Console.WriteLine($"Здоровье солдата повышается на 15 единиц!");
            }
        }
    }

    public static void Attacking(List<Soldier> attackingArmy, List<Soldier> defendingArmy)
    {
        if (Data.playerArmy.Count != 0 || Data.enemyArmy.Count != 0)
        {
            foreach (Soldier attacker in attackingArmy)
            {
                if (attacker.HP <= 0) continue; // Пропускаем мёртвых

                // Получаем список живых защитников
                var aliveDefenders = defendingArmy.Where(d => d.HP > 0).ToList();
        
                if (aliveDefenders.Count == 0)
                {
                    Console.WriteLine("Все защитники мертвы!");
                    return;
                }

                // Выбираем случайного защитника
                Soldier defender = aliveDefenders[random.Next(aliveDefenders.Count)];
                int attackDamage = random.Next(attacker.MinAttack, attacker.MaxAttack + 1);
                int calculatedDamage = Math.Max(1, attackDamage - defender.Defense / 2);
                // Наносим урон
                defender.HP -= calculatedDamage;
                Console.WriteLine($"{attacker.GetType().Name} атакует {defender.GetType().Name}!" +
                                  $" Урон: {calculatedDamage}, HP защитника: {defender.HP}");
            }
        }
        
    }
    public static void SuperAttacking(List<Soldier> attackingArmy, List<Soldier> defendingArmy)
    {
        if (Data.playerArmy.Count != 0 || Data.enemyArmy.Count != 0)
        {
            foreach (Soldier attacker in attackingArmy)
            {
                if (attacker.HP <= 0) continue;
                
                var aliveDefenders = defendingArmy.Where(d => d.HP > 0).ToList();
        
                if (aliveDefenders.Count == 0)
                {
                    Console.WriteLine("Все защитники мертвы!");
                    return;
                }
                
                Soldier defender = aliveDefenders[random.Next(aliveDefenders.Count)];
                int attackDamage = random.Next(attacker.MinAttack, attacker.MaxAttack + 1);
                int calculatedDamage = Math.Max(1, attackDamage - defender.Defense / 2);
                int UltimateDamageBaff = 15;
                defender.HP -= (calculatedDamage + UltimateDamageBaff);
                Console.WriteLine($"{attacker.GetType().Name} атакует {defender.GetType().Name}!" +
                                  $" Урон: {calculatedDamage} с бафом в {UltimateDamageBaff} едениц" +
                                  $", HP защитника: {defender.HP}");
            }
        }
    }

    public static void Defending(List<Soldier> defendingArmy)
    {
        if (Data.playerArmy.Count != 0 || Data.enemyArmy.Count != 0)
        {
            foreach (Soldier attacker in defendingArmy)
            {
                if (attacker.HP <= 0) continue;
                
                var aliveDefenders = defendingArmy.Where(d => d.HP > 0).ToList();
        
                if (aliveDefenders.Count == 0)
                {
                    Console.WriteLine("Все защитники мертвы!");
                    return;
                }
                
                Soldier defender = aliveDefenders[random.Next(aliveDefenders.Count)];
                int DefenseBaff = 15;
                defender.Defense += DefenseBaff;
                Console.WriteLine($"Увеличение уровня защиты на {DefenseBaff} единиц. Защита - {defender.Defense}.");
            }
        }
    }
    public static void DefendingDebaff(List<Soldier> defendingArmy)
    {
        if (Data.playerArmy.Count != 0 || Data.enemyArmy.Count != 0)
        {
            foreach (Soldier attacker in defendingArmy)
            {
                if (attacker.HP <= 0) continue;
                
                var aliveDefenders = defendingArmy.Where(d => d.HP > 0).ToList();
        
                if (aliveDefenders.Count == 0)
                {
                    Console.WriteLine("Все защитники мертвы!");
                    return;
                }
                
                Soldier defender = aliveDefenders[random.Next(aliveDefenders.Count)];
                int DefenseDebaff = 15;
                defender.Defense -= DefenseDebaff;
                Console.WriteLine($"Снижение уровня защиты на {DefenseDebaff} единиц. Защита - {defender.Defense}.");
            }
        }
    }
}