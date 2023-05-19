using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public SoundManager soundManager;

    private Rigidbody2D rigidbody2D;
    private Animator animator;
    
    bool jumped = false;
    bool isGround = false;
    bool isFall = false;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            jumped = true;
        }
        Fall();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    void Jump()
    {
        if(jumped)
        {
            animator.Play("Jump");
            rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            soundManager.Sound(SoundManager.SOUND_TYPE.JUMP);
            jumped = false;
            isGround = false;
        }
    }

    void Fall()
    {
        if(isFall)
        {
            soundManager.Sound(SoundManager.SOUND_TYPE.GAME_OVER);
            Time.timeScale = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform(Clone)")
        {
            isGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Falling Zone")
        {
            isFall = true;
        }
    }
}
