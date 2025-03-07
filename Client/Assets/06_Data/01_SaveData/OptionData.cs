////////////////////////////////////////////////////////////////////////////
///
///  ユーザーセーブデータスクリプト
///  Author : 川口京佑  2025.01/28
///
////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionData
{
    public int windowSize { get; set; }       //ウィンドウサイズ
    public int screenMode { get; set; }       //スクリーンモード
    public int textSize { get; set; }         //テキストサイズ
    public int textSpeed { get; set; }        //文字送りスピード
    public float BGMVolume { get; set; }      //BGMボリューム
    public float SEVolume { get; set; }       //SEボリューム
}