using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.gameover)
        {
            transform.position = new Vector2(transform.position.x - GameController.speed * Time.deltaTime, transform.position.y);

            if (transform.position.x <= -13f)
            {
                Destroy(gameObject);
            }
        }
    }
}
