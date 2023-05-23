using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour, IItem
{
    int score;

    public void Use()
    {
        gameObject.SetActive(false);
        GamaManager.instance.Score = GamaManager.instance.Score + 2;
        score = GamaManager.instance.Score;
        Debug.Log(score);
    }
}
