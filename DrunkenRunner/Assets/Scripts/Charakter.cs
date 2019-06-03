using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charakter : Actor
{
    private int _lvl { get; set; }//not in Scriptable Object
    private int _exp { get; set; }//not in Scriptable Object
    private int _liverBase { get; set; }
    private int _heartBase { get; set; }
    private int _bowelBase { get; set; }
    private int _lungBase { get; set; }
    private int _liverScale { get; set; }
    private int _heartScale { get; set; }
    private int _bowelScale { get; set; }
    private int _lungScale { get; set; }


    public int LVL { get { return _lvl; } }//not in Scriptable Object
    public int LiverBase { get { return _liverBase; } }
    public int HeartBase { get { return _heartBase; } }
    public int BowelBase { get { return _bowelBase; } }
    public int LungBase { get { return _lungBase; } }
    public int Exp { get { return _exp; } }//not in Scriptable Object
    public int LiverScale { get { return GameData.CurrInstance.CharakterScaleStandard * _liverScale; } }
    public int HeartScale { get { return GameData.CurrInstance.CharakterScaleStandard * _heartScale; } }
    public int BowelScale { get { return GameData.CurrInstance.CharakterScaleStandard * _bowelScale; } }
    public int LungScale { get { return GameData.CurrInstance.CharakterScaleStandard * _lungScale; } }

    public int CharakerUpgradeCost(int lvl)
    {
        return 0;
    }

    public override void INIT()
    {
        base.INIT();
        Charakter_SO charakter_SO = (Charakter_SO)Actor_SO;
        _liverBase = charakter_SO.LiverBase;
        _heartBase = charakter_SO.HeartBase;
        _bowelBase = charakter_SO.BowelBase;
        _lungBase = charakter_SO.LungBase;
        
    }



}
