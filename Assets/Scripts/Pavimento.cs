using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pavimento : MonoBehaviour
{
    private Vector2 posIniziale;

    // Start is called before the first frame update
    void Start()
    {
        posIniziale.y = transform.position.y;
        posIniziale.x = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.gameover)
        {
            if (transform.position.x >= -4.47f)
                transform.position = new Vector2(transform.position.x - GameController.speed * Time.deltaTime, transform.position.y);
            else
                transform.position = posIniziale;
        }
    }
}
