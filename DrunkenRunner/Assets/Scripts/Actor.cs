using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Actor : MonoBehaviour
{
    public Actor_SO Actor_SO;
    private string _name { get; set; }
    private int _life { get; set; }
    private string _lore { get; set; }


    public int Life { get { return _life; } }
    public string Name { get { return _name; } }
    public string Lore { get { return _lore; } }
   


    public virtual void INIT()
    {
        _name = Actor_SO.Name;
        _life = Actor_SO.Life;
        _lore = Actor_SO.Lore;
    }

    private void Awake()
    {
        INIT();
    }

}




