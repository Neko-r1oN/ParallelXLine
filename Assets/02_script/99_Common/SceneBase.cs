using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SceneBase : MonoBehaviour
{
    // �����r���[�C���f�b�N�X.
    [SerializeField] protected int initialViewIndex = 0;
    // �����r���[�g�����W�V�����t���O.
    [SerializeField] protected bool isInitialTransition = true;
    // View���X�g.
    [SerializeField] protected List<ViewBase> viewList = new List<ViewBase>();
    // ���݂̃r���[.
    protected ViewBase currentView = null;

    protected virtual void Start()
    {
        // ����Index�������Ɛݒ肳��Ă�����B
        if (initialViewIndex >= 0)
        {
            // �r���[�̃��X�g�S�Ă�.
            foreach (var view in viewList)
            {
                // �V�[����ݒ�.
                view.Scene = this;
                // �����C���f�b�N�X�̃r���[�ɑ΂��Ă̏���.
                if (viewList.IndexOf(view) == initialViewIndex)
                {
                    // �g�����W�V��������ꍇ.
                    if (view.Transition != null && isInitialTransition == true)
                    {
                        view.Transition.Canvas.alpha = 0;
                        view.gameObject.SetActive(true);
                        view.OnViewOpened();
                        view.Transition.TransitionIn();
                    }
                    // �g�����W�V�������Ȃ��ꍇ.
                    else
                    {
                        view.OnViewOpened();
                        view.gameObject.SetActive(true);
                    }
                    // ���݂̃r���[��ݒ�.
                    currentView = view;
                }
                // �����r���[�ȊO�ɑ΂��Ă̏���.
                else
                {
                    view.gameObject.SetActive(false);
                }
            }
        }
    }

    // ------------------------------------------------
    /// View�ړ�����
    // ------------------------------------------------
    public virtual async UniTask ChangeView(int index)
    {
        // ���݂̃r���[���ݒ肳��Ă���ꍇClose�������s��.
        if (currentView != null)
        {
            currentView.OnViewClosed();
            if (currentView.Transition != null) await currentView.Transition.TransitionOutWait();
        }

        // �r���[���X�g����w��̃C���f�b�N�X�r���[������.
        foreach (var view in viewList)
        {
            // �Y���r���[��.
            if (viewList.IndexOf(view) == index)
            {
                // �I�[�v���������s��.
                view.gameObject.SetActive(true);
                view.OnViewOpened();
                if (view.Transition != null) await view.Transition.TransitionInWait();

                currentView = view;
            }
            else
            {
                view.gameObject.SetActive(false);
            }
        }
    }

    // ------------------------------------------------
    /// Scene�ړ�����
    // ------------------------------------------------
    public virtual async UniTask ChangeScene(string sceneName)
    {
        // ���݂̃r���[���ݒ肳��Ă���ꍇClose�������s��.
        if (currentView != null)
        {
            currentView.OnViewClosed();
            if (currentView.Transition != null) await currentView.Transition.TransitionOutWait();
        }

        await SceneManager.LoadSceneAsync(sceneName);
    }

}