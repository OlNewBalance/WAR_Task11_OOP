namespace WAR_Task13_OOP;

public class Cavalry : Soldier
{
    public Cavalry()
        : base(healthPoint: 100, defense: 30, maxAttack: 40, minAttack: 25, type: "Cavalry") { }

    public Cavalry(int hp, int def, int maxAtk, int minAtk)
        : base(hp, def, maxAtk, minAtk, "Cavalry") { }

    public override Soldier Clone() => new Cavalry(HealthPoint, Defense, MaxAttack, MinAttack);
}
