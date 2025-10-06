////////////////////////////////////////////////////////////////////////////
///
///  ユーザーセーブデータスクリプト
///  Author : 川口京佑  2025.01/28
///
////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public string UserName { get; set; }    //ユーザー名
    public int UserID { get; set; }         //ユーザーID
    public string PlayerName { get; set; }  //プレイヤー(ゲーム内)名
    public Vector3 PlayerPos { get; set; }  //プレイヤー座標

}