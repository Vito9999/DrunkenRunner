using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{


    public GameObject test;
    public GameObject Player;

    public GameObject[,] PlayfieldArray = new GameObject[6,3];

    public GameObject PlayField_GO;
    public void fillPlayfield()
    {
        int i = 0;
        for(int y = 0; y < 6; y++)
        {
            for(int x = 0; x < 3; x++)
            {
                PlayfieldArray[y,x] = PlayField_GO.transform.GetChild(i).gameObject;
                i++;
            }
        }
    }

    

    public void Update()
    {

        if(test.GetComponent<Swipe>().SwipeLeft == true)
        {
            Player.transform.SetParent(PlayfieldArray[5, 2].transform);
            Player.transform.position = Player.transform.parent.position;
            Debug.Log("Funkt");
        }

    }
    private void Awake()
    {
        test = GameObject.Find("ScriptHolder");
        fillPlayfield();
    }
}
