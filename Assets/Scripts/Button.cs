using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject bulletAll;
    public GameObject player;
    
    Rigidbody2D rb;
    private int jumpLimit;
    private float jumpDelay;

    public AudioClip[] audioClips;
    AudioSource audioSource;
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
}

    private void Update()
    {
        //verifica che il player sia a terra per azzerare il jumpLimit
        if (IsGrounded() && jumpDelay<=0)
        {
            jumpLimit = 0;
        }

        if (jumpDelay >= 0)
            jumpDelay -= Time.deltaTime;
    }

    //bottone a destra per sparare
    public void clickShoot()
    {
        if (Player.ammo > 0 && !GameController.gameover)
        {
            Vector2 spawnPos = new Vector2(player.transform.position.x + 1f, player.transform.position.y);
            Instantiate(bulletAll, spawnPos, Quaternion.identity);
            Player.ammo--;
            audioSource.PlayOneShot(audioClips[0]);            
        }
        else
        {
            if (Player.ammo <= 0)
                audioSource.PlayOneShot(audioClips[1]);
        }
    }

    //bottone a sinistra per saltare
    public void clickJump()
    {
        if (jumpLimit < 1 && !GameController.gameover)
        {
            rb.velocity = new Vector2(0f, 15f);
            jumpLimit++;
            jumpDelay = 0.5f;
        }
    }

    //verifica se il giocatore è a terra
    private bool IsGrounded()
    {
        return player.transform.position.y <= -1.80f;
    }

}
