using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_7 : MonoBehaviour
{
    public float speed = 6f;   // ���Ɉړ����鑬�x�B�������x�B
    public float jumpP = 6.2f; // �W�����v��
    float FirstPosx = 69f; //x=47�̎�     �����W�̂Ƃ̌덷=22
    float SecondPosx = 132f; //x=110�̎�
    float originalspeed;
    float originaljumpP;

    Rigidbody2D rbody; // ���W�b�h�{�f�B���g�����߂̐錾

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Stop3());
        // ���W�b�h�{�f�B2D���R���|�[�l���g����擾���ĕϐ��ɓ����
        rbody = GetComponent<Rigidbody2D>();
        //�������x��ݒ肷��
        rbody.velocity = transform.forward * speed;
        originalspeed = speed;
        originaljumpP = jumpP;
    }

    // Update is called once per frame
    void Update()
    {
        // �W�����v�����邽�߂̃R�[�h�i�����X�y�[�X�L�[��������āA������ɑ��x���Ȃ����Ɂj
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // ���W�b�h�{�f�B�ɗ͂�������i������ɃW�����v�͂�������j
            rbody.AddForce(Vector2.up * jumpP, ForceMode2D.Impulse);
        }

        //FirstPosx���z�����瑬�x�ƃW�����v�͂����ꂼ��ς���
        if (transform.position.x > FirstPosx && transform.position.x < SecondPosx)
        {
            speed = 10f;
            jumpP = 3f;
        }
        //SecondPosx���z�����猳�̑��x�ƃW�����v�͂ɖ߂�
        if (transform.position.x >= SecondPosx)
        {
            speed = originalspeed;
            jumpP = originaljumpP;
        }

    }
    private void FixedUpdate()
    {
        //���W�b�h�{�f�B�Ɉ��̑��x������i���ړ��̑��x, ���W�b�h�{�f�B��y�̑��x�j
        rbody.velocity = new Vector2(speed, rbody.velocity.y);
    }
    IEnumerator Stop3()//�J�E���g�_�E�����Ƀl�R�������Ȃ��悤�ɂ���
    {
        enabled = false;
        //rbody.velocity = Vector2.zero;
        yield return new WaitForSeconds(3);
        enabled = true;
    }
}
