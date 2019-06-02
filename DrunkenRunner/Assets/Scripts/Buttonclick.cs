using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonclick : MonoBehaviour
{
    public Image bild;
    public void scale()
    {
        bild.enabled = !bild.enabled;
    }
}
