namespace WAR_Task13_OOP;


public class Guard : Soldier
{
    public Guard()
        : base(healthPoint: 100, defense: 50, maxAttack: 40, minAttack: 30, type: "Guard") { }

    public Guard(int hp, int def, int maxAtk, int minAtk)
        : base(hp, def, maxAtk, minAtk, "Guard") { }

    public override Soldier Clone() => new Guard(HealthPoint, Defense, MaxAttack, MinAttack);
}
