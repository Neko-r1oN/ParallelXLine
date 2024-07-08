using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class SelectButtonDialog : MonoBehaviour
{
    // �w�i�̃g�����W�V����.
    [SerializeField] UITransition bgTransition = null;
    // �{�^���̐e.
    [SerializeField] Transform buttonParent = null;
    // �{�^���̃v���n�u.
    [SerializeField] SelectButton buttonPrefab = null;
    // ���X�|���X.
    int response = -1;
    // �{�^�����X�g.
    List<SelectButton> buttons = new List<SelectButton>();

    void Start()
    {
    }

    // ------------------------------------------------------------
    // �{�^���̐���.
    // ------------------------------------------------------------
    public async UniTask<int> CreateButtons(bool bgOpen, string[] selectParams)
    {
        if (selectParams == null || selectParams.Length == 0) return -1;

        try
        {
            var tasks = new List<UniTask>();
            int index = 0;

            // �w�i�̐ݒ�.
            if (bgOpen == true)
            {
                bgTransition.gameObject.SetActive(true);
                tasks.Add(bgTransition.TransitionInWait());
            }
            else
            {
                bgTransition.gameObject.SetActive(false);
            }

            // �{�^���̐���.
            foreach (var param in selectParams)
            {
                var button = Instantiate(buttonPrefab, buttonParent);
                buttons.Add(button);
                tasks.Add(button.OnCreated(param, index, OnAnyButtonClicked));
                index++;
            }

            // ���C�A�E�g�O���[�v�̊m���Ȕ��f�̂��߂ɃL�����o�X���X�V.
            Canvas.ForceUpdateCanvases();

            await UniTask.WhenAll(tasks);

            // �����ŉ�������̃{�^�����������܂őҋ@.
            await UniTask.WaitUntil(() => response != -1, PlayerLoopTiming.Update, this.GetCancellationTokenOnDestroy());
            var res = response;
            // ����.
            await Close();

            return res;
        }
        catch (System.OperationCanceledException e)
        {
            Debug.Log("CreateButtons �L�����Z���B");
            throw e;
        }

    }

    // ------------------------------------------------------------
    // �_�C�A���O�����.
    // ------------------------------------------------------------
    public async UniTask Close()
    {
        // �{�^�������.
        var tasks = new List<UniTask>();
        foreach (var b in buttons)
        {
            tasks.Add(b.Close());
        }
        // �w�i�����.
        if (bgTransition.gameObject.activeSelf == true)
        {
            tasks.Add(bgTransition.TransitionOutWait());
        }

        await UniTask.WhenAll(tasks);
        bgTransition.gameObject.SetActive(false);
        response = -1;
    }

    // ------------------------------------------------------------
    // �ǂꂩ�̃{�^�������������̏���.
    // ------------------------------------------------------------
    void OnAnyButtonClicked(int index)
    {
        // ���X�|���X������.
        Debug.Log(index + "���N���b�N");
        response = index;
    }
}