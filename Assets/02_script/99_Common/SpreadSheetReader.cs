
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;

public class SpreadSheetReader : MonoBehaviour
{

    void Start()
    {
        string _sheetId = "1yFNPA1Wl7FcbgGHC7fp8U_G0zcl24l5Mwudpl8n542g";
        string _sheetName = "TestSheet";
        LoadSpreadSheet(_sheetId, _sheetName).Forget();
    }

    public async UniTask LoadSpreadSheet(string id, string name)
    {
        Debug.Log("ì«Ç›çûÇ›äJén");
        UnityWebRequest request = UnityWebRequest.Get("https://docs.google.com/spreadsheets/d/" + id + "/gviz/tq?tqx=out:csv&sheet=" + name);
        await request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("<< ëSï∂ >>\n" + request.downloadHandler.text);
        }
    }
}