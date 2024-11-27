using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseT : MonoBehaviour
{
    public  static Canvas PauseCanvas;

    private void Awake()
    {
        //canvasコンポーネント取得
        PauseCanvas = GetComponent<Canvas>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PauseStart()
    {
        PauseCanvas.enabled = true;
    }
}
