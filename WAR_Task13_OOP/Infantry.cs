namespace WAR_Task13_OOP;

public class Infantry : Soldier
{
    public Infantry()
        : base(healthPoint: 100, defense: 20, maxAttack: 25, minAttack: 15, type: "Infantry") { }

    public Infantry(int hp, int def, int maxAtk, int minAtk)
        : base(hp, def, maxAtk, minAtk, "Infantry") { }

    public override Soldier Clone() => new Infantry(HealthPoint, Defense, MaxAttack, MinAttack);
}
