using CriWare;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BGMManager : MonoBehaviour
{
    private CriAtomExAcb acb;
    private CriAtomExPlayer atomExPlayer;

    private void Start()
    {
        atomExPlayer = new CriAtomExPlayer();
    }

    public async void LoadCueSheetAsync(string targetName)
    {
        CriAtomCueSheet criAtomCueSheet = CriAtom.GetCueSheet(targetName);

        if (criAtomCueSheet == null)
        {
            criAtomCueSheet = CriAtom.AddCueSheet(targetName, targetName + ".acb", "");
            while (criAtomCueSheet.IsLoading)
            {
                await Task.Yield();
            }
        }

        acb = criAtomCueSheet.acb;
    }

    public void PlaySE(string cueName)
    {
        if (acb == null) return;
        if (!acb.Exists(cueName)) return;

        atomExPlayer.SetCue(acb, cueName);
        atomExPlayer.Start();
    }
}
