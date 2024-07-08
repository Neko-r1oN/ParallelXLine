using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;  //DOTween���g���Ƃ��͂���using������

public class MenuManager : MonoBehaviour
{

    Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenOptionAnim()
    {
        //menu.SetActive(true);
        animator.SetBool("isManu", true);
    }

    public void CloseOptionAnim()
    {
       
        animator.SetBool("isManu", false);
    }

}

