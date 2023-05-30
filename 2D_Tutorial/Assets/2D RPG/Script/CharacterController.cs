using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    private Vector2 moveMent;
    [SerializeField] float speed = 5.0f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveMent.x = Input.GetAxis("LeftRight");
        moveMent.y = Input.GetAxis("UpDown");

        transform.Translate(moveMent * speed *  Time.deltaTime);
        
        if(moveMent.x >= 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        
    }
}
