using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private bool shot;
    public GameObject bulletNem;
    AudioSource shotSound;

    // Start is called before the first frame update
    void Start()
    {
        shot = false;
        shotSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.gameover)
        {
            transform.position = new Vector2(transform.position.x - GameController.speed * Time.deltaTime, transform.position.y);
            
            if(transform.position.x <= 2.95f && !shot)
            {
                Vector2 pos = new Vector2(1.2f, 1.76f);
                Instantiate(bulletNem, pos, Quaternion.identity);
                shot = true;
                shotSound.Play();
            }

            
            if (transform.position.x <= -13f)
            {
                Destroy(gameObject);
            }
        }
    }
}
