using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BGMData", menuName = "ScriptableObjects/BGMData")]
public class BGMData : ScriptableObject
{
    // メモ.
    [SerializeField] string Memo = "";
    // パラメータリスト.
    public List<Parameter> Parameters = new List<Parameter>();


    // ------------------------------------------------------
    // 背景のパラメータ.
    // ------------------------------------------------------
    [System.Serializable]
    public class Parameter
    {
        // 名前.
        public string Name = "";
        // 画像パラメーターのリスト.
        public AudioClip BGM = null;

    }

    // -----------------------------------------------------------------------
    // 画像名から画像を取得する.
    // -----------------------------------------------------------------------
    public AudioClip GetMusic(string bgmName)
    {
        foreach (var param in Parameters)
        {
            if (param.Name == bgmName) return param.BGM;
        }
        return null;
    }
    
}