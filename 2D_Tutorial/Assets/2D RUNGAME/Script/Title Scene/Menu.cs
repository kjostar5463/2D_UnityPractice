using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip[] animationClip;
    [SerializeField] GameObject canvas;
    bool ingameClosed = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < animationClip.Length; i++)
        {
            var data = AnimationUtility.GetAnimationClipSettings(animationClip[i]);

            data.loopTime = false;

            AnimationUtility.SetAnimationClipSettings(animationClip[i], data);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 현재 애니메이터에 있는 애니매이션이 Close일 때
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("closeMenu"))
        {
            // 현재 애니매이션의 진행도가 >= 1 이면 애니메이터의 게임 오브젝트를 비활성화 한다
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                animator.gameObject.SetActive(false);
                if(ingameClosed)
                {
                    canvas.GetComponent<Canvas>().sortingOrder = 0;
                    canvas.GetComponent<Canvas>().sortingLayerName = "Default";
                    Time.timeScale = 1f;
                }
            }
        }
    }

    public void Open()
    {
        animator.gameObject.SetActive(true);
    }
    public void Close()
    {
        animator.SetTrigger("Close");
    }

    public void inGameOpen()
    {
        ingameClosed = false;
        canvas.GetComponent<Canvas>().sortingOrder = 0;
        canvas.GetComponent<Canvas>().sortingLayerName = "OpenUI";
        animator.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void inGameClose()
    {
        ingameClosed = true;
        animator.SetTrigger("Close");
    }
}
