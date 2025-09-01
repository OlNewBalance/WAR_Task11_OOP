namespace WAR_Task13_OOP;

public class DeffGeneral
{
    public string GeneralName { get; set; }
    public int GeneralDefenseBuff;
    private readonly Data _data;

    public DeffGeneral(string generalName, int generalDefenseBuff, Data data)
    {
        _data = data;
        GeneralName = generalName;
        generalName = _data.PlayerGeneralNameInput;
        GeneralDefenseBuff = generalDefenseBuff;
        generalDefenseBuff = Data.GeneralDefenseBuff;
    }

    public void DeffenseBuff()
    {
        if (_data.GeneralIsDeff == true)
        {
            _data.myArtillery.Defense += GeneralDefenseBuff;
            _data.myArtillery.Defense += GeneralDefenseBuff;
            _data.myInfantry.Defense += GeneralDefenseBuff;
            _data.myInfantry.Defense += GeneralDefenseBuff;
            _data.myCavalry.Defense += GeneralDefenseBuff;
            _data.myCavalry.Defense += GeneralDefenseBuff;
            _data.myGuard.Defense += GeneralDefenseBuff;
            _data.myGuard.Defense += GeneralDefenseBuff;
        }

        if (_data.GeneralIsSelectedByEnemy == true)
        {
            _data.enemyArtillery.Defense += GeneralDefenseBuff;
            _data.enemyArtillery.Defense += GeneralDefenseBuff;
            _data.enemyInfantry.Defense += GeneralDefenseBuff;
            _data.enemyInfantry.Defense += GeneralDefenseBuff;
            _data.enemyCavalry.Defense += GeneralDefenseBuff;
            _data.enemyCavalry.Defense += GeneralDefenseBuff;
            _data.enemyGuard.Defense += GeneralDefenseBuff;
            _data.enemyGuard.Defense += GeneralDefenseBuff;
        }
    }
}
