using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;  //DOTween���g���Ƃ��͂���using������


public class StartFade : MonoBehaviour
{
    [SerializeField] Renderer fade;

    [Header("���[�v�J�n���̐F")]
    [SerializeField]
    Color32 startColor = new Color32(255, 255, 255, 255);
    

    // Start is called before the first frame update
    void Start()
    {
        fade = GetComponent<Renderer>();

        fade.material.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        fade.material.color = Color.Lerp(fade.material.color, new Color(1, 1, 1.0f, 0), 0.2f * Time.deltaTime);
    }
}
