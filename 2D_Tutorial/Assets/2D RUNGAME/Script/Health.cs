using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject[] cherry;

    private SpriteRenderer [] cRender = new SpriteRenderer[3];
    private Animator[] cAnimator = new Animator[3];

    public int healthPoint;

    private void Start()
    {
        for (int i = 0; i < cherry.Length; i++)
        {
            cRender[i] = cherry[i].GetComponent<SpriteRenderer>();
            cAnimator[i] = cherry[i].GetComponent<Animator>();
        }
    }

    private void Update()
    {
        for (int i = 0; i < healthPoint; i++)
        {
            cRender[i].color = new Color(255, 255, 255, 255);
            cAnimator[i].SetBool("Destory", false);
        }
        for (int i = 0; i < 3 - healthPoint; i++)
        {
            cRender[2 - i].color = new Color(0, 0, 0, 255);
            cAnimator[2 - i].SetBool("Destory", true);
        }    
    }
}
