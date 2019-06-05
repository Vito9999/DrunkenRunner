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

    public int PlayFieldArrayX;
    public int PlayFieldArrayY;
    public GameObject[,] PlayfieldArray;
    public GameObject PlayField_GO;
    public void fillPlayfield()
    {
        int i = 0;
        for (int y = 0; y < PlayFieldArrayY; y++)
        {
            for (int x = 0; x < PlayFieldArrayX; x++)
            {
                PlayfieldArray[y, x] = PlayField_GO.transform.GetChild(i).gameObject;
                i++;
            }
        }
    }

    private void Awake()
    {
        PlayFieldArrayX = 5; PlayFieldArrayY = 7;
        PlayfieldArray = new GameObject[PlayFieldArrayY, PlayFieldArrayX];
        currScene = CurrScene.GameScene;
        GameManger = gameObject;
        fillPlayfield();
    }
}
