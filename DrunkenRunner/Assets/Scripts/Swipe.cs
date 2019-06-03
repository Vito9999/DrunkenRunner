using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Swipe : MonoBehaviour
{
    public enum SwipeType
    {
        Left,Right,Down,Up,DownRight,DownLeft,UpRight,UpLeft
    }
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
            if (Mathf.Abs(swipeDelta.normalized.x) > 0.9)
            {

                if (Mathf.Sign(swipeDelta.x) > 0) MCMovement(SwipeType.Right);
                else MCMovement(SwipeType.Left);

            }
            else if (Mathf.Abs(swipeDelta.normalized.y) > 0.9)
            {
                if (Mathf.Sign(swipeDelta.y) > 0) MCMovement(SwipeType.Up); // swipe up
                else MCMovement(SwipeType.Down); // swipe down
            }
            else
            {
                // diagonal:
                if (Mathf.Sign(swipeDelta.x) > 0)
                {

                    if (Mathf.Sign(swipeDelta.y) > 0) MCMovement(SwipeType.UpRight); // swipe diagonal up-right
                    else MCMovement(SwipeType.DownRight); // swipe diagonal down-right

                }
                else
                {

                    if (Mathf.Sign(swipeDelta.y) > 0) MCMovement(SwipeType.UpLeft); // swipe diagonal up-left
                    else MCMovement(SwipeType.DownLeft); // swipe diagonal down-left

                }
            }

            Reset();
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
    public void MCMovement(SwipeType swipe)
    {
        if(SceneManager.GetActiveScene().name == "Gamescene")
        {
            switch(swipe)
            {
                case SwipeType.Down:
                    Debug.Log("Down");
                  
                    break;
                case SwipeType.Up:
                    Debug.Log("Up");
                    break;
                case SwipeType.Left:
                    Debug.Log("Left");
                    break;
                case SwipeType.Right:
                    Debug.Log("Right");
                    break;
                case SwipeType.DownLeft:
                    Debug.Log("DownLeft");
                    break;
                case SwipeType.DownRight:
                    Debug.Log("DownRight");
                    break;
                case SwipeType.UpLeft:
                    Debug.Log("UpLeft");
                    break;
                case SwipeType.UpRight:
                    Debug.Log("UpRight");
                    break;
            }
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
