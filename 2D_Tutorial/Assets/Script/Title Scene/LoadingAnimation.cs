using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingAnimation : MonoBehaviour
{
    int randomNum;
    private Animator animator;

    public void jumpRepeat()
    {
        animator = GetComponent<Animator>();
        randomNum = Random.Range(0, 2);
        if (randomNum == 0) animator.SetTrigger("JUMP");
    }
}
