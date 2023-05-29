using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
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
        while (true)
        {
            ObjectPoolManager.Instance.GetQueue();

            yield return new WaitForSeconds(4.0f);
        }
    }

}
