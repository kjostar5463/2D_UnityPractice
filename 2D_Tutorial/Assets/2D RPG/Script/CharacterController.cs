using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{

    private Vector2 moveMent;
    [SerializeField] float speed = 10.0f;

    private SpriteRenderer spriteRenderer;

    [SerializeField] Material flashMaterial;
    private Material origin_Material;

    [SerializeField] Image HPbar;
    float HP = 100f;

    [SerializeField] ParticleSystem particleVariable;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
        spriteRenderer = GetComponent<SpriteRenderer>();
        origin_Material = spriteRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        moveMent.x = Input.GetAxis("LeftRight");
        moveMent.y = Input.GetAxis("UpDown");

        
    }

    private void FixedUpdate()
    {
        transform.Translate(moveMent * speed * Time.deltaTime);

        if (moveMent.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveMent.x < 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    void Damage()
    {
        HP -= 20f;
        HPbar.fillAmount = HP / 100f;
        particleVariable.Play();
    }
    void Death()
    {
        gameObject.transform.Rotate(0, 0, moveMent.x * 90);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Damage();
            StartCoroutine(Flash());
            if (HP <= 0)
            {
                Death();
            }
        }
        if (collision.CompareTag("Portal"))
        {
            SceneManager.LoadScene("RPG Stage");
        }
        
    }

    public IEnumerator Flash()
    {
        spriteRenderer.material = flashMaterial;

        yield return new WaitForSeconds(0.15f);

        spriteRenderer.material = origin_Material;

        yield return new WaitForSeconds(0.15f);

        spriteRenderer.material = flashMaterial;

        yield return new WaitForSeconds(0.15f);

        spriteRenderer.material = origin_Material;
    }
}
