using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    GameObject character;
    SpriteRenderer charColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        character = GameObject.Find("Character");
        charColor = character.GetComponent<SpriteRenderer>();
        character.transform.position = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.6f);
        charColor.color = new Color(1, 1, 1, 0.4f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        charColor.color = new Color(1, 1, 1, 1f);
    }
}
