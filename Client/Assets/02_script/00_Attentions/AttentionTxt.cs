using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;  //DOTween���g���Ƃ��͂���using������

/// <summary>
/// �Q�[���N�����\���e�L�X�g�N���X
/// </summary>
public class AttentionText : MonoBehaviour
{
    [SerializeField] GameObject text;           //�e�L�X�g
    [SerializeField] GameObject image;    //�v���_�N�g�摜

    [SerializeField] float startTime;     //�`��J�n����

    private Text textColor;     //�F�ύX�p(�e�L�X�g)
    private Image imgColor;     //�F�ύX�p(�摜)

    private float finishTime = 3.0f;     //�\������
    private float timer;                 //�J��Ԃ��Ԋu

    public bool isChange;   //�\�����I������J�ڂ��邩

    [Header("�X�^�[�g�J���[")]
    [SerializeField]
    Color32 startColor = new Color32(255, 255, 255, 0);

    [Header("�G���h�J���[")]
    [SerializeField]
    Color32 endColor = new Color32(255, 255, 255, 255);

    void Start()
    {
        if (text)
        {
            textColor = text.GetComponent<Text>();
            textColor.color = startColor;
        }
        if (image)
        {
            imgColor = image.GetComponent<Image>();
            imgColor.color = startColor;
        }

        timer = 0.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;     //���Ԃ��J�E���g����

        if (timer >= startTime)
        {
            if(text) textColor.color = Color.Lerp(textColor.color, new Color(1, 1, 1, 1), 2.0f * Time.deltaTime);      //�e�L�X�g
            if(imgColor) imgColor.color = Color.Lerp(imgColor.color, new Color(1, 1, 1, 1), 2.0f * Time.deltaTime);     //�v���_�N�g�摜

            if (timer >= startTime + finishTime)
            {
                if (text) textColor.color = Color.Lerp(textColor.color, new Color(0, 0, 0, -3), 2.0f * Time.deltaTime);
                if (imgColor) imgColor.color = Color.Lerp(imgColor.color, new Color(0, 0, 0, -3), 2.0f * Time.deltaTime);

                if (isChange) Invoke("StartTitleScene", 1.0f);
            }
        }
    }

    public void StartTitleScene()
    {
        // �V�[���J��
        Initiate.Fade("TitleScene", new Color(0,0, 0, 0), 2.0f);
    }

}