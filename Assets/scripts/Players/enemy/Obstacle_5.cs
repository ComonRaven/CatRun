using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_5 : MonoBehaviour
{
    public Game_5e gameover_5;

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
            Game_5e.GameOverShowPanel();
        }
    }
}
