using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CurrScene
{
    GameScene, NonGame
}

public class GameMangaerScript : MonoBehaviour
{
    public static GameObject GameManger;
    public GameObject Player;
    public CurrScene currScene;

    public int PlayFieldArrayX = 3;
    public int PlayFieldArrayY = 6;
    public GameObject[,] PlayfieldArray;
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
        PlayfieldArray = new GameObject[PlayFieldArrayY, PlayFieldArrayX];
        currScene = CurrScene.GameScene;
        GameManger = gameObject;
        fillPlayfield();
    }
}
