using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoryData
{
    // �L����.
    public string Name = "";
    // ��b���e.
    [Multiline(3)] public string Talk = "";
    // �ꏊ�A�w�i.
    public string Place = "";
    // ���L����.
    public string Left = "";
    // �^�񒆃L����.
    public string Center = "";
    // �E�L����.
    public string Right = "";
}
