using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_1 : MonoBehaviour
{
    public Game_1e gameover_1;

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
            Game_1e.GameOverShowPanel();
        }
    }
}