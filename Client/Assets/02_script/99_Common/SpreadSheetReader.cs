
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;
using System.IO;

public class SpreadSheetReader : MonoBehaviour
{

    void Start()
    {
      /*  string _sheetId = "1yFNPA1Wl7FcbgGHC7fp8U_G0zcl24l5Mwudpl8n542g";
        string _sheetName = "Prologue";
        LoadSpreadSheet(_sheetId, _sheetName).Forget();*/
    }

    public async UniTask<List<StoryData>> LoadSpreadSheet(string id, string name)
    {
        Debug.Log("読み込み開始");
        UnityWebRequest request = UnityWebRequest.Get("https://docs.google.com/spreadsheets/d/" + id + "/gviz/tq?tqx=out:csv&sheet=" + name);
        await request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(request.error);
            return null;
        }
        else
        {
           // Debug.Log("<< 全文 >>\n" + request.downloadHandler.text);
            var dataList = GetSheetData(request.downloadHandler.text);
            return dataList;
        }
    }
    // ---------------------------------------------------------------------------------
    // スプレッドシートを読み込む.
    // ---------------------------------------------------------------------------------
    List<StoryData> GetSheetData(string text)
    {
        List<string[]> cells = new List<string[]>();
        StringReader reader = new StringReader(text);
        reader.ReadLine();  // 1行目はラベルなので外す
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();        // 一行ずつ読み込み
            string result = "";
            while (true)
            {
                int count = 0;
                bool isCell = false;
                foreach (var c in line)
                {
                    // セル内にコンマが使用されている場合にそのコンマを<c>に置き換える.それ以外はそのまま文字列へ.
                    if (c.ToString() == "," && isCell == true) result += "<c>";
                    else result += c.ToString();

                    // 奇数"はセルの開始、偶数は終了.
                    if (c.ToString() == "\"")
                    {
                        count++;
                        isCell = !isCell;
                    }
                }

                // 奇数のまま１行が終わった場合その行のみで完結していないので、一旦resultをリセットしてlineに次の行も読み込む.
                if (count == 0 || count % 2 == 1)
                {
                    line += "<br>";
                    line += reader.ReadLine();

                    result = "";
                }
                else
                {
                    break;
                }
            }

            //Debug.Log(result);

            // 行のセルは,で区切られる。セルごとに分けて配列化.
            string[] elements = result.Split(',');
            cells.Add(elements);
        }
        string log = "";
        List<StoryData> storys = new List<StoryData>();
        foreach (var line in cells)
        {
            var data = new StoryData();

            // 最初最後の囲みを消して、コンマ、改行などを元に戻す。
            var trim0 = line[0].TrimStart('"').TrimEnd('"');
            var replace0 = trim0.Replace("<br>", "\n");
            replace0 = replace0.Replace("<c>", ",");

            var trim1 = line[1].TrimStart('"').TrimEnd('"');
            var replace1 = trim1.Replace("<br>", "\n");
            replace1 = replace1.Replace("<c>", ",");

            var trim2 = line[2].TrimStart('"').TrimEnd('"');
            var replace2 = trim2.Replace("<br>", "\n");
            replace2 = replace2.Replace("<c>", ",");

            var trim3 = line[3].TrimStart('"').TrimEnd('"');
            var replace3 = trim3.Replace("<br>", "\n");
            replace3 = replace3.Replace("<c>", ",");

            var trim4 = line[4].TrimStart('"').TrimEnd('"');
            var replace4 = trim4.Replace("<br>", "\n");
            replace4 = replace4.Replace("<c>", ",");

            var trim5 = line[5].TrimStart('"').TrimEnd('"');
            var replace5 = trim5.Replace("<br>", "\n");
            replace5 = replace5.Replace("<c>", ",");

            // データの値を入れる.
            data.Place = replace0;
            data.Name = replace1;
            data.Talk = replace2;
            data.Left = replace3;
            data.Center = replace4;
            data.Right = replace5;

            log += $"<場所> {data.Place}, <キャラNo> {data.Name}, <内容> {data.Talk}, <左> {data.Left}, <中> {data.Center}, <右> {data.Right}\n";

            storys.Add(data);
        }

        Debug.Log(log);

        return storys;
    }

}