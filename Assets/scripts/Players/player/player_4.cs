using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_4 : MonoBehaviour
{
    public float speed = 5f;   // 横に移動する速度。初期速度。
    public float jumpP = 5f; // ジャンプ力
    //Collider Terrain_enemy; //Terrain-enemyのあたり判定を無効にしたい設定
    private float rotationDuration = 5f;
    private float rotationSpeed = 5f;

    Rigidbody2D rbody; // リジッドボディを使うための宣言

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Stop3());
        // リジッドボディ2Dをコンポーネントから取得して変数に入れる
        rbody = GetComponent<Rigidbody2D>();
        //初期速度を設定する
        rbody.velocity = transform.forward * speed;
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
        /*       if(collision.gameObject.tag == "Transmission")
               {
                   //StartCoroutine(DisableCollisionCoroutine());
                 StartCoroutine(judge());  
               } */

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

    /* IEnumerator judge()
       {
           Perfect_judge = 1; //あたり判定を一時的になしにする
           yield return new WaitForSeconds(5f);
           Perfect_judge = 0; 
       } */
    IEnumerator rolling(Rigidbody2D rbody)//ローリングする
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
