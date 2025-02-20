using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterData;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData")]
public class CharacterData : ScriptableObject
{
    // ------------------------------------------------------
    // �L�����N�^�[��`.
    // ------------------------------------------------------
    public enum Type
    {
        None = 0,
        Kitakuchan = 1,
        Orekun = 2,
        Sensei = 3
    }

    // ------------------------------------------------------
    // �摜�̂��߂̕\���`.
    // ------------------------------------------------------
    public enum EmotionType
    {
        None,
        Egao,
        Nakigao,
        Ikarigao,
    }

    // ------------------------------------------------------
    // �摜�ƕ\��̊֘A�t���p�����[�^.
    // ------------------------------------------------------
    [System.Serializable]
    public class ImageParam
    {
        // �\��^�C�v.
        public EmotionType Emotion = EmotionType.None;
        // �摜.
        public Sprite Sprite = null;
    }

    // ------------------------------------------------------
    // �L�����̃p�����[�^.
    // ------------------------------------------------------
    [System.Serializable]
    public class Parameter
    {
        // ���O.
        public string DisplayName = "";
        // �L�����^�C�v.
        public Type Character = Type.None;
        // �摜�p�����[�^�[�̃��X�g.
        public List<ImageParam> ImageParams = new List<ImageParam>();

        // -----------------------------------------------------------------------
        // �\��^�C�v����摜���擾����.
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
            var typeInt = (int)param.Character;
            var typeStr = typeInt.ToString();

            if (typeStr == characterNumber) return param;
        }
        return null;
    }

    // -----------------------------------------------------------------------
    // ������̃f�[�^����L�����摜���擾����.
    // -----------------------------------------------------------------------
    public Sprite GetCharacterSprite(string dataString)
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
        var emotion = GetEmotionType(emo);
        var sprite = param.GetEmotionSprite(emotion);

        return sprite;
    }

    // -----------------------------------------------------------------------
    // �\����̕����񂩂�EmotationType���擾����B
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