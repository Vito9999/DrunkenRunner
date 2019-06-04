using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SwipeType
{
    Left, Right, Down, Up, DownRight, DownLeft, UpRight, UpLeft
}

public class Swipe : MonoBehaviour
{

    
    public static GameObject CurrInstance;
    [SerializeField]
    private bool tap, swipeLeft, swipeRight, swipeUp,  swipeDown;
    private bool isDraging = true;
    private Vector2 startTouch, swipeDelta;

    private void Awake()
    {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;
    }
    private void Update()
    {

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            isDraging = true;
            tap = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            SwipeRecognition(CurrScene.GameScene);
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion


        //Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDraging == true)
        {
            if (Input.touches.Length > 0)
            { swipeDelta = Input.touches[0].position - startTouch; }
            else if (Input.GetMouseButton(0))
            { swipeDelta = (Vector2)Input.mousePosition - startTouch; }
        }


    }


    public void SwipeRecognition(CurrScene currScene)
    {
       switch(currScene)
        {
            case CurrScene.GameScene:
                if (Mathf.Abs(swipeDelta.normalized.x) > 0.9)
                {

                    if (Mathf.Sign(swipeDelta.x) > 0) SwipeControl(SwipeType.Right);
                    else SwipeControl(SwipeType.Left);

                }
                else if (Mathf.Abs(swipeDelta.normalized.y) > 0.9)
                {
                    if (Mathf.Sign(swipeDelta.y) > 0) SwipeControl(SwipeType.Up); // swipe up
                    else SwipeControl(SwipeType.Down); // swipe down
                }
                else
                {
                    // diagonal:
                    if (Mathf.Sign(swipeDelta.x) > 0)
                    {

                        if (Mathf.Sign(swipeDelta.y) > 0) SwipeControl(SwipeType.UpRight); // swipe diagonal up-right
                        else SwipeControl(SwipeType.DownRight); // swipe diagonal down-right

                    }
                    else
                    {

                        if (Mathf.Sign(swipeDelta.y) > 0) SwipeControl(SwipeType.UpLeft); // swipe diagonal up-left
                        else SwipeControl(SwipeType.DownLeft); // swipe diagonal down-left

                    }
                }
                Reset();
                break;
        }        
    }

    public void SwipeControl(SwipeType swipe)
    {
            switch(swipe)
            {
                case SwipeType.Down:
                    Debug.Log("Down");
                  if(GameMangaerScript.GameManger.GetComponent<GameMangaerScript>().currScene == CurrScene.GameScene)
                  {
                    MoveOnPlayField(SwipeType.Down);
                  }
                    break;
                case SwipeType.Up:
                if (GameMangaerScript.GameManger.GetComponent<GameMangaerScript>().currScene == CurrScene.GameScene)
                {
                    MoveOnPlayField(SwipeType.Up);
                }
                break;
                case SwipeType.Left:
                if (GameMangaerScript.GameManger.GetComponent<GameMangaerScript>().currScene == CurrScene.GameScene)
                {
                    MoveOnPlayField(SwipeType.Left);
                }
                break;
                case SwipeType.Right:
                if (GameMangaerScript.GameManger.GetComponent<GameMangaerScript>().currScene == CurrScene.GameScene)
                {
                    MoveOnPlayField(SwipeType.Right);
                }
                break;
                case SwipeType.DownLeft:
                if (GameMangaerScript.GameManger.GetComponent<GameMangaerScript>().currScene == CurrScene.GameScene)
                {
                    MoveOnPlayField(SwipeType.DownLeft);
                }
                break;
                case SwipeType.DownRight:
                if (GameMangaerScript.GameManger.GetComponent<GameMangaerScript>().currScene == CurrScene.GameScene)
                {
                    MoveOnPlayField(SwipeType.DownRight);
                }
                break;
                case SwipeType.UpLeft:
                if (GameMangaerScript.GameManger.GetComponent<GameMangaerScript>().currScene == CurrScene.GameScene)
                {
                    MoveOnPlayField(SwipeType.UpLeft);
                }
                break;
                case SwipeType.UpRight:
                if (GameMangaerScript.GameManger.GetComponent<GameMangaerScript>().currScene == CurrScene.GameScene)
                {
                    MoveOnPlayField(SwipeType.UpRight);
                }
                break;
            }
    }

    public void MoveOnPlayField(SwipeType swipe)
    {
        //Debug.Log(Player.Player_GO.transform);

        int x = Player.Player_GO.GetComponent<Player>().x;
        int y = Player.Player_GO.GetComponent<Player>().y;
        GameObject [,] PlayField = GameMangaerScript.GameManger.GetComponent<GameMangaerScript>().PlayfieldArray;
        int PlayFieldX = GameMangaerScript.GameManger.GetComponent<GameMangaerScript>().PlayFieldArrayX;
        int PlayFieldY = GameMangaerScript.GameManger.GetComponent<GameMangaerScript>().PlayFieldArrayY;
        
        switch (swipe)
        {
            case SwipeType.Down:
                if(y+1 < PlayFieldY)
                {
                    y++;
                    Player.Player_GO.GetComponent<Player>().y++;
                    Player.Player_GO.transform.SetParent(PlayField[y,x].transform);
                    Player.Player_GO.transform.position = Player.Player_GO.transform.parent.position;
                }
                break;
            case SwipeType.Up:
                if (y - 1 >= 0)
                {
                    y--;
                    Player.Player_GO.GetComponent<Player>().y--;
                    Player.Player_GO.transform.SetParent(PlayField[y, x].transform);
                    Player.Player_GO.transform.position = Player.Player_GO.transform.parent.position;
                }
                break;
            case SwipeType.Left:
                if (x - 1 >= 0)
                {
                    x--;
                    Player.Player_GO.GetComponent<Player>().x--;
                    Player.Player_GO.transform.SetParent(PlayField[y, x].transform);
                    Player.Player_GO.transform.position = Player.Player_GO.transform.parent.position;
                }
                break;
            case SwipeType.Right:
                if (x + 1 < PlayFieldX)
                {
                    x++;
                    Player.Player_GO.GetComponent<Player>().x++;
                    Player.Player_GO.transform.SetParent(PlayField[y, x].transform);
                    Player.Player_GO.transform.position = Player.Player_GO.transform.parent.position;
                }
                break;
            case SwipeType.DownLeft:
                if (y + 1 < PlayFieldY && x - 1 >= 0)
                {
                    y++; x--;
                    Player.Player_GO.GetComponent<Player>().y++;
                    Player.Player_GO.GetComponent<Player>().x--;
                    Player.Player_GO.transform.SetParent(PlayField[y, x].transform);
                    Player.Player_GO.transform.position = Player.Player_GO.transform.parent.position;
                }
                break;
            case SwipeType.DownRight:
                if (y + 1 < PlayFieldY && x + 1 < PlayFieldX)
                {
                    y++; x++;
                    Player.Player_GO.GetComponent<Player>().y++;
                    Player.Player_GO.GetComponent<Player>().x++;
                    Player.Player_GO.transform.SetParent(PlayField[y, x].transform);
                    Player.Player_GO.transform.position = Player.Player_GO.transform.parent.position;
                }
                break;
            case SwipeType.UpLeft:
                if (y - 1 >= 0 && x - 1 >= 0)
                {
                    y--; x--;
                    Player.Player_GO.GetComponent<Player>().y--;
                    Player.Player_GO.GetComponent<Player>().x--;
                    Player.Player_GO.transform.SetParent(PlayField[y, x].transform);
                    Player.Player_GO.transform.position = Player.Player_GO.transform.parent.position;
                }
                break;
            case SwipeType.UpRight:
                if (y - 1 >= 0 && x + 1 < PlayFieldX)
                {
                    y--; x++;
                    Player.Player_GO.GetComponent<Player>().y--;
                    Player.Player_GO.GetComponent<Player>().x++;
                    Player.Player_GO.transform.SetParent(PlayField[y, x].transform);
                    Player.Player_GO.transform.position = Player.Player_GO.transform.parent.position;
                }
                break;
        }

    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
    }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public Vector2 StartTouch { get { return startTouch; } }
    public bool SwipeLeft
    {
        get
        {
            return swipeLeft;
        }
    }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }



}
