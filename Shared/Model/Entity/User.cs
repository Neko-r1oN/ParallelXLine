////////////////////////////////////////////////////////////////////////////
///
///  ユーザーデータスクリプト
///  Author : 川口京佑  2025.01/28
///
////////////////////////////////////////////////////////////////////////////

using MessagePack;
using System;
using UnityEngine;

namespace Shared.Model.Entity
{
    /// <summary>
    /// ユーザークラス
    /// </summary>
    [MessagePackObject]
    public class User
    {
        [Key(0)]
        public int Id { get; set; }                //作成ID
        [Key(1)]
        public string Name { get; set; }           //ユーザー名
        [Key(2)]
        public int UserId { get; set; }            //ユーザーID
        [Key(3)]
        public string PlayerName { get; set; }     //プレイヤー名
        [Key(4)]
        public Vector3 PlayerPos { get; set; }     //プレイヤー座標
        [Key(5)]
        public DateTime Created_at { get; set; }   //生成日時
        [Key(6)]
        public DateTime Updated_at { get; set; }   //更新日時
    }
}
