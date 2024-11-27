using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseAllB_9 : MonoBehaviour
{
    PauseC pauseC;
    GameObject obj;
    public player_9 player;
    GameObject neko;
    Pauser neko2;

    //カウントダウン中はどうか
    public bool IsCountDown { get; set; }
    //カウントダウン数字を表示するテキスト
    public TextMeshProUGUI countDownText;


    // Start is called before the first frame update
    void Start()
    {
        countDownText = GameObject.Find("CountDownText").GetComponent<TextMeshProUGUI>();
        obj = GameObject.Find("neko-player");
        player = obj.GetComponent<player_9>();
        neko = GameObject.Find("neko-player");
        neko2 = neko.GetComponent<Pauser>();

    }

    public void close()//closeボタンが押されたとき
    {
        //player_1.catstop();
        Time.timeScale = 1;
        PauseC.pausecancel();
        IsCountDown = true;
        //player_1.CountDown2();


        countDownText.gameObject.SetActive(true);
        StartCoroutine(CountDown());

    }
    public void restart9()
    {
        SceneManager.LoadScene("Stage_9");
    }

    public void home()
    {
        SceneManager.LoadScene("StartScene");
    }
    //カウントダウン表示
    IEnumerator CountDown()
    {
        //ここから五秒経過毎に数字を更新

        countDownText.text = "3";
        yield return new WaitForSeconds(1f);
        countDownText.text = "2";
        yield return new WaitForSeconds(1f);
        countDownText.text = "1";
        yield return new WaitForSeconds(1f);
        countDownText.text = "Start!!!";
        IsCountDown = false;
        Pauser.Resume();
        yield return new WaitForSeconds(0.5f);
        countDownText.gameObject.SetActive(false);
    }
}
