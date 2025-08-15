namespace WAR_Task13_OOP;

public abstract class Soldier
{
    public int HealthPoint;
    public int Defense;
    public int MaxAttack;
    public int MinAttack;
    public bool IsAlive = true;

    public string Type { get; } // для визора (опционально)

    protected Soldier(int healthPoint, int defense, int maxAttack, int minAttack, string type)
    {
        HealthPoint = healthPoint;
        Defense     = defense;
        MaxAttack   = maxAttack;
        MinAttack   = minAttack;
        Type        = type;
    }

    public abstract Soldier Clone();
    
    public override string ToString()
    {
        return $"{Type}: HP={HealthPoint}, DEF={Defense}, ATK={MinAttack}-{MaxAttack}";
    }
}
