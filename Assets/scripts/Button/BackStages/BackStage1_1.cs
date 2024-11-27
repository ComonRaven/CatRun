using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackStage1_1 : MonoBehaviour
{
    public Game_1e gameOver_1;

    public void LoadCurrentScene()
    {
        Game_1e.ReStartGame();
    }
}