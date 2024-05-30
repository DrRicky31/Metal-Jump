using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static float speed = 6f;

    public static bool gameover;

    float spawnTimerEnemy1;
    float spawnRateEnemy1;
    public GameObject ostacolo;

    float spawnTimerAmmoBox;
    float spawnRateAmmoBox;
    public GameObject ammoBox;

    float spawnTimerTower;
    float spawnRateTower;
    public GameObject tower;

    float spawnTimerHelp;
    float spawnRateHelp;
    public GameObject help;

    public GameObject leaderboard;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnRateEnemy1 = Random.Range(25/speed, 40/speed);
        spawnRateAmmoBox = Random.Range(165/speed, 195/speed);
        spawnRateTower = Random.Range(30/speed, 54/speed);
        spawnRateHelp = Random.Range(132/speed, 162/speed);


        if (!gameover)
        {
            //spawn enemy1
            spawnTimerEnemy1 += Time.deltaTime;
            if (spawnTimerEnemy1 >= spawnRateEnemy1)
            {
                spawnTimerEnemy1 -= spawnRateEnemy1;
                Vector2 spawnPos = new Vector2(12f, -2.24f);
                Instantiate(ostacolo, spawnPos, Quaternion.identity);
            }

            //spawn ammoBox
            spawnTimerAmmoBox += Time.deltaTime;
            if (spawnTimerAmmoBox >= spawnRateAmmoBox)
            {
                spawnTimerAmmoBox -= spawnRateAmmoBox;
                Vector2 spawnPosAmmoBox = new Vector2(12f, -2.17f);
                Instantiate(ammoBox, spawnPosAmmoBox, Quaternion.identity);
            }

            //spawn tower
            spawnTimerTower += Time.deltaTime;
            if (spawnTimerTower >= spawnRateTower)
            {
                spawnTimerTower -= spawnRateTower;
                Vector2 spawnPosTower = new Vector2(12f, 1.25f);
                Instantiate(tower, spawnPosTower, Quaternion.identity);
            }

            //spawn helping man
            spawnTimerHelp += Time.deltaTime;
            if (spawnTimerHelp >= spawnRateHelp)
            {
                spawnTimerHelp -= spawnRateHelp;
                Vector2 spawnPosHelp = new Vector2(12f, -2.16f);
                Instantiate(help, spawnPosHelp, Quaternion.identity);
            }

        }


        //gestione leaderboard
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }

        }

        if(gameover)
        {
            leaderboard.SetActive(true);
        }

        //gestione velocità
        if (Punti.punti >= 300)
            speed = 6f+(Punti.punti/500);
    }
}
