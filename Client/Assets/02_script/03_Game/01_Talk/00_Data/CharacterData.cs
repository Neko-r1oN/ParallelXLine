using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterData;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData")]
public class CharacterData : ScriptableObject
{
    // ------------------------------------------------------
    // キャラクター定義.
    // ------------------------------------------------------
    public enum Type
    {
        None = 0,
        Kitakuchan = 1,
        Orekun = 2,
        Sensei = 3
    }

    // ------------------------------------------------------
    // 画像のための表情定義.
    // ------------------------------------------------------
    public enum EmotionType
    {
        None,
        Egao,
        Nakigao,
        Ikarigao,
    }

    // ------------------------------------------------------
    // 画像と表情の関連付けパラメータ.
    // ------------------------------------------------------
    [System.Serializable]
    public class ImageParam
    {
        // 表情タイプ.
        public EmotionType Emotion = EmotionType.None;
        // 画像.
        public Sprite Sprite = null;
    }

    // ------------------------------------------------------
    // キャラのパラメータ.
    // ------------------------------------------------------
    [System.Serializable]
    public class Parameter
    {
        // 名前.
        public string DisplayName = "";
        // キャラタイプ.
        public Type Character = Type.None;
        // 画像パラメーターのリスト.
        public List<ImageParam> ImageParams = new List<ImageParam>();

        // -----------------------------------------------------------------------
        // 表情タイプから画像を取得する.
        // -----------------------------------------------------------------------
        public Sprite GetEmotionSprite(EmotionType emotion)
        {
            foreach (var img in ImageParams)
            {
                if (img.Emotion == emotion) return img.Sprite;
            }
            return null;
        }
    }

    // メモ.
    [SerializeField] string Memo = "";
    // パラメータリスト.
    public List<Parameter> Parameters = new List<Parameter>();


    // -----------------------------------------------------------------------
    // キャラ番号から表示名を取得.
    // -----------------------------------------------------------------------
    public string GetCharacterName(string characterNumber)
    {
        // 「1」「2」「3」の場合.
        if (characterNumber == "1" || characterNumber == "2" || characterNumber == "3")
        {
            var param = GetParameterFromNumber(characterNumber);
            return param.DisplayName;
        }

        // 「0」やその他の場合は何もなしで返す.
        return "";
    }

    // -----------------------------------------------------------------------
    // キャラ番号からパラメータを取得.
    // -----------------------------------------------------------------------
    Parameter GetParameterFromNumber(string characterNumber)
    {
        foreach (var param in Parameters)
        {
            var typeInt = (int)param.Character;
            var typeStr = typeInt.ToString();

            if (typeStr == characterNumber) return param;
        }
        return null;
    }

    // -----------------------------------------------------------------------
    // 文字列のデータからキャラ画像を取得する.
    // -----------------------------------------------------------------------
    public Sprite GetCharacterSprite(string dataString)
    {
        // 先頭の一文字抜き出し.
        var num = dataString.Substring(0, 1);
        // 先頭の一文字以外.
        var emo = dataString.Substring(1);

        if (num != "0" && num != "1" && num != "2" && num != "3")
        {
            Debug.Log("入力データが正しくありません。" + dataString);
            return null;
        }

        var param = GetParameterFromNumber(num);
        var emotion = GetEmotionType(emo);
        var sprite = param.GetEmotionSprite(emotion);

        return sprite;
    }

    // -----------------------------------------------------------------------
    // 表情部分の文字列からEmotationTypeを取得する。
    // -----------------------------------------------------------------------
    EmotionType GetEmotionType(string emotionString)
    {
        switch (emotionString)
        {
            case "Egao": return EmotionType.Egao;
            case "Nakigao": return EmotionType.Nakigao;
            case "Ikarigao": return EmotionType.Ikarigao;
            default: return EmotionType.None;
        }
    }

}