using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player_1: MonoBehaviour
{
    float speed = 3f;   // ���Ɉړ����鑬�x�B�������x�B
    float jumpP = 5f; // �W�����v��

     Rigidbody2D rbody; // ���W�b�h�{�f�B���g�����߂̐錾

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
        
        // ���W�b�h�{�f�B2D���R���|�[�l���g����擾���ĕϐ��ɓ����
        rbody = GetComponent<Rigidbody2D>();
        //StartCoroutine(Stop3());
        //�������x��ݒ肷��
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
        // �W�����v�����邽�߂̃R�[�h�i�����X�y�[�X�L�[��������āA������ɑ��x���Ȃ����Ɂj
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            //Ray�𔭎ˁI
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            //Object���Ȃ� or �������Ƃ��Ă�UI�I�u�W�F�N�g�o�Ȃ���Ή�ʃN���b�N�Ƃ��ĔF��
            if (!hit2D || hit2D.transform.gameObject.tag != "PauseTag")
            {
                // ���W�b�h�{�f�B�ɗ͂�������i������ɃW�����v�͂�������j
                rbody.AddForce(Vector2.up * jumpP, ForceMode2D.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        //���W�b�h�{�f�B�Ɉ��̑��x������i���ړ��̑��x, ���W�b�h�{�f�B��y�̑��x�j
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
        //��������ܕb�o�ߖ��ɐ������X�V

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