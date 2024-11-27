using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_3 : MonoBehaviour
{
    public float speed = 6f;   // ���Ɉړ����鑬�x�B�������x�B
    public float jumpP = 6f; // �W�����v��

    Rigidbody2D rbody; // ���W�b�h�{�f�B���g�����߂̐錾

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Stop3());
        // ���W�b�h�{�f�B2D���R���|�[�l���g����擾���ĕϐ��ɓ����
        rbody = GetComponent<Rigidbody2D>();
        //�������x��ݒ肷��
        rbody.velocity = transform.forward * speed;
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