using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cysharp.Threading.Tasks;
using TMPro;

// ------------------------------------------------------------
/// �I�����̃{�^��.
// ------------------------------------------------------------
public class SelectButton : MonoBehaviour
{
    // �e�L�X�g.
    [SerializeField] TextMeshProUGUI buttonText = null;
    // �g�����W�V����.
    [SerializeField] UITransition transition = null;
    // �N���b�N�C�x���g��`.
    public class ClickEvent : UnityEvent<int> { };
    // �N���b�N�C�x���g.
    public ClickEvent OnClicked = new ClickEvent();
    // �{�^���C���f�b�N�X.
    public int buttonIndex = 0;

    void Start()
    {
    }

    // ------------------------------------------------------------
    // �쐬���R�[��.
    // ------------------------------------------------------------
    public async UniTask OnCreated(string txt, int index, UnityAction<int> onClick)
    {
        transition.Canvas.alpha = 0;
        buttonText.text = txt;
        buttonIndex = index;
        OnClicked.AddListener(onClick);

        await transition.TransitionInWait();
    }

    // ------------------------------------------------------------
    // ����.
    // ------------------------------------------------------------
    public async UniTask Close()
    {
        await transition.TransitionOutWait();
        Destroy(gameObject);
    }

    // ------------------------------------------------------------
    // �{�^���N���b�N�R�[���o�b�N.
    // ------------------------------------------------------------
    public void OnButtonClicked()
    {
        OnClicked.Invoke(buttonIndex);
    }
}