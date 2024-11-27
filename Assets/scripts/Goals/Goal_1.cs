using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal_1 : MonoBehaviour
{
    public Game_1g gameclear_1;

    GameObject pb;

    void Start()
    {
        pb = GameObject.Find("PauseButton");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pb.SetActive(false);
            int stageUnlock = PlayerPrefs.GetInt("StageUnlock");
            int NextScene = SceneManager.GetActiveScene().buildIndex + 1;
            if(NextScene == 5)
            {
                PlayerPrefs.SetInt("StageUnlock",NextScene - 3);
            }
            Game_1g.GameClearShowPanel();
            //Debug.Log(PlayerPrefs.GetInt("StageUnlock"));
        }
    }
}