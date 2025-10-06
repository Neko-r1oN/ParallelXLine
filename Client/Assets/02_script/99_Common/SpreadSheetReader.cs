
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
        Debug.Log("�ǂݍ��݊J�n");
        UnityWebRequest request = UnityWebRequest.Get("https://docs.google.com/spreadsheets/d/" + id + "/gviz/tq?tqx=out:csv&sheet=" + name);
        await request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(request.error);
            return null;
        }
        else
        {
           // Debug.Log("<< �S�� >>\n" + request.downloadHandler.text);
            var dataList = GetSheetData(request.downloadHandler.text);
            return dataList;
        }
    }
    // ---------------------------------------------------------------------------------
    // �X�v���b�h�V�[�g��ǂݍ���.
    // ---------------------------------------------------------------------------------
    List<StoryData> GetSheetData(string text)
    {
        List<string[]> cells = new List<string[]>();
        StringReader reader = new StringReader(text);
        reader.ReadLine();  // 1�s�ڂ̓��x���Ȃ̂ŊO��
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();        // ��s���ǂݍ���
            string result = "";
            while (true)
            {
                int count = 0;
                bool isCell = false;
                foreach (var c in line)
                {
                    // �Z�����ɃR���}���g�p����Ă���ꍇ�ɂ��̃R���}��<c>�ɒu��������.����ȊO�͂��̂܂ܕ������.
                    if (c.ToString() == "," && isCell == true) result += "<c>";
                    else result += c.ToString();

                    // �"�̓Z���̊J�n�A�����͏I��.
                    if (c.ToString() == "\"")
                    {
                        count++;
                        isCell = !isCell;
                    }
                }

                // ��̂܂܂P�s���I������ꍇ���̍s�݂̂Ŋ������Ă��Ȃ��̂ŁA��Uresult�����Z�b�g����line�Ɏ��̍s���ǂݍ���.
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

            // �s�̃Z����,�ŋ�؂���B�Z�����Ƃɕ����Ĕz��.
            string[] elements = result.Split(',');
            cells.Add(elements);
        }
        string log = "";
        List<StoryData> storys = new List<StoryData>();
        foreach (var line in cells)
        {
            var data = new StoryData();

            // �ŏ��Ō�݂̈͂������āA�R���}�A���s�Ȃǂ����ɖ߂��B
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

            // �f�[�^�̒l������.
            data.Place = replace0;
            data.Name = replace1;
            data.Talk = replace2;
            data.Left = replace3;
            data.Center = replace4;
            data.Right = replace5;

            log += $"<�ꏊ> {data.Place}, <�L����No> {data.Name}, <���e> {data.Talk}, <��> {data.Left}, <��> {data.Center}, <�E> {data.Right}\n";

            storys.Add(data);
        }

        Debug.Log(log);

        return storys;
    }

}