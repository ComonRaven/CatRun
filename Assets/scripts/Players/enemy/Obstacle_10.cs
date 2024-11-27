using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_10 : MonoBehaviour
{
    public Game_10e gameover_10;

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
            Game_10e.GameOverShowPanel();
        }
    }
}
