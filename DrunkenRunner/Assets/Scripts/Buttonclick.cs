using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonclick : MonoBehaviour
{
    // Start is called before the first frame update
    public Image bild;
    public void scale()
    {
        bild.enabled = !bild.enabled;
    }
}
