using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public void nextScene()
    {
        //�X�e�[�W�̃N���A�����擾
        int StageUnlock = PlayerPrefs.GetInt("StageUnlock");
        int NextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if(NextScene < 11)
        {
            if(StageUnlock < NextScene)
            {
                PlayerPrefs.SetInt("StageUnlocl", NextScene);
            }
        }
    }
}