////////////////////////////////////////////////////////////////////////////
///
///  ルームモデルスクリプト
///  Author : 川口京佑  2025.01/28
///
////////////////////////////////////////////////////////////////////////////
/*
using Cysharp.Net.Http;
using Cysharp.Threading.Tasks;
using Grpc.Net.Client;
using MagicOnion.Client;
using Shared.Interfaces.StreamingHubs;
using Shared.Model.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SocialPlatforms;
using static UnityEngine.UIElements.UxmlAttributeDescription;

/// <summary>
/// ルーム処理クラス
/// </summary>
/// 
public class RoomModel : BaseModel, IRoomHubReceiver
{
    private GrpcChannel channel;
    private IRoomHub roomHub;

    private int userId;

    public bool isMaster;

    //接続ID
    public Guid ConnectionId { get; set; }
    //ユーザー接続通知
    public Action<JoinedUser> OnJoinedUser { get; set; }
    //ユーザー切断通知
    public Action<Guid> LeavedUser { get; set; }
    //ユーザーマッチング通知
    public Action<string> MatchedUser { get; set; }
    //マスターチェック
    public Action MasterCheckedUser { get; set; }

    //準備遷移通知
    public Action StandUser { get; set; }
    //ユーザー準備状態確認通知
    public Action<Guid, bool> ReadyUser { get; set; }
   

    //ユーザー状態
    public enum USER_STATE
    {
        NONE = 0,             //停止中
        CONNECT = 1,          //接続中
        JOIN = 2,             //入室中
        LEAVE = 3,            //退出中
    }

    USER_STATE userState = USER_STATE.NONE;

    //MoajicOnion接続処理
    public async UniTask ConnectAsync()
    {
        var handler = new YetAnotherHttpHandler() { Http2Only = true };
        channel = GrpcChannel.ForAddress(ServerURL, new GrpcChannelOptions() { HttpHandler = handler });
        roomHub = await StreamingHubClient.ConnectAsync<IRoomHub, IRoomHubReceiver>(channel, this);

        //ユーザー状態を接続中に変更
        userState = USER_STATE.CONNECT;

        //マスタークライアント判定
        isMaster = false;
    }

    //MagicOnion切断処理
    public async UniTask DisConnectAsync()
    {
        if (roomHub != null)
        {
            await roomHub.DisposeAsync();
        }
        if (channel != null)
        {
            await channel.ShutdownAsync();
        }

        roomHub = null; channel = null;

        //ユーザー状態を停止中に変更
        userState = USER_STATE.NONE;
    }

    //破棄処理
    async void OnDestroy()
    {
        await DisConnectAsync();
    }

    //入室処理
    public async UniTask JoinAsync(string roomName, int userId)
    {
        //配列に引数で受け取った情報を追加
        JoinedUser[] users = await roomHub.JoinAsync(roomName, userId);

        //配列の要素分ループ
        foreach (var user in users)
        {
            if (user.UserData.Id == userId)
            {
                this.ConnectionId = user.ConnectionId;

                Debug.Log(this.ConnectionId);
            }
            OnMasterCheck(user);

            //
            OnJoinedUser(user);
        }

        //ユーザー状態を入室中に変更
        userState = USER_STATE.JOIN;

        Debug.Log("入室中");
    }

    //入室通知
    public void OnJoin(JoinedUser user)
    {
        //nullじゃなかったら実行(null条件演算子)
        OnJoinedUser?.Invoke(user);
    }


    //ロビー入室
    public async UniTask JoinLobbyAsync(int userId)
    {
        //配列に引数で受け取った情報を追加
        await roomHub.JoinLobbyAsync(userId);

        Debug.Log("ロビー入室");
    }
    //入室通知
    public void OnJoinLobby(JoinedUser user)
    {
        OnJoinedUser(user);
    }

    //マッチング通知
    public void OnMatch(string roomName)
    {
        MatchedUser(roomName);
        Debug.Log("マッチング成立:" + roomName);
    }


    //退出処理
    public async UniTask LeaveAsync()
    {
        //マスター判定削除
        isMaster = false;
        await roomHub.LeaveAsync();
    }

    //退出通知
    public void Leave(Guid LeaveId)
    {
        LeavedUser(LeaveId);
    }


    //マスタークライアント判定処理
    public void OnMasterCheck(JoinedUser user)
    {
        //マスタークライアント判定
        if (user.ConnectionId == this.ConnectionId && user.JoinOrder == 1)
        {
            Debug.Log(user.UserData.Name + "マスター");
            isMaster = true;
        }
        else Debug.Log(user.UserData.Name + "マスターじゃない");
    }

    //プレイヤー移動処理
    public async Task MoveAsync(MoveData moveData)
    {
        await roomHub.MoveAsync(moveData);
    }
    //移動通知
    public void OnMove(MoveData moveData)
    {
        MovedUser(moveData);
    }


    //準備状態遷移
    public void OnStand()
    {
        StandUser();
    }

    //準備完了処理
    public async Task ReadyAsync(Guid id, bool isReady)
    {
        await roomHub.ReadyAsync(id, isReady);
    }
    //通知
    public void Ready(Guid id, bool isStart)
    {
        ReadyUser(id, isStart);
    }
   
}*/

