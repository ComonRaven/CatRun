using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    // ボタンを配列として定義
    [SerializeField] private Button[] stageButton;

    void Start()
    {
        //ステージのクリア数の初期値を１にする
        // PlayerPrefs.SetInt("StageUnlock", 1);
        //保存
        // PlayerPrefs.Save();
        int stageunlock = PlayerPrefs.GetInt("StageUnlock");
        if(stageunlock < 1)
        {
            PlayerPrefs.SetInt("StageUnlock", 1);
        }
    }
    void Update()
    {
        // ステージのクリア数を取得
        int stageUnlock = PlayerPrefs.GetInt("StageUnlock");

        // ステージボタンの表示・非表示の設定
        for (int i = 0; i < stageButton.Length; i++)
        {
            if (i < stageUnlock) { 
                stageButton[i].interactable = true; 
            }
            else
            {
                stageButton[i].interactable = false;
            }
            //Debug.Log(i);
            //Debug.Log(stageUnlock);
            //Debug.Log(PlayerPrefs.GetInt("StageUnlock"));
        }
    }
    public void StageSelect(int stage)
    {
        // 受け取った引数(stage)のステージをロードする
        SceneManager.LoadScene(stage);
    }
}