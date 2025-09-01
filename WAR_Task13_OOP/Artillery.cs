namespace WAR_Task13_OOP;

public class Artillery : Soldier
{
    public Artillery()
        : base(healthPoint: 100, defense: 0, maxAttack: 80, minAttack: 65, type: "Artillery") { }

    public Artillery(int hp, int def, int maxAtk, int minAtk)
        : base(hp, def, maxAtk, minAtk, "Artillery") { }

    public override Soldier Clone() => new Artillery(HealthPoint, Defense, MaxAttack, MinAttack);
}

