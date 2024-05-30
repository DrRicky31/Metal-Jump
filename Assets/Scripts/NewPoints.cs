using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPoints : MonoBehaviour
{
    private float despawnTime;
    public static int points;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        despawnTime = 1.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (points > 0)
            GetComponent<Text>().color = Color.white;
        else
            GetComponent<Text>().color = Color.red;
        
        if(!GameController.gameover)
            transform.position = new Vector2(transform.position.x - GameController.speed * Time.deltaTime, transform.position.y + Time.deltaTime);

        GetComponent<Text>().text = "+" + points.ToString();
        despawnTime -= Time.deltaTime;
        if (despawnTime <= 0)
            Destroy(canvas);
    }
}
