using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_4 : MonoBehaviour
{
    public float speed = 5f;   // ���Ɉړ����鑬�x�B�������x�B
    public float jumpP = 5f; // �W�����v��
    //Collider Terrain_enemy; //Terrain-enemy�̂����蔻��𖳌��ɂ������ݒ�
    private float rotationDuration = 5f;
    private float rotationSpeed = 5f;

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
        float originalSpeed = speed; //���̑��x��ێ�
        speed *= 1.15f;  //���x��1.15�{�ɕύX

        yield return new WaitForSeconds(2f); //�Q�b�ԑ҂�

        speed = originalSpeed; //���̑��x�ɖ߂�
    }

    /* IEnumerator judge()
       {
           Perfect_judge = 1; //�����蔻����ꎞ�I�ɂȂ��ɂ���
           yield return new WaitForSeconds(5f);
           Perfect_judge = 0; 
       } */
    IEnumerator rolling(Rigidbody2D rbody)//���[�����O����
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
