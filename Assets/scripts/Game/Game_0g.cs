using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_0g : MonoBehaviour
{
    private static Canvas gameClearCanvas;
    private void Awake()
    {
        //canvas�R���|�[�l���g�擾
        gameClearCanvas = GetComponent<Canvas>();
    }
    public static void GameClearShowPanel()
    {
        //�Q�[�����̎��Ԃ��~�߂�
        Time.timeScale = 0f;
        //GameOverCanvas��Canvas�̃`�F�b�N���f�t�H���g�ŊO���Ɗ֐����Ă΂ꂽ����true�ɂȂ�
        //(�Փ˂������ɕ\�������)
        gameClearCanvas.enabled = true;
    }
    public static void reHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }
    public static void NextStage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage_1");
    }
}
