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
        // ���� �ִϸ����Ϳ� �ִ� �ִϸ��̼��� Close�� ��
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("closeMenu"))
        {
            // ���� �ִϸ��̼��� ���൵�� >= 1 �̸� �ִϸ������� ���� ������Ʈ�� ��Ȱ��ȭ �Ѵ�
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
