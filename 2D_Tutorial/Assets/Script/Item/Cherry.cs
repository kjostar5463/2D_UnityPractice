using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour, IItem
{
    Player player;
    public void Use()
    {
        player = GameObject.Find("player").GetComponent<Player>();
        gameObject.SetActive(false);
        player.PlayerHeal();
    }
}
