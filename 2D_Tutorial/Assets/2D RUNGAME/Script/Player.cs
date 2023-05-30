using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class Player : MonoBehaviour
{
    public SoundManager soundManager;
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [SerializeField] GameObject healthCherry;
    private Health health;

    private bool jumped = false;
    private bool isGround = false;

    private float moveMent;
    private float MoveSpeed = 3.0f;

    private int HP = 3;
    private bool invincibility = false;
    private bool canMove = true;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = healthCherry.GetComponent<Health>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        health.healthPoint = HP;

        if(GameManager.Instance.death)
        {
            HP = 0;
            moveMent = 0;
            if(canMove)
            {
                canMove = false;
                PlayerIsDeath();  
            }   
        }
        else if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                jumped = true;
                animator.SetBool("JUMP", true);
            }
            Move();
        }

        if(HP == 0)
        {
            GameManager.Instance.death = true;
        }
    }

    private void FixedUpdate()
    {
        Jump();
    }

    void Jump()
    {
        if (jumped)
        {
            rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            soundManager.Sound(SoundManager.SOUND_TYPE.JUMP);
            jumped = false;
            isGround = false;
        }
    }

    public void Move()
    {
        moveMent = Input.GetAxis("LeftRight");
        float playerMove = moveMent * Time.deltaTime * MoveSpeed;

        if (moveMent != 0)
        {
            if (isGround)
                animator.SetBool("MOVE", true);
            if (moveMent < 0)
            {
                gameObject.transform.localScale = new Vector3(-2f, 2f, 2f);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
            }
        }
        else
        {
            animator.SetBool("MOVE", false);
        }


        gameObject.transform.Translate(new Vector2(playerMove, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            animator.SetBool("JUMP", false);
            isGround = true;   
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IItem item = collision.gameObject.GetComponent<IItem>();

        if (item != null)
        {
            item.Use();

        }
    }

    void PlayerIsDeath()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        GameManager.Instance.death = true;
        animator.Play("Death");
        StartCoroutine(waitForEnd());
    }

    IEnumerator waitForEnd()
    {
        soundManager.GetComponent<AudioSource>().Stop();
        soundManager.Sound(SoundManager.SOUND_TYPE.GAME_OVER);
        yield return new WaitForSeconds(0.1f);
        rigidbody2D.velocity = Vector3.zero;
        rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    public async void PlayerDamaged()
    {
        if(!invincibility)
        {
            HP -= 1;
            if (HP > 0)
            {
                rigidbody2D.velocity = Vector3.zero;
                rigidbody2D.AddForce(new Vector2(-2 * moveMent, 2f), ForceMode2D.Impulse);
                await Task.Run(async () =>
                {
                    canMove = false;
                    await Task.Delay(500);
                    canMove = true;
                });
                StartCoroutine(invincibilityState());
            }
        } 
    }

    IEnumerator invincibilityState()
    {
        invincibility = true;
        for(int i = 0; i < 5; i++)
        {
            if(!GameManager.Instance.death)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
                yield return new WaitForSeconds(0.15f);
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 255);
                yield return new WaitForSeconds(0.15f);
            }        
        }
        invincibility = false;
    }

    public void PlayerHeal()
    {
        if (HP < 3)
        {
            HP++;
        }
        else GameManager.Instance.Score++;
    }
}
