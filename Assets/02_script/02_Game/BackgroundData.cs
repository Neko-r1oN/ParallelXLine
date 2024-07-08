using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BackgroundData", menuName = "ScriptableObjects/BackgroundData")]
public class BackgroundData : ScriptableObject
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
        public Sprite Sprite = null;

    }

    // -----------------------------------------------------------------------
    // 画像名から画像を取得する.
    // -----------------------------------------------------------------------
    public Sprite GetSprite(string imageName)
    {
        foreach (var param in Parameters)
        {
            if (param.Name == imageName) return param.Sprite;
        }
        return null;
    }
}