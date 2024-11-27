using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player_1: MonoBehaviour
{
    float speed = 3f;   // 横に移動する速度。初期速度。
    float jumpP = 5f; // ジャンプ力

     Rigidbody2D rbody; // リジッドボディを使うための宣言

    public static bool  IsCountDown { get; set; }
    public static TextMeshProUGUI countDownText;
    private Vector2 pos;
    
    //GameObject gg;
    //Pauser pp;


    // Start is called before the first frame update
    void Start()
    {
        //gg = GameObject.Find("neko-player");
        //pp = gg.GetComponent<Pauser>();
        
        // リジッドボディ2Dをコンポーネントから取得して変数に入れる
        rbody = GetComponent<Rigidbody2D>();
        //StartCoroutine(Stop3());
        //初期速度を設定する
        rbody.velocity = transform.forward * speed;
        StartCoroutine(Stop3());
    }

    // Update is called once per frame
    void Update()
    {
       /* if(pos.x <= -33)
        {
            StartCoroutine(Stop3s());
            Transform transform_this = this.GetComponent<Transform>();
            pos = new Vector2(-33f, -6f);
            transform_this.position = pos;
        }*/
        // ジャンプをするためのコード（もしスペースキーが押されて、上方向に速度がない時に）
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            //Rayを発射！
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            //Objectがない or あったとしてもUIオブジェクト出なければ画面クリックとして認識
            if (!hit2D || hit2D.transform.gameObject.tag != "PauseTag")
            {
                // リジッドボディに力を加える（上方向にジャンプ力をかける）
                rbody.AddForce(Vector2.up * jumpP, ForceMode2D.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        //リジッドボディに一定の速度を入れる（横移動の速度, リジッドボディのyの速度）
        rbody.velocity = new Vector2(speed, rbody.velocity.y);
        //Debug.Log(rbody.velocity);
    }
    IEnumerator Stop3()
    {
        enabled = false ;
        yield return new WaitForSeconds(3);
        enabled = true ;
    }
    /*IEnumerator Stop3s()
    {
        //Pauser.OnPause();
        Pauser.Pause();
        yield return new WaitForSeconds(3);
        Debug.Log("Hello");
        Pauser.Resume();
        //Pauser.Resume();
    }*/
   /* public static IEnumerator CountDown1()
    {
        enabled = false;
        countDownText.gameObject.SetActive(true);
        //ここから五秒経過毎に数字を更新

        countDownText.text = "3";
        yield return new WaitForSeconds(1f);
        countDownText.text = "2";
        yield return new WaitForSeconds(1f);
        countDownText.text = "1";
        yield return new WaitForSeconds(1f);
        countDownText.text = "Start!!!";
        IsCountDown = false;
        enabled = true;
        yield return new WaitForSeconds(0.5f);
        countDownText.gameObject.SetActive(false);
    }
    public static void CountDown2()
    {
        StartCoroutine(CountDown1());
    }
   */
}