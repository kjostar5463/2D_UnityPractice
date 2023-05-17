using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2D;
    bool jumped = false;
    bool isGround = false;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumped = true;
        }
    }

    private void FixedUpdate()
    {
        Jump();
    }

    void Jump()
    {
        if(jumped && isGround)
        {
            rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            jumped = false;
            isGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform(Clone)")
        {
            isGround = true;
        }
    }
}
