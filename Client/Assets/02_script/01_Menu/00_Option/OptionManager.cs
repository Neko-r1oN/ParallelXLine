using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [SerializeField] Text windowSizeText;     //ウィンドウサイズテキスト
    [SerializeField] Text screenModeText;     //スクリーンモードテキスト

    public int windowSize { get; set; }         //ウィンドウサイズ

    void Start()
    {
        /*if(Screen.fullScreen) windowModeText.text = "ウィンドウモード";
        else windowSizeText.text = "フルスクリーンモード";*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 解像度変更関数
    /// </summary>
    public void OnClickChangeWindowSize()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen);

    }

    /// <summary>
    /// ウィンドウモード切替関数
    /// </summary>
    public void OnClickChangeScreenMode()
    {
        if (Screen.fullScreen)
        {
            // ウィンドウモードに切り替え
            Screen.fullScreen = false;
            screenModeText.text = "フルスクリーンモード";
        }
        else
        {
            // フルスクリーンモードに切り替え
            Screen.fullScreen = false;
            screenModeText.text = "ウィンドウモード";
        }
    }

    //
    public void SetResolution()
    {
        /*if()
        Screen.SetResolution(width, height, Screen.fullScreen);*/
    }

    public void SetResolution1080p()
    {
        //SetResolution(1920, 1080);
    }

    public void SetResolution720p()
    {
        //SetResolution(1280, 720);
    }
}
