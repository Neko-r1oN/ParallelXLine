using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewBase : MonoBehaviour
{
    // �r���[�̃g�����W�V����.
    UITransition transition = null;
    // �r���[�̃g�����W�V����.
    public UITransition Transition
    {
        get
        {
            if (transition == null) transition = GetComponent<UITransition>();
            return transition;
        }
    }
    // �V�[���x�[�X�N���X.
    public SceneBase Scene = null;


    // -------------------------------------------------------
    // �r���[�I�[�v�����R�[��.
    // -------------------------------------------------------
    public virtual void OnViewOpened()
    {
        // Debug.Log( "View Open" );
    }

    // -------------------------------------------------------
    // �r���[�N���[�Y���R�[��.
    // -------------------------------------------------------
    public virtual void OnViewClosed()
    {
        // Debug.Log( "View Close" );
    }
}