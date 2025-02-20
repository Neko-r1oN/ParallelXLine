using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;                   //DOTweenを使うときはこのusingを入れる
using KanKikuchi.AudioManager;

public class TitleManager : MonoBehaviour
{

    [SerializeField] GameObject fade;
    [SerializeField] GameObject menu;
    public static bool isMenuFlag;

    

    void Start()
    {
        fade.SetActive(true);               //フェードを有効化
        menu.SetActive(false);              //メニューを非表示
        isMenuFlag = false;                 //メニューフラグを無効化

        //BGM再生
        BGMManager.Instance.Play(
            audioPath: BGMPath.TITLE, //再生したいオーディオのパス
            volumeRate: 0.5f,                //音量の倍率
            delay: 2.0f,                //再生されるまでの遅延時間
            pitch: 1,                //ピッチ
            isLoop: true,             //ループ再生するか
            allowsDuplicate: false             //他のBGMと重複して再生させるか
        );
        SEManager.Instance.Play(
           audioPath: SEPath.TRAIN, //再生したいオーディオのパス
           volumeRate: 0.7f,                //音量の倍率
           delay: 0,                //再生されるまでの遅延時間
           pitch: 1,                //ピッチ
           isLoop: true,             //ループ再生するか
           callback: null              //再生終了後の処理
       );

        //全てのBGMをフェードアウト
        BGMManager.Instance.FadeIn(1.0f);
        //全てのBGMをフェードアウト
        SEManager.Instance.FadeIn(1.0f);
    }

    public void OpenOptionButton()
    {
        ClickSE();

        menu.SetActive(true);
        isMenuFlag = true;
        
    }

    public void CloseOptionButton()
    {
        SEManager.Instance.Play(
            audioPath: SEPath.TAP, //再生したいオーディオのパス
            volumeRate: 1,                //音量の倍率
            delay: 0,                //再生されるまでの遅延時間
            pitch: 1,                //ピッチ
            isLoop: false,             //ループ再生するか
            callback: null              //再生終了後の処理
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
        ClickSE();

        //全てのBGMをフェードアウト
        BGMManager.Instance.FadeOut(BGMPath.TITLE, 3, () => {
            Debug.Log("BGMフェードアウト終了");
        });
    }

    /// <summary>
    /// クリック音再生関数
    /// </summary>
    public void ClickSE()
    {
        SEManager.Instance.Play(
            audioPath: SEPath.TAP, //再生したいオーディオのパス
            volumeRate: 1,                //音量の倍率
            delay: 0,                //再生されるまでの遅延時間
            pitch: 1,                //ピッチ
            isLoop: false,             //ループ再生するか
            callback: null              //再生終了後の処理
        );
    }

}

