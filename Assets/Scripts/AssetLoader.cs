using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using USFB;

public class AssetLoader : MonoBehaviour
{
    public Button LoadAsset;
    public VideoHelper videoHelper;

    void Start()
    {
        LoadAsset.onClick.AddListener(LoadAssetAction);
    }

    void LoadAssetAction(){
        var extensions = new [] {
                new ExtensionFilter("supported video", "webm", "mp4"),
                new ExtensionFilter("3d model", "fbx"),
            };
        var result = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, false);
        if(result.Length > 0){
            Debug.Log($"Read File:{result[0]}");

            System.IO.FileInfo fi = new System.IO.FileInfo(result[0]);  
            
            Debug.Log("File Type " + fi.Extension);

            if(fi.Extension == ".webm" || fi.Extension == ".mp4"){
                videoHelper.SetupVideo(result[0]);
            }

            if(fi.Extension == ".fbx"){
                videoHelper.CloseVideo();
            }
        }
    }
}
