using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public const int ammoMax = 30;
    public const int startAmmo = 15;
    public static int ammo = startAmmo;

    public GameObject frame0;
    public GameObject frame1;
    private bool framechoise;
    private float timeRate = 0.2f;
    private float timeSlot;

    Rigidbody2D rb;
    public GameObject pavimento;
    public GameObject gameover;

    private int jumpLimit;

    public AudioClip[] audioClips;
    AudioSource audioSource;

    public GameObject newPoints;

    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
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

            if (IsGrounded())
            {
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
            }
            else
            {
                frame1.SetActive(true);
                frame0.SetActive(false);
            }
        }
    }

    private bool IsGrounded()
    {
        return transform.position.y <= -1.75f;
    }

    //Gestione collisione
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collisione per gameover
        if (collision.gameObject != pavimento && collision.gameObject != frame0 && collision.gameObject != frame1 &&
            collision.gameObject.tag != "ammoBox" && collision.gameObject.tag != "helpingMan")
        {
            GameController.gameover = true;
            audioSource.PlayOneShot(audioClips[1]);
            gameover.transform.position = transform.position;
            gameover.SetActive(true);
            frame0.SetActive(false);
            frame1.SetActive(false);
        }

        //collisione per ammobox
        if(collision.gameObject.tag == "ammoBox")
        {
            if ((ammo + startAmmo) >= ammoMax)
                ammo = ammoMax;
            else 
                ammo += startAmmo;

            audioSource.PlayOneShot(audioClips[0]);
            Destroy(collision.gameObject);
        }

        //collisione per helpingMan
        if (collision.gameObject.tag == "helpingMan")
        {
            Punti.punti += 75;
            NewPoints.points = 75;
            Instantiate(newPoints, collision.gameObject.transform.position, Quaternion.identity);
            audioSource.PlayOneShot(audioClips[2]);
            Destroy(collision.gameObject);
        }
    }
}
