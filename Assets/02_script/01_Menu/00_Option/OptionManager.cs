using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [SerializeField] Text windowSizeText;     //ウィンドウサイズテキスト
    [SerializeField] Text windowModeText;     //ウィンドウモードテキスト


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickChangeScreenMode()
    {
        if (Screen.fullScreen)
        {
            // ウィンドウモードに切り替え
            Screen.fullScreen = false;
            windowModeText.text = "フルスクリーンモード";
        }
        else
        {
            // フルスクリーンモードに切り替え
            Screen.fullScreen = false;
            windowModeText.text = "ウィンドウモード";
        }
    }
}
