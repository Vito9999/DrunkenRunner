using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMangaerScript : MonoBehaviour
{
    public static GameMangaerScript CurrInstance;
    public static GameObject ThisGO;
    public GameObject Player;

    public GameObject[,] PlayfieldArray = new GameObject[6, 3];

    public GameObject PlayField_GO;
    public void fillPlayfield()
    {
        int i = 0;
        for (int y = 0; y < 6; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                PlayfieldArray[y, x] = PlayField_GO.transform.GetChild(i).gameObject;
                i++;
            }
        }
    }


    private void Awake()
    { 
        ThisGO = gameObject;
        fillPlayfield();
    }
}
