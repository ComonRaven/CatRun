using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gameMaanger : MonoBehaviour
{
    //カウントダウン中はどうか
    public bool IsCountDown { get; set; }
    //カウントダウン数字を表示するテキスト
    public TextMeshProUGUI countDownText;


    void Start()
    {
        countDownText = GameObject.Find("CountDownText").GetComponent<TextMeshProUGUI>();
        //ゲーム関連初期化
        IsCountDown = true;
        countDownText.gameObject.SetActive(true);
        StartCoroutine(CountDown());
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
        yield return new WaitForSeconds(0.5f);
        countDownText.gameObject.SetActive(false);
    }
}
