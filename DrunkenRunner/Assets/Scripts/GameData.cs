using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData CurrInstance;

    public int CharakterScaleStandard;
    public ScriptableObject SelectedCharakter;
    public ScriptableObject[] AllCharakters;

    private void Awake()
    {
        
        CharakterScaleStandard = 10;
      
    }

}
