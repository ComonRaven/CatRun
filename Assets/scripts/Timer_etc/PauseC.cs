using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseC : MonoBehaviour
{
    public static Canvas PauseCanvas;

    private void Awake()
    {
        //canvasコンポーネント取得
        PauseCanvas = GetComponent<Canvas>();
    }

    // Start is called before the first frame update
    void Start()
    {
        PauseCanvas.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void pause100()
    {
        PauseCanvas.enabled = true;
    }
    public static void pausecancel()
    {
        PauseCanvas.enabled = false;
    }

}
