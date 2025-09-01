public class AttackGeneral
{
    private readonly Data _data;
    public string GeneralName { get; set; }
    public int GeneralAttackBuff;

    public AttackGeneral(string generalName, int generalAttackBuff, Data data)
    {
        _data = data;
        GeneralName = generalName;
        generalName = _data.PlayerGeneralNameInput;
        GeneralAttackBuff = generalAttackBuff;
        generalAttackBuff = Data.GeneralAttackBuff;
    }

    public void AttackBuff()
    {
        if (_data.GeneralIsAttack == true)
        {
            _data.myArtillery.MaxAttack += GeneralAttackBuff;
            _data.myArtillery.MinAttack += GeneralAttackBuff;
            _data.myInfantry.MaxAttack += GeneralAttackBuff;
            _data.myInfantry.MinAttack += GeneralAttackBuff;
            _data.myCavalry.MaxAttack += GeneralAttackBuff;
            _data.myCavalry.MinAttack += GeneralAttackBuff;
            _data.myGuard.MaxAttack += GeneralAttackBuff;
            _data.myGuard.MinAttack += GeneralAttackBuff;
        }

        if (_data.GeneralIsSelectedByEnemy == true)
        {
            _data.enemyArtillery.MaxAttack += GeneralAttackBuff;
            _data.enemyArtillery.MinAttack += GeneralAttackBuff;
            _data.enemyInfantry.MaxAttack += GeneralAttackBuff;
            _data.enemyInfantry.MinAttack += GeneralAttackBuff;
            _data.enemyCavalry.MaxAttack += GeneralAttackBuff;
            _data.enemyCavalry.MinAttack += GeneralAttackBuff;
            _data.enemyGuard.MaxAttack += GeneralAttackBuff;
            _data.enemyGuard.MinAttack += GeneralAttackBuff;
        }
    }
}
