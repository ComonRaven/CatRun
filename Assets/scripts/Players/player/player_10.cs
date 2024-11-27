using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_10 : MonoBehaviour
{
    public float speed = 6f;   // ���Ɉړ����鑬�x�B�������x�B
    public float jumpP = 6.2f; // �W�����v��
    private float rotationDuration = 5f;
    private float rotationSpeed = 5f;
    Rigidbody2D rbody; // ���W�b�h�{�f�B���g�����߂̐錾
    float originalspeed;
    float originaljumpP;
    float FirstPosx = -14;  //Posx=-36�̎� d=22
    float SecondPosx = 138; //Posx=116�̎� d=22
    float ThirdPosx = 379;  //Posx=357�̎� d=22
    float ForthPosx = 430;  //Posx=408�̎� d=22
    float FifthPosx = 472;  //Posx=460�̎� d=22
    float SixthPosx = 512;  //Posx=490�̎� d=22
    float SeventhPosx = 552;  //Posx=530�̎� d=22
    float EighthPoax = 597;  //Posx=575�̎� d=22

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Stop3());
        // ���W�b�h�{�f�B2D���R���|�[�l���g����擾���ĕϐ��ɓ����
        rbody = GetComponent<Rigidbody2D>();
        //�������x��ݒ肷��
        rbody.velocity = transform.forward * speed;

        originaljumpP = jumpP;
        originalspeed = speed;
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
        //���X�e�[�W��speed��jumpP
        if(transform.position.x > FirstPosx && transform.position.x < SecondPosx)
        {
            speed = 6f;
            jumpP = 6f;
        }
        //���X�e�[�W��speed��jumpP
        if(transform.position.x > SecondPosx && transform.position.x < ThirdPosx)
        {
            speed = 5f;
            jumpP = 5f;
        }
        //��O�X�e�[�W�̑��u���b�N��speed��jumpP
        if(transform.position.x > ThirdPosx && transform.position.x < ForthPosx)
        {
            speed = 6f;
            jumpP = 6.2f;
        }
        //��O�X�e�[�W�̑��u���b�N��speed��jumpP
        if(transform.position.x > ForthPosx && transform.position.x < FifthPosx)
        {
            speed = 10f;
            jumpP = 3f;
        }
        //��O�X�e�[�W�̑�O�u���b�N��speed��jumpP
        if(transform.position.x > FifthPosx && transform.position.x < SixthPosx)
        {
            speed = 15f;
            jumpP = 3f;
        }
        //��O�X�e�[�W�̑�l�u���b�N��speed��jumpP
        if(transform.position.x > SixthPosx && transform.position.x < SeventhPosx)
        {
            speed = 10f;
            jumpP = 3f;
        }
        //��O�X�e�[�W�̑�܃u���b�N��speed��jumpp
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
        //���W�b�h�{�f�B�Ɉ��̑��x������i���ړ��̑��x, ���W�b�h�{�f�B��y�̑��x�j
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
        float originalSpeed = speed; //���̑��x��ێ�
        speed *= 1.15f;  //���x��1.15�{�ɕύX

        yield return new WaitForSeconds(2f); //�Q�b�ԑ҂�

        speed = originalSpeed; //���̑��x�ɖ߂�
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
    IEnumerator Stop3()//�J�E���g�_�E�����Ƀl�R�������Ȃ��悤�ɂ���
    {
        enabled = false;
        //rbody.velocity = Vector2.zero;
        yield return new WaitForSeconds(3);
        enabled = true;
    }
}
