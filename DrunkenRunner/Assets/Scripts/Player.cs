using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static GameObject Player_GO;
    public int x, y;
    private void Awake()
    {
        Player_GO = gameObject;
        x =2; y = 3;
    }
}
