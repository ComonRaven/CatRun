using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_7 : MonoBehaviour
{
    public Game_7e gameover_7;

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
            Game_7e.GameOverShowPanel();
        }
    }
}
