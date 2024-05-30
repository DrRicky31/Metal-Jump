using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public GameObject frame0;
    public GameObject frame1;
    private bool framechoise;
    private float timeRate = 0.7f;
    private float timeSlot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!GameController.gameover)
        {
            //gestione animazione
            timeSlot += Time.deltaTime;
            if (timeSlot >= timeRate)
            {
                framechoise = !framechoise;
                timeSlot -= timeRate;
            }

            if (framechoise)
            {
                frame0.SetActive(true);
                frame1.SetActive(false);
            }
            else
            {
                frame1.SetActive(true);
                frame0.SetActive(false);
            }

            //spostamento verso sinistra
            transform.position = new Vector2(transform.position.x - GameController.speed * Time.deltaTime, transform.position.y);
        }

        if (transform.position.x <= -13f)
        {
            Destroy(gameObject);
        }

    }
}
