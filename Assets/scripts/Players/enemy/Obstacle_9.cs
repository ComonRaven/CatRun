using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_9 : MonoBehaviour
{
    public Game_9e gameover_9;

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
            Game_9e.GameOverShowPanel();
        }
    }
}
