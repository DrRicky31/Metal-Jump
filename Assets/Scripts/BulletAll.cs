using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletAll : MonoBehaviour
{
    public GameObject deadTower;
    public GameObject deadEnemy1;
    public GameObject newPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.gameover)
        {

            transform.position = new Vector2(transform.position.x + 20f * Time.deltaTime, transform.position.y);
            if (transform.position.x >12f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //colpito nemico 1
        if (collision.gameObject.tag == "enemy1")
        {
            Vector2 pos = new Vector2(collision.gameObject.transform.position.x,
                   collision.gameObject.transform.position.y - 0.44f);
            Instantiate(deadEnemy1, pos, Quaternion.identity);

            Destroy(gameObject);
            Destroy(collision.gameObject);

            NewPoints.points = 20;
            Instantiate(newPoints, pos, Quaternion.identity);
            Punti.punti += 20;
        }

        //colpita torre
        if (collision.gameObject.tag == "tower")
        {
            Instantiate(deadTower, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);

            NewPoints.points = 30;
            Instantiate(newPoints, collision.gameObject.transform.position, Quaternion.identity);
            Punti.punti += 30;
        }

        //colpito helping man
        if (collision.gameObject.tag == "helpingMan")
        {
            Instantiate(deadEnemy1, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);

            NewPoints.points =-100;
            Instantiate(newPoints, collision.gameObject.transform.position, Quaternion.identity);
            Punti.punti-=100;
        }
    }
}
