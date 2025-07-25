using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EmotionFxData;

[CreateAssetMenu(fileName = "EmotionFxData", menuName = "ScriptableObjects/EmotionFxData")]
public class EmotionFxData : ScriptableObject
{
    // ------------------------------------------------------
    // �����`.
    // ------------------------------------------------------
    public enum Type
    {
        None = 0,
        Kirakira = 1,
        Bikkuri = 2,
        Pikon = 3,
        Hatena = 4,
        Tententen = 5,
        Aseri = 6,
        Hirameki = 7
    }

    // ------------------------------------------------------
    // �摜�ƕ\��̊֘A�t���p�����[�^.
    // ------------------------------------------------------
    [System.Serializable]
    public class ImageParam
    {
        // �摜.
        public Sprite Sprite = null;

    }

    // ------------------------------------------------------
    // �L�����̃p�����[�^.
    // ------------------------------------------------------
    [System.Serializable]
    public class Parameter
    {
        // ���.
        public string DisplayName = "";
        // ����^�C�v.
        public Type EmotionFx = Type.None;
        // �摜�p�����[�^�[�̃��X�g.
        public List<ImageParam> ImageParams = new List<ImageParam>();

        // -----------------------------------------------------------------------
        // �\��^�C�v����摜���擾����.
        // -----------------------------------------------------------------------
        /*public Sprite GetEmotionFxSprite(EmotionFxType emotion)
        {
            foreach (var img in ImageParams)
            {
                if (img.Emotion == emotion) return img.Sprite;
            }
            return null;
        }*/
    }

    // ����.
    [SerializeField] string Memo = "";
    // �p�����[�^���X�g.
    public List<Parameter> Parameters = new List<Parameter>();


    // -----------------------------------------------------------------------
    // �L�����ԍ�����\�������擾.
    // -----------------------------------------------------------------------
    public string GetCharacterName(string characterNumber)
    {
        // �u1�v�u2�v�u3�v�̏ꍇ.
        if (characterNumber == "1" || characterNumber == "2" || characterNumber == "3")
        {
            var param = GetParameterFromNumber(characterNumber);
            return param.DisplayName;
        }

        // �u0�v�₻�̑��̏ꍇ�͉����Ȃ��ŕԂ�.
        return "";
    }

    // -----------------------------------------------------------------------
    // �L�����ԍ�����p�����[�^���擾.
    // -----------------------------------------------------------------------
    Parameter GetParameterFromNumber(string characterNumber)
    {
        foreach (var param in Parameters)
        {
            var typeInt = (int)param.EmotionFx;
            var typeStr = typeInt.ToString();

            if (typeStr == characterNumber) return param;
        }
        return null;
    }

    // -----------------------------------------------------------------------
    // ������̃f�[�^����L�����摜���擾����.
    // -----------------------------------------------------------------------
    
    /*public Sprite GetCharacterSprite(string dataString)
    {
        // �擪�̈ꕶ�������o��.
        var num = dataString.Substring(0, 1);
        // �擪�̈ꕶ���ȊO.
        var emo = dataString.Substring(1);

        if (num != "0" && num != "1" && num != "2" && num != "3")
        {
            Debug.Log("���̓f�[�^������������܂���B" + dataString);
            return null;
        }

        var param = GetParameterFromNumber(num);
        var emotion = GetEmotionFxType(emo);
        var sprite = param.GetEmotionFxSprite(emotion);

        return sprite;
    }*/

    // -----------------------------------------------------------------------
    // �\����̕����񂩂�EmotationType���擾����B
    // -----------------------------------------------------------------------
    /*EmotionFxType GetEmotionFxType(string emotionString)
    {
        switch (emotionString)
        {
            case "Egao": return EmotionFxType.Egao;
            case "Nakigao": return EmotionFxType.Nakigao;
            case "Ikarigao": return EmotionFxType.Ikarigao;
            default: return EmotionFxType.None;
        }
    }*/

}