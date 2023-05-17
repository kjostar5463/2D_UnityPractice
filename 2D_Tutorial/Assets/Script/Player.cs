using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] RawImage rawImage;

    private void Start()
    {
        StartCoroutine(GetTexture());
    }

    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://cdn.pixabay.com/photo/2014/04/13/20/49/cat-323262_960_720.jpg");

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            rawImage.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
        else
        {
            Debug.Log(www.error);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("2D Ãæµ¹");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
