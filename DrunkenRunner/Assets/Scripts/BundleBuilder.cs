using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class BundleBuilder : MonoBehaviour
{
    static string AssetSavesPath = Application.persistentDataPath + @"\AssetBundles";

   [MenuItem("Assets/ Build AssetBundles")]
   static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles(AssetSavesPath, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);
    }
}
