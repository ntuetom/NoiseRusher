using UnityEngine;
using System.Collections;

public class ReadAssetBundles : MonoBehaviour {

    public static readonly string PathURL = 
#if UNITY_ANDROID
        "jar:file://" + Application.dataPath + "!/assets/";
#elif UNITY_IPHONE
        Application.dataPath + "/Raw/";
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
        "file://" + Application.dataPath + "/StreamingAssets/";
#else
        string.Empty;
#endif

    void OnGUI()
    {
        if (GUILayout.Button("Main Assetbundle"))
        {
            StartCoroutine(LoadMainGameObject(PathURL + "missile.assetbundle"));
            StartCoroutine(LoadMainGameObject(PathURL + "Arduino.assetbundle"));
        }

        if (GUILayout.Button("ALL Assetbundle"))
        {
            StartCoroutine(LoadALLGameObject(PathURL + "ALL.assetbundle"));
        }

    }

    private IEnumerator LoadMainGameObject(string path) {
        WWW bundle = WWW.LoadFromCacheOrDownload(path,5);

        yield return bundle;
        yield return Instantiate(bundle.assetBundle.mainAsset);
        
        bundle.assetBundle.Unload(false);

    }

    private IEnumerator LoadALLGameObject(string path) {
        WWW bundle = WWW.LoadFromCacheOrDownload(path,5);

        yield return bundle;

        Object obj0 = bundle.assetBundle.Load("Arduino");
        Object obj1 = bundle.assetBundle.Load("missile");

        yield return Instantiate(obj0);
        yield return Instantiate(obj1);
        bundle.assetBundle.Unload(false);
    }
}
