using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackStage0_2 : MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadScene("Stage_1");
    }
}
