using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_6 : MonoBehaviour
{
    public Game_6e gameover_6;

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
            Game_6e.GameOverShowPanel();
        }
    }
}
