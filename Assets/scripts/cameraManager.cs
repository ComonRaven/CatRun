using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    public GameObject target;   //�Ǐ]����吳�����߂�ϐ�
    Vector3 pos;                //�J�����̏����T���L�����邽�߂̕ϐ�

    // Start is called before the first frame update
    void Start()
    {
        pos = Camera.main.gameObject.transform.position; //�J�����̏����ʒu��ϐ�pos�ɓ����
    }

    // Update is called once per frame
    void Update()
    {
    
        Vector3 cameraPos = target.transform.position;     //cameraPos�Ƃ����ϐ������A�Ǐ]����Ώۂ̈ʒu������
        
        //�����Ώۂ̉��ʒu���O��菬�����ꍇ
        if(target.transform.position.x < 0)
        {
            cameraPos.x = 0;    //�J�����̉��ʒu��0������
        }

        //�����Ώۂ̏c�ʒu��0��菬�����ꍇ
        if(target.transform.position.y < 0)
        {
            cameraPos.y = 0;    //�J�����̏c�ʒu�ɂO������
        }

        //�����Ώۂ̏c�ʒu���O���傫���ꍇ
        if(target.transform.position.y > 0)
        {
            cameraPos.y = 0 ;     //�J�����̏c�ʒu�ɑΏۂ̈ʒu������
        }

        cameraPos.z = -10;
        Camera.main.gameObject.transform.position = cameraPos; //�J�����̈ʒu�ɕϐ�cameraPos�̈ʒu������
    }
}
