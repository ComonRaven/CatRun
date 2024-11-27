using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal_9 : MonoBehaviour
{
    public Game_9g gameclear_9;

    GameObject pb;

    void Start()
    {
        pb = GameObject.Find("PauseButton");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pb.SetActive(false);
            int stageUnlock = PlayerPrefs.GetInt("StageUnlock");
            int NextScene = SceneManager.GetActiveScene().buildIndex + 1;
            if (NextScene == 13)
            {
                PlayerPrefs.SetInt("StageUnlock", NextScene - 3);
            }
            Game_9g.GameClearShowPanel();
        }
    }
}
