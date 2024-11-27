using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_0 : MonoBehaviour
{
    public Game_0g gameclear_1;
    GameObject pb;
    // Start is called before the first frame update
    void Start()
    {
        pb = GameObject.Find("PauseButton");   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pb.SetActive(false);
            Game_0g.GameClearShowPanel();
        }
    }
}
