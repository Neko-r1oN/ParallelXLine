using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [SerializeField] Text windowSizeText;     //�E�B���h�E�T�C�Y�e�L�X�g
    [SerializeField] Text screenModeText;     //�X�N���[�����[�h�e�L�X�g


    void Start()
    {
        /*if(Screen.fullScreen) windowModeText.text = "�E�B���h�E���[�h";
        else windowSizeText.text = "�t���X�N���[�����[�h";*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �𑜓x�ύX�֐�
    /// </summary>
    public void OnClickChangeWindowSize()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen);

    }

    /// <summary>
    /// �E�B���h�E���[�h�ؑ֊֐�
    /// </summary>
    public void OnClickChangeScreenMode()
    {
        if (Screen.fullScreen)
        {
            // �E�B���h�E���[�h�ɐ؂�ւ�
            Screen.fullScreen = false;
            screenModeText.text = "�t���X�N���[�����[�h";
        }
        else
        {
            // �t���X�N���[�����[�h�ɐ؂�ւ�
            Screen.fullScreen = false;
            screenModeText.text = "�E�B���h�E���[�h";
        }
    }
}
