using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;                   //DOTween���g���Ƃ��͂���using������
using KanKikuchi.AudioManager;

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

        //�S�Ă�BGM���t�F�[�h�A�E�g
        BGMManager.Instance.FadeOut();

        //BGM�Đ�
        BGMManager.Instance.Play(
            audioPath: BGMPath.TITLE, //�Đ��������I�[�f�B�I�̃p�X
            volumeRate: 1,                //���ʂ̔{��
            delay: 0,                //�Đ������܂ł̒x������
            pitch: 1,                //�s�b�`
            isLoop: true,             //���[�v�Đ����邩
            allowsDuplicate: false             //����BGM�Əd�����čĐ������邩
        );
    }

    public void OpenOptionButton()
    {
        SEManager.Instance.Play(
            audioPath: SEPath.TAP, //�Đ��������I�[�f�B�I�̃p�X
            volumeRate: 1,                //���ʂ̔{��
            delay: 0,                //�Đ������܂ł̒x������
            pitch: 1,                //�s�b�`
            isLoop: false,             //���[�v�Đ����邩
            callback: null              //�Đ��I����̏���
        );

        menu.SetActive(true);
        isMenuFlag = true;
        
    }

    public void CloseOptionButton()
    {
        SEManager.Instance.Play(
            audioPath: SEPath.TAP, //�Đ��������I�[�f�B�I�̃p�X
            volumeRate: 1,                //���ʂ̔{��
            delay: 0,                //�Đ������܂ł̒x������
            pitch: 1,                //�s�b�`
            isLoop: false,             //���[�v�Đ����邩
            callback: null              //�Đ��I����̏���
        );

        isMenuFlag = false;
        Invoke("CloseMenu", 0.5f);
        
    }

    void CloseMenu()
    {
        menu.SetActive(false);
    }

    public void OnClickStart()
    {
        SEManager.Instance.Play(
            audioPath: SEPath.TAP, //�Đ��������I�[�f�B�I�̃p�X
            volumeRate: 1,                //���ʂ̔{��
            delay: 0,                //�Đ������܂ł̒x������
            pitch: 1,                //�s�b�`
            isLoop: false,             //���[�v�Đ����邩
            callback: null              //�Đ��I����̏���
        );

        //�S�Ă�BGM���t�F�[�h�A�E�g
        BGMManager.Instance.FadeOut(BGMPath.TITLE, 3, () => {
            Debug.Log("BGM�t�F�[�h�A�E�g�I��");
        });
    }

}

