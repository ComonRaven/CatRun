using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_8 : MonoBehaviour
{
    public Game_8e gameover_8;

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
            Game_8e.GameOverShowPanel();
        }
    }
}
