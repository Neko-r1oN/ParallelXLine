using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : ViewBase
{
    // トークウインドウ.
    [SerializeField] TalkWindow talkWindow = null;
    // スプレッドシートリーダー.
    [SerializeField] SpreadSheetReader spreadSheetReader = null;

    void Start()
    {
    }

    // -------------------------------------------------------
    // ビューオープン時コール.
    // -------------------------------------------------------
    public override async void OnViewOpened()
    {
        base.OnViewOpened();

        // テストデータなのでコメントアウト.
        // var data = talkWindow.Talks;
        string _sheetId = "1yFNPA1Wl7FcbgGHC7fp8U_G0zcl24l5Mwudpl8n542g";
        string _sheetName = "Prologue";
        var data = await spreadSheetReader.LoadSpreadSheet(_sheetId, _sheetName);

        try
        {
            await talkWindow.SetBg(data[0].Place, true);

            Debug.Log("会話開始");
            await talkWindow.Open();
            await talkWindow.TalkStart(data);
            await talkWindow.Close();
            Debug.Log("テスト終了");
        }
        catch (System.OperationCanceledException e)
        {
            Debug.Log("テスト会話がキャンセルされました。" + e);
        }
    }

    // -------------------------------------------------------
    // ビュークローズ時コール.
    // -------------------------------------------------------
    public override void OnViewClosed()
    {
        base.OnViewClosed();
    }

    // -------------------------------------------------------
    // ホームに戻る.
    // -------------------------------------------------------
    public void OnBackToHomeButtonClicked()
    {
        Scene.ChangeScene("01_Home").Forget();
    }
}