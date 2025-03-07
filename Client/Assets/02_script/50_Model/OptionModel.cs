////////////////////////////////////////////////////////////////////////////
///
///  ���[�U�[API�X�N���v�g
///  Author : ������C  2025.01/28
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
/// ���[�U�[�����N���X
/// </summary>
public class OptoinModel : BaseModel
{
    public int windowSize { get; set; }       //�E�B���h�E�T�C�Y
    public int screenMode { get; set; }       //�X�N���[�����[�h
    public int textSize { get; set; }         //�e�L�X�g�T�C�Y
    public int textSpeed { get; set; }        //��������X�s�[�h
    public float BGMVolume { get; set; }      //BGM�{�����[��
    public float SEVolume { get; set; }       //SE�{�����[��


    private static OptoinModel instance;

    public static OptoinModel Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject gameObj = new GameObject("UserModel");
                //GameObject�����ANetworkManager�R���|�[�l���g��ǉ�
                instance = gameObj.AddComponent<OptoinModel>();
                //�V�[���ړ����ɍ폜���Ȃ��悤�ɂ���
                DontDestroyOnLoad(gameObj);
            }
            return instance;
        }
    }

    /// <summary>
    /// ���[�U�[�o�^����
    /// </summary>
    /// <param name="name">���[�U�[��</param>
    /// <returns>�o�^���� or ���s</returns>
    public async UniTask<bool> RegistUserAsync(string name)
    {
        var handler = new YetAnotherHttpHandler() { Http2Only = true };
        var channel = GrpcChannel.ForAddress(ServerURL, new GrpcChannelOptions() { HttpHandler = handler });
        var client = MagicOnionClient.Create<IUserService>(channel);
        try
        {//�o�^����
            Debug.Log("�T�[�o�[�ڑ�����");
            User user = await client.RegistUserAsync(name);
            //�t�@�C���Ƀ��[�U�[��ۑ�
            /*this.userName = name;
            this.userId = user.Id;
            this.authToken = user.Token;*/
            SaveOptionData();
            return true;
        }
        catch (Exception e)
        {//�o�^���s
            Debug.Log("�T�[�o�[�ڑ��G���[�����ɓo�^����Ă閼�O�ł�");
            Debug.Log(e);
            return false;
        }
    }

    //�f�[�^�ۑ�����
    private void SaveOptionData()
    {
        OptionData optionData = new OptionData();
        /*optionData.Name = this.userName;
        optionData.UserID = this.userId;
        optionData.AuthToken = this.authToken;*/
        string json = JsonConvert.SerializeObject(optionData);

        //�t�@�C����Json��ۑ�
        var writer = new StreamWriter(Application.persistentDataPath + "/optionData.json");   // Application.persistentDataPath�͕ۑ��t�@�C����u���ꏊ

        //Json�`���ŏ�������
        writer.Write(json);
        writer.Flush();
        writer.Close();
    }

    //���[�U�[���ǂݍ��ݏ���
    public bool LoadOptionData()
    {
        //���[�J���ɑ��݂��Ȃ��ꍇ
        if (!File.Exists(Application.persistentDataPath + "/optionData.json")) return false;

        var reader = new StreamReader(Application.persistentDataPath + "/optionData.json");
        string json = reader.ReadToEnd();
        reader.Close();
        OptionData optionData = JsonConvert.DeserializeObject<OptionData>(json);

        //���[�J���t�@�C������e��l���擾
        /*this.userId = saveData.UserID;
        this.userName = saveData.Name;
        this.authToken = saveData.AuthToken;*/

        //�ǂݍ��ݔ���
        return true;
    }
}
