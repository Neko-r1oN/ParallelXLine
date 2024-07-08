using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading;
using UnityEngine.Events;
using Cysharp.Threading.Tasks;



[RequireComponent(typeof(CanvasGroup))]
public class UITransition : MonoBehaviour
{
    // ���N�g�g�����X�t�H�[���擾�p.
    public RectTransform Rect
    {
        get
        {
            if (rect == null) rect = GetComponent<RectTransform>();
            return rect;
        }
    }
    // ���N�g�g�����X�t�H�[���ۊǗp.
    RectTransform rect = null;

    // �ݒ�l.
    [System.Serializable]
    public class TransitionParam
    {
        // ���s�t���O.
        public bool IsActive = true;
        // �C���̒l.
        public Vector2 In = new Vector2(0, 1f);
        // �A�E�g�̒l.
        public Vector2 Out = new Vector2(1f, 0);
    }

    // �t�F�[�h�ݒ�l.
    [SerializeField] TransitionParam fade = new TransitionParam();
    // �X�P�[���ݒ�l.
    [SerializeField] TransitionParam scale = new TransitionParam() { IsActive = false, In = Vector2.zero, Out = Vector2.zero };
    // �J�ڎ���.
    [SerializeField] float duration = 1f;

    //! �C���̃V�[�N�G���X.
    Sequence inSequence = null;
    //! �A�E�g�̃V�[�N�G���X.
    Sequence outSequence = null;

    //! �C���̃L�����Z���g�[�N��.
    CancellationTokenSource inCancellation = null;
    //! �A�E�g�̃L�����Z���g�[�N��.
    CancellationTokenSource outCancellation = null;

    // �L�����o�X�O���[�v�擾�p.
    public CanvasGroup Canvas
    {
        get
        {
            if (canvas == null) canvas = GetComponent<CanvasGroup>();
            return canvas;
        }
    }

    // �L�����o�X�O���[�v�ۊǗp.
    CanvasGroup canvas = null;

    void Start()
    {
    }

    // ----------------------------------------------------
    // �g�����W�V�����C��.
    // ----------------------------------------------------
    public void TransitionIn(UnityAction onCompleted = null)
    {
        if (inSequence != null)
        {
            inSequence.Kill();
            inSequence = null;
        }
        inSequence = DOTween.Sequence();

        if (fade.IsActive == true && Canvas != null)
        {
            Canvas.alpha = fade.In.x;

            inSequence.Join
            (
                Canvas.DOFade(fade.In.y, duration)
                .SetLink(gameObject)
            );
        }

        if (scale.IsActive == true)
        {
            var current = Rect.transform.localScale;
            Rect.transform.localScale = new Vector3(scale.In.x, scale.In.y, current.z);

            inSequence.Join
            (
                Rect.DOScale(current, duration)
                .SetLink(gameObject)
            );
        }

        inSequence
        .SetLink(gameObject)
        .OnComplete(() => onCompleted?.Invoke());
    }

    // ----------------------------------------------------
    // �g�����W�V�����A�E�g.
    // ----------------------------------------------------
    public void TransitionOut(UnityAction onCompleted = null)
    {
        if (outSequence != null)
        {
            outSequence.Kill();
            outSequence = null;
        }
        outSequence = DOTween.Sequence();

        if (fade.IsActive == true && Canvas != null)
        {
            Canvas.alpha = fade.Out.x;

            outSequence.Join
            (
                Canvas.DOFade(fade.Out.y, duration)
                .SetLink(gameObject)
            );
        }

        if (scale.IsActive == true)
        {
            var current = Rect.transform.localScale;
            outSequence.Join
            (
                Rect.DOScale(new Vector3(scale.Out.x, scale.Out.y, current.z), duration)
                .SetLink(gameObject)
                .OnComplete(() => Rect.transform.localScale = current)
            );
        }

        outSequence
        .SetLink(gameObject)
       .OnComplete(() => onCompleted?.Invoke());
    }

    // ----------------------------------------------------
    // �g�����W�V�����C���I���ҋ@.
    // ----------------------------------------------------
    public async UniTask TransitionInWait()
    {
        bool isDone = false;
        if (inCancellation != null)
        {
            inCancellation.Cancel();
        }
        inCancellation = new CancellationTokenSource();

        TransitionIn(() => { isDone = true; });

        try
        {
            await UniTask.WaitUntil(() => isDone == true, PlayerLoopTiming.Update, inCancellation.Token);
        }
        catch (System.OperationCanceledException e)
        {
            Debug.Log("�L�����Z������܂����B" + e);
            throw e;
        }

    }

    // ----------------------------------------------------
    // �g�����W�V�����A�E�g�I���ҋ@.
    // ----------------------------------------------------
    public async UniTask TransitionOutWait()
    {
        bool isDone = false;
        if (outCancellation != null)
        {
            outCancellation.Cancel();
        }
        outCancellation = new CancellationTokenSource();

        TransitionOut(() => { isDone = true; });

        try
        {
            await UniTask.WaitUntil(() => isDone == true, PlayerLoopTiming.Update, outCancellation.Token);
        }
        catch (System.OperationCanceledException e)
        {
            Debug.Log("�L�����Z������܂����B" + e);
            throw e;
        }

    }

    // ----------------------------------------------------
    // �j�����ꂽ���̃R�[���o�b�N.
    // ----------------------------------------------------
    void OnDestroy()
    {
        if (inCancellation != null)
        {
            inCancellation.Cancel();
        }
        if (outCancellation != null)
        {
            outCancellation.Cancel();
        }
    }

}