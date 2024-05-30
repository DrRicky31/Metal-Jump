using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void clickRestart()
    {
        Player.ammo = Player.startAmmo;
        GameController.gameover = false;
        Punti.punti = 0;
        GameController.speed = 6f;
        SceneManager.LoadScene(1);
    }

    public void clickStart()
    {
        Player.ammo = Player.startAmmo;
        GameController.gameover = false;
        Punti.punti = 0;
        GameController.speed = 6f;
        SceneManager.LoadScene(1);
    }
}
