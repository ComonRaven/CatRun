using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_2g : MonoBehaviour
{
    private static Canvas gameClearCanvas;

    private void Awake()
    {
        //canvasコンポーネント取得
        gameClearCanvas = GetComponent<Canvas>();
    }
    //パネルを開く用の関数 static呼びたし可能
    public static void GameClearShowPanel()
    {
        //ゲーム内の時間を止める
        Time.timeScale = 0f;
        //GameOverCanvasのCanvasのチェックをデフォルトで外すと関数が呼ばれた時にtrueになる
        //(衝突した時に表示される)
        gameClearCanvas.enabled = true;
    }
    //StartSceneに戻る
    public static void reHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }
    //次のシーンに移動
    public static void NextStage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage_3");
    }
}
