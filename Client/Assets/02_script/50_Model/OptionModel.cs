////////////////////////////////////////////////////////////////////////////
///
///  ユーザーAPIスクリプト
///  Author : 川口京佑  2025.01/28
///
////////////////////////////////////////////////////////////////////////////

using Cysharp.Net.Http;
using Cysharp.Threading.Tasks;
using Grpc.Net.Client;
using MagicOnion.Client;
using Shared.Interfaces.RPCServices;
using Shared.Interfaces.StreamingHubs;
using Shared.Model.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;

/// <summary>
/// ユーザー処理クラス
/// </summary>
public class OptoinModel : BaseModel
{
    public int windowSize { get; set; }       //ウィンドウサイズ
    public int screenMode { get; set; }       //スクリーンモード
    public int textSize { get; set; }         //テキストサイズ
    public int textSpeed { get; set; }        //文字送りスピード
    public float BGMVolume { get; set; }      //BGMボリューム
    public float SEVolume { get; set; }       //SEボリューム


    private static OptoinModel instance;

    public static OptoinModel Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject gameObj = new GameObject("UserModel");
                //GameObject生成、NetworkManagerコンポーネントを追加
                instance = gameObj.AddComponent<OptoinModel>();
                //シーン移動時に削除しないようにする
                DontDestroyOnLoad(gameObj);
            }
            return instance;
        }
    }

    /// <summary>
    /// ユーザー登録処理
    /// </summary>
    /// <param name="name">ユーザー名</param>
    /// <returns>登録成功 or 失敗</returns>
    public async UniTask<bool> RegistUserAsync(string name)
    {
        var handler = new YetAnotherHttpHandler() { Http2Only = true };
        var channel = GrpcChannel.ForAddress(ServerURL, new GrpcChannelOptions() { HttpHandler = handler });
        var client = MagicOnionClient.Create<IUserService>(channel);
        try
        {//登録成功
            Debug.Log("サーバー接続成功");
            User user = await client.RegistUserAsync(name);
            //ファイルにユーザーを保存
            /*this.userName = name;
            this.userId = user.Id;
            this.authToken = user.Token;*/
            SaveOptionData();
            return true;
        }
        catch (Exception e)
        {//登録失敗
            Debug.Log("サーバー接続エラーか既に登録されてる名前です");
            Debug.Log(e);
            return false;
        }
    }

    //データ保存処理
    private void SaveOptionData()
    {
        OptionData optionData = new OptionData();
        /*optionData.Name = this.userName;
        optionData.UserID = this.userId;
        optionData.AuthToken = this.authToken;*/
        string json = JsonConvert.SerializeObject(optionData);

        //ファイルにJsonを保存
        var writer = new StreamWriter(Application.persistentDataPath + "/optionData.json");   // Application.persistentDataPathは保存ファイルを置く場所

        //Json形式で書き込み
        writer.Write(json);
        writer.Flush();
        writer.Close();
    }

    //ユーザー情報読み込み処理
    public bool LoadOptionData()
    {
        //ローカルに存在しない場合
        if (!File.Exists(Application.persistentDataPath + "/optionData.json")) return false;

        var reader = new StreamReader(Application.persistentDataPath + "/optionData.json");
        string json = reader.ReadToEnd();
        reader.Close();
        OptionData optionData = JsonConvert.DeserializeObject<OptionData>(json);

        //ローカルファイルから各種値を取得
        /*this.userId = saveData.UserID;
        this.userName = saveData.Name;
        this.authToken = saveData.AuthToken;*/

        //読み込み判定
        return true;
    }
}
