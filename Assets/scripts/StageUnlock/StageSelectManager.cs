using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    // �{�^����z��Ƃ��Ē�`
    [SerializeField] private Button[] stageButton;

    void Start()
    {
        //�X�e�[�W�̃N���A���̏����l���P�ɂ���
        // PlayerPrefs.SetInt("StageUnlock", 1);
        //�ۑ�
        // PlayerPrefs.Save();
        int stageunlock = PlayerPrefs.GetInt("StageUnlock");
        if(stageunlock < 1)
        {
            PlayerPrefs.SetInt("StageUnlock", 1);
        }
    }
    void Update()
    {
        // �X�e�[�W�̃N���A�����擾
        int stageUnlock = PlayerPrefs.GetInt("StageUnlock");

        // �X�e�[�W�{�^���̕\���E��\���̐ݒ�
        for (int i = 0; i < stageButton.Length; i++)
        {
            if (i < stageUnlock) { 
                stageButton[i].interactable = true; 
            }
            else
            {
                stageButton[i].interactable = false;
            }
            //Debug.Log(i);
            //Debug.Log(stageUnlock);
            //Debug.Log(PlayerPrefs.GetInt("StageUnlock"));
        }
    }
    public void StageSelect(int stage)
    {
        // �󂯎��������(stage)�̃X�e�[�W�����[�h����
        SceneManager.LoadScene(stage);
    }
}