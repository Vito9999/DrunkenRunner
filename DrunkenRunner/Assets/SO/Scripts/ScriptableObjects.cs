using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "new Actor", menuName = "new Actor")]
public class Actor_SO : ScriptableObject
{
    
    public string Name;
    public int Life;
    public string Lore;
}

[CreateAssetMenu(fileName = "new Actor", menuName = "new Charakter")]
public class Charakter_SO : Actor_SO
{
    
    public int LVL;
    public int LiverBase;
    public int HeartBase;
    public int BowelBase;
    public int LungBase;
    public int LiverScale;
    public int HeartScale;
    public int BowelScale;
    public int LungScale;
}



