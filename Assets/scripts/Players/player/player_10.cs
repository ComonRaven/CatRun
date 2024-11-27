using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_10 : MonoBehaviour
{
    public float speed = 6f;   // 横に移動する速度。初期速度。
    public float jumpP = 6.2f; // ジャンプ力
    private float rotationDuration = 5f;
    private float rotationSpeed = 5f;
    Rigidbody2D rbody; // リジッドボディを使うための宣言
    float originalspeed;
    float originaljumpP;
    float FirstPosx = -14;  //Posx=-36の時 d=22
    float SecondPosx = 138; //Posx=116の時 d=22
    float ThirdPosx = 379;  //Posx=357の時 d=22
    float ForthPosx = 430;  //Posx=408の時 d=22
    float FifthPosx = 472;  //Posx=460の時 d=22
    float SixthPosx = 512;  //Posx=490の時 d=22
    float SeventhPosx = 552;  //Posx=530の時 d=22
    float EighthPoax = 597;  //Posx=575の時 d=22

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Stop3());
        // リジッドボディ2Dをコンポーネントから取得して変数に入れる
        rbody = GetComponent<Rigidbody2D>();
        //初期速度を設定する
        rbody.velocity = transform.forward * speed;

        originaljumpP = jumpP;
        originalspeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        // ジャンプをするためのコード（もしスペースキーが押されて、上方向に速度がない時に）
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // リジッドボディに力を加える（上方向にジャンプ力をかける）
            rbody.AddForce(Vector2.up * jumpP, ForceMode2D.Impulse);
        }
        //第一ステージのspeedとjumpP
        if(transform.position.x > FirstPosx && transform.position.x < SecondPosx)
        {
            speed = 6f;
            jumpP = 6f;
        }
        //第二ステージのspeedとjumpP
        if(transform.position.x > SecondPosx && transform.position.x < ThirdPosx)
        {
            speed = 5f;
            jumpP = 5f;
        }
        //第三ステージの第一ブロックのspeedとjumpP
        if(transform.position.x > ThirdPosx && transform.position.x < ForthPosx)
        {
            speed = 6f;
            jumpP = 6.2f;
        }
        //第三ステージの第二ブロックのspeedとjumpP
        if(transform.position.x > ForthPosx && transform.position.x < FifthPosx)
        {
            speed = 10f;
            jumpP = 3f;
        }
        //第三ステージの第三ブロックのspeedとjumpP
        if(transform.position.x > FifthPosx && transform.position.x < SixthPosx)
        {
            speed = 15f;
            jumpP = 3f;
        }
        //第三ステージの第四ブロックのspeedとjumpP
        if(transform.position.x > SixthPosx && transform.position.x < SeventhPosx)
        {
            speed = 10f;
            jumpP = 3f;
        }
        //第三ステージの第五ブロックのspeedとjumpp
        if(transform.position.x > SeventhPosx && transform.position.x < EighthPoax)
        {
            speed = 6f;
            jumpP = 6.2f;
        }
        if(transform.position.x > EighthPoax)
        {
            speed = originalspeed;
            jumpP = originaljumpP;
        }
    }
    private void FixedUpdate()
    {
        //リジッドボディに一定の速度を入れる（横移動の速度, リジッドボディのyの速度）
        rbody.velocity = new Vector2(speed, rbody.velocity.y);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fire_Trap")
        {
            StartCoroutine(ApplyTemporarySpeed());
        }

        if (collision.gameObject.name == "Transition")
        {
            rbody = GetComponent<Rigidbody2D>();
            StartCoroutine(rolling(rbody));
        }
    }
    IEnumerator ApplyTemporarySpeed()
    {
        float originalSpeed = speed; //元の速度を保持
        speed *= 1.15f;  //速度を1.15倍に変更

        yield return new WaitForSeconds(2f); //２秒間待つ

        speed = originalSpeed; //元の速度に戻す
    }

    IEnumerator rolling(Rigidbody2D rbody)
    {
        float elapsedTime = 0f;
        Quaternion initialRotation = rbody.transform.rotation;
        while (elapsedTime < rotationDuration)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            rbody.transform.Rotate(Vector2.up, rotationAmount);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        rbody.transform.rotation = initialRotation;
    }
    IEnumerator Stop3()//カウントダウン時にネコが動かないようにする
    {
        enabled = false;
        //rbody.velocity = Vector2.zero;
        yield return new WaitForSeconds(3);
        enabled = true;
    }
}
