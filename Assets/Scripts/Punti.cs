using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Punti : MonoBehaviour
{

    public static float punti;

    // Start is called before the first frame update
    void Start()
    {
        punti = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.gameover)
        {
            punti += (Time.deltaTime * 3);
        }
        GetComponent<Text>().text = ((int)punti).ToString();
    }
}
