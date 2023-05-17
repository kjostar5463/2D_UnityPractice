using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platform;
    

    void Start()
    {
        // go [   ] <- platform
        //GameObject go = Instantiate(platform); // 0, -0.5, 0
        // go [   ] <- new Vector2(-1.25f, -0.5f)
        //go.transform.position = new Vector2(-1.25f, -0.5f); // -1.25f, -0.5f, 0
        StartCoroutine(SpawnCoroutine());
    }

    

    IEnumerator SpawnCoroutine()
    {
        GameObject newPlatform;

        while (true)
        {
            newPlatform = Instantiate(platform);
            newPlatform.transform.position = new Vector2(-1.25f, -0.5f);

            yield return new WaitForSeconds(3.5f);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
