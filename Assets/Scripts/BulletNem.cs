using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNem : MonoBehaviour
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

            transform.position = new Vector2(transform.position.x - 14f * Time.deltaTime, transform.position.y-8f*Time.deltaTime);
            if (transform.position.x > 12f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "pavimento")
            Destroy(gameObject);
    }
}
