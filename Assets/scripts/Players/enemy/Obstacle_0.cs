using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle_0 : MonoBehaviour
{
    

    GameObject pb;
    // Start is called before the first frame update
    void Start()
    {
        pb = GameObject.Find("PauseButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pb.SetActive(false);
            SceneManager.LoadScene("Tutorial");
        }
    }
}
