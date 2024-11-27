using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal_2 : MonoBehaviour
{
    public Game_2g gameclear_2;

    GameObject pb;

    void Start()
    {
        pb = GameObject.Find("PauseButton");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || gameObject.transform.position.x > 100)
        {
            pb.SetActive(false);
            int stageUnlock = PlayerPrefs.GetInt("StageUnlock");
            int NextScene = SceneManager.GetActiveScene().buildIndex + 1;
            if(NextScene == 6)
            {
                PlayerPrefs.SetInt("StageUnlock", NextScene - 3);
            }
            Game_2g.GameClearShowPanel();
        }
    }
}