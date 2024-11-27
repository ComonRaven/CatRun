using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_3 : MonoBehaviour
{
    public float speed = 6f;   // 横に移動する速度。初期速度。
    public float jumpP = 6f; // ジャンプ力

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
    IEnumerator Stop3()//カウントダウン時にネコが動かないようにする
    {
        enabled = false;
        //rbody.velocity = Vector2.zero;
        yield return new WaitForSeconds(3);
        enabled = true;
    }
}