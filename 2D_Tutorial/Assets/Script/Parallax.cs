using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    [SerializeField] Rect rect;
    [SerializeField] RawImage rawImage;

<<<<<<< HEAD
    [SerializeField] float speed = 0.5f;
=======
    [SerializeField] float speed = 1.0f;
>>>>>>> 29fefffeaf9ae2055258eecb2c9631d82c5656e1

    // Update is called once per frame
    void Update()
    {
        rect = rawImage.uvRect;
        rect.x += Time.deltaTime * speed;

        rawImage.uvRect = rect;
    }
}
