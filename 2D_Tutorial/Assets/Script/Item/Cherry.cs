using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour, IItem
{
    int score;

    public void Use()
    {
        gameObject.SetActive(false);
        GamaManager.instance.Score++;
        score = GamaManager.instance.Score;
        Debug.Log(score);
    }
}
