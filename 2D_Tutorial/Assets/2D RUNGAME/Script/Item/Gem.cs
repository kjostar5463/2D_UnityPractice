using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour, IItem
{
    public void Use()
    {
        gameObject.SetActive(false);
        GameManager.Instance.Score++;
    }
}
