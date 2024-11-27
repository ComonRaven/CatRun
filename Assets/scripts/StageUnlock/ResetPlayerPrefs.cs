using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetPlayerPrefs : MonoBehaviour
{
    public void ResetAll()
    {
        PlayerPrefs.SetInt("StageUnlock" ,1);
        PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetInt("StageUnlock"));
    }
}
