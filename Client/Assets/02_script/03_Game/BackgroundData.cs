using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BackgroundData", menuName = "ScriptableObjects/BackgroundData")]
public class BackgroundData : ScriptableObject
{
    // ����.
    [SerializeField] string Memo = "";
    // �p�����[�^���X�g.
    public List<Parameter> Parameters = new List<Parameter>();


    // ------------------------------------------------------
    // �w�i�̃p�����[�^.
    // ------------------------------------------------------
    [System.Serializable]
    public class Parameter
    {
        // ���O.
        public string Name = "";
        // �摜�p�����[�^�[�̃��X�g.
        public Sprite Sprite = null;

    }

    // -----------------------------------------------------------------------
    // �摜������摜���擾����.
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