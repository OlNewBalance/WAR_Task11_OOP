namespace WAR_Task13_OOP;

public class Soldier
{
        public int HP;
        public int Defense;
        public int MinAttack;
        public int MaxAttack;

        public Soldier(int healthPoint, int defense, int minAttack,int maxAttack)
        {
                HP = healthPoint;
                Defense = defense;
                MinAttack = minAttack;
                MaxAttack = maxAttack;
        }
}