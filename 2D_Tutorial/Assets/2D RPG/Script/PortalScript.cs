using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PortalScript : MonoBehaviour
{
    // Start is called before the first frame update
    Tilemap portal;
    int randR;
    int randG;
    int randB;
    float timer;
    float waitingTime;

    void Start()
    {
        timer = 0.0f;
        waitingTime = 0.2f;

        portal = gameObject.GetComponent<Tilemap>();
        Debug.Log(portal.color);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            changeColor();
            timer = 0;
        }
    }

    void changeColor()
    {
        randR = Random.Range(50, 250);  
        randG = Random.Range(50, 250);
        randB = Random.Range(50, 250);
        portal.color = new Color(randR / 255f, randG / 255f, randB / 255f, 1f);
    }
}
