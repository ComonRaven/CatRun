using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseObject1 : MonoBehaviour
{
    PauseT pauseobject;
    PauseC pauseobject2;
    GameObject pause_object;
    Pauser pause_script;
    Button button;
    

    // Start is called before the first frame update
    void Start()
    {
        pause_object = GameObject.Find("neko-player");
        pause_script = pause_object.GetComponent<Pauser>();
        button = GameObject.Find("PauseButton").GetComponent<Button>();
        StartCoroutine(Buttone());
        //bcheck = GameObject.Find("neko-player");
    }

    // Update is called once per frame
    void Update()
    {
    /*    if(Pauser.instance.buttoncheck)
        {
            button.enabled = false;
        }*/
    }
    public  void Pause1()
    {
        PauseC.pause100();
        PauseT.PauseStart();
        Pauser.Pause();
    }
    IEnumerator Buttone()
    {
        button.enabled = false;
        yield return new WaitForSeconds(3);
        button.enabled = true;
    }
}
