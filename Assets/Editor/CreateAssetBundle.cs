using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateAssetBundle : EditorWindow {

	
    [MenuItem("Custom Editor/Create AssetBundles Main")]
    static void CreateAssetBundlesMain() {
        Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

        foreach (Object obj in SelectedAsset)
        {
            string sourcePath = AssetDatabase.GetAssetPath(obj);
            string targetPath = Application.dataPath + "/StreamingAssets/" + obj.name + ".assetbundle";
            if (BuildPipeline.BuildAssetBundle(obj, null, targetPath, BuildAssetBundleOptions.CollectDependencies))
            {
                Debug.Log(obj.name + "資源打包成功");
            }
            else {
                Debug.Log(obj.name + "資源打包失敗");
            }
        }

        AssetDatabase.Refresh();
    }

    [MenuItem("Custom Editor/Create AssetBundles All")]
    static void CreateAssetBundlesAll() {
        Caching.CleanCache();

        string Path = Application.dataPath + "/StreamingAssets/ALL.assetbundle";
        Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

        foreach (Object obj in SelectedAsset) 
        {
            Debug.Log("Create AssetBundles name :" + obj);
        }
        if(BuildPipeline.BuildAssetBundle(null,SelectedAsset,Path,BuildAssetBundleOptions.CollectDependencies))
        {
            AssetDatabase.Refresh();
        }
        else{
          
        }
    }

    [MenuItem("Custom Editor/Create Scene")]
    static void CreatedSceneALL() {
        Caching.CleanCache();
        string Path = Application.dataPath + "/MyScene.unity3d";
        string[] levels = {"Assets/Level.unity"};
    }
}
