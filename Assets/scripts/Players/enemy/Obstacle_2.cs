using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_2 : MonoBehaviour
{
    public Game_2e gameover_2;

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
            Game_2e.GameOverShowPanel();
        }
    }
}