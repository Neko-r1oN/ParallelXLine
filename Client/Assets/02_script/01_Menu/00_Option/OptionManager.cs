using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [SerializeField] Text windowSizeText;     //�E�B���h�E�T�C�Y�e�L�X�g
    [SerializeField] Text windowModeText;     //�E�B���h�E���[�h�e�L�X�g


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
            // �E�B���h�E���[�h�ɐ؂�ւ�
            Screen.fullScreen = false;
            windowModeText.text = "�t���X�N���[�����[�h";
        }
        else
        {
            // �t���X�N���[�����[�h�ɐ؂�ւ�
            Screen.fullScreen = false;
            windowModeText.text = "�E�B���h�E���[�h";
        }
    }
}
