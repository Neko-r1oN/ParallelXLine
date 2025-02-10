using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;                   //DOTween���g���Ƃ��͂���using������

public class TitleManager : MonoBehaviour
{

    [SerializeField] GameObject fade;
    [SerializeField] GameObject menu;
    public static bool isMenuFlag;

    

    void Start()
    {
        fade.SetActive(true);               //�t�F�[�h��L����
        menu.SetActive(false);              //���j���[���\��
        isMenuFlag = false;                 //���j���[�t���O�𖳌���

        //BGM�Đ�
        
    }

    public void OpenOptionButton()
    {
        menu.SetActive(true);
        isMenuFlag = true;
        
    }

    public void CloseOptionButton()
    {
        isMenuFlag = false;
        Invoke("CloseMenu", 0.5f);
        
    }

    void CloseMenu()
    {
        menu.SetActive(false);
    }

    public void StartGame()
    {

    }

}

