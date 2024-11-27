using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_0g : MonoBehaviour
{
    private static Canvas gameClearCanvas;
    private void Awake()
    {
        //canvasコンポーネント取得
        gameClearCanvas = GetComponent<Canvas>();
    }
    public static void GameClearShowPanel()
    {
        //ゲーム内の時間を止める
        Time.timeScale = 0f;
        //GameOverCanvasのCanvasのチェックをデフォルトで外すと関数が呼ばれた時にtrueになる
        //(衝突した時に表示される)
        gameClearCanvas.enabled = true;
    }
    public static void reHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }
    public static void NextStage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage_1");
    }
}
