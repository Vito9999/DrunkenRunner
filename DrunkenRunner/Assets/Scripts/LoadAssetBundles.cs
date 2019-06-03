using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetBundles : MonoBehaviour
{
    AssetBundle AssetBundle;
    public void LoadAssetBundle(string path)
    {
        AssetBundle = AssetBundle.LoadFromFile(path);
    }
}
