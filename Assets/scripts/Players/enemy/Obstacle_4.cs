using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_4 : MonoBehaviour
{
    public Game_4e gameover_4;

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
            Game_4e.GameOverShowPanel();
        }
    }
}