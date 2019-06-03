using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData CurrInstance;

    public int CharakterScaleStandard;

    private void Awake()
    {
        CharakterScaleStandard = 10;
        bool test = Resources.Load<ScriptableObject>("new Actor");
            Debug.Log(test);
    }

}
