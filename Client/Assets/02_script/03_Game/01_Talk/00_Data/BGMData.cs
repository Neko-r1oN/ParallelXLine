using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BGMData", menuName = "ScriptableObjects/BGMData")]
public class BGMData : ScriptableObject
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
        public AudioClip BGM = null;

    }

    // -----------------------------------------------------------------------
    // �摜������摜���擾����.
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