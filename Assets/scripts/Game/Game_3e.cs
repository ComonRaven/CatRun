using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_3e : MonoBehaviour
{
    private static Canvas gameOverCanvas;

    private void Awake()
    {
        //canvas�R���|�[�l���g�擾
        gameOverCanvas = GetComponent<Canvas>();
    }
    //�p�l�����J���p�̊֐� static�Ăт����\
    public static void GameOverShowPanel()
    {
        //�Q�[�����̎��Ԃ��~�߂�
        Time.timeScale = 0f;
        //GameOverCanvas��Canvas�̃`�F�b�N���f�t�H���g�ŊO���Ɗ֐����Ă΂ꂽ����true�ɂȂ�
        //(�Փ˂������ɕ\�������)
        gameOverCanvas.enabled = true;
    }
    //�Q�[�����ăX�^�[�g����֐�(Stage3����)
    public static void ReStartGame()
    {
        //�~�߂��Q�[�����̎��Ԃ�߂�
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage_3");
    }
    //StartScene�ɖ߂�
    public static void reHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }
}
