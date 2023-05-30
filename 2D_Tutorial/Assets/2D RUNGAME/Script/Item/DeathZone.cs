using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class DeathZone : MonoBehaviour, IItem
{
    public void Use()
    {
        GameManager.Instance.death = true;
    }
}
