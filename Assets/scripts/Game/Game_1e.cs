using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_1e : MonoBehaviour
{
    private static Canvas gameOverCanvas;


    private void Awake()
    {
        //canvasコンポーネント取得
        gameOverCanvas = GetComponent<Canvas>();
    }

    //パネルを開く用の関数 static呼びたし可能
    public static void GameOverShowPanel()
    {
        //ゲーム内の時間を止める
        Time.timeScale = 0f;
        //GameOverCanvasのCanvasのチェックをデフォルトで外すと関数が呼ばれた時にtrueになる
        //(衝突した時に表示される)
        gameOverCanvas.enabled = true;
    }
   /* public static void GameClearShowPanel()
    {
        //ゲーム内の時間を止める
        Time.timeScale = 0f;
        //GameOverCanvasのCanvasのチェックをデフォルトで外すと関数が呼ばれた時にtrueになる
        //(衝突した時に表示される)
        gameClearCanvas.enabled = true;
    } */
    //ゲームを再スタートする関数(Stage1から)
    public static void ReStartGame()
    {
        //止めたゲーム内の時間を戻す
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage_1");
    }
    //StartSceneに戻る
    public static void reHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }
/*    public static void NextStage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage_2");
    } */
}
