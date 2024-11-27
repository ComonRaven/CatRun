using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_3 : MonoBehaviour
{
    public Game_3e gameover_3;

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
            Game_3e.GameOverShowPanel();
        }
    }
}