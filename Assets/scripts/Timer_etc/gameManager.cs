using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gameMaanger : MonoBehaviour
{
    //�J�E���g�_�E�����͂ǂ���
    public bool IsCountDown { get; set; }
    //�J�E���g�_�E��������\������e�L�X�g
    public TextMeshProUGUI countDownText;


    void Start()
    {
        countDownText = GameObject.Find("CountDownText").GetComponent<TextMeshProUGUI>();
        //�Q�[���֘A������
        IsCountDown = true;
        countDownText.gameObject.SetActive(true);
        StartCoroutine(CountDown());
    }
    //�J�E���g�_�E���\��
    IEnumerator CountDown()
    {
        //��������ܕb�o�ߖ��ɐ������X�V

        countDownText.text = "3";
        yield return new WaitForSeconds(1f);
        countDownText.text = "2";
        yield return new WaitForSeconds(1f);
        countDownText.text = "1";
        yield return new WaitForSeconds(1f);
        countDownText.text = "Start!!!";
        IsCountDown = false;
        yield return new WaitForSeconds(0.5f);
        countDownText.gameObject.SetActive(false);
    }
}
