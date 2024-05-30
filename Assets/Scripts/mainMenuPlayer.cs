using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuPlayer : MonoBehaviour
{
    public GameObject frame0;
    public GameObject frame1;
    private bool framechoise;
    private float timeRate = 0.1f;
    private float timeSlot;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(-20f, -2.66f);
    }

    // Update is called once per frame
    void Update()
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

        if (transform.position.x >= 30f)
            transform.position = new Vector2(-30f, transform.position.y);

        transform.position = new Vector2(transform.position.x + 9f * Time.deltaTime, transform.position.y);


        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }

        }

    }
}
