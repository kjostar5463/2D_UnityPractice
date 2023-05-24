using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class Player : MonoBehaviour
{
    public SoundManager soundManager;
    [SerializeField] AudioSource audioSource;

    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    
    bool jumped = false;
    bool isGround = false;

    bool isFall = false;
    int deathCnt = 0;

    float moveMent;
    public float MoveSpeed;

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
        
        Move();
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
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            moveMent = 0;
            animator.Play("Death");
            if(deathCnt == 1)
                StartCoroutine(waitForEnd());
            deathCnt++;
        }
    }

    IEnumerator waitForEnd()
    {
        soundManager.Sound(SoundManager.SOUND_TYPE.GAME_OVER);
        yield return new WaitForSeconds(0.1f);
        rigidbody2D.velocity = Vector3.zero;
        rigidbody2D.AddForce(new Vector2(0, 5) , ForceMode2D.Impulse);
        yield return new WaitForSeconds(2f);
        audioSource.Stop();
        Time.timeScale = 0f;
    }

    public void Move()
    {
        moveMent = Input.GetAxis("LeftRight");
        float playerMove = moveMent * Time.deltaTime * MoveSpeed;
        
        if(moveMent != 0) 
        {
            if(isGround)
                animator.Play("run-Animation");
            if (moveMent < 0)
            {
                gameObject.transform.localScale = new Vector3(-2f, 2f, 2f);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
            }
        }
        
       
        gameObject.transform.Translate(new Vector2(playerMove, 0));
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
        IItem item = collision.gameObject.GetComponent<IItem>();

        if(item != null)
        {
            item.Use();
        }

        // Ãß¶ô
        if(collision.gameObject.tag == "Death Zone")
        {
            isFall = true;
            deathCnt++;
        }
    }
}
