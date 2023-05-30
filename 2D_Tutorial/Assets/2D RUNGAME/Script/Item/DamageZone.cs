using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour, IItem
{
    Player player;
    public void Use()
    {
        player = GameObject.Find("player").GetComponent<Player>();
        player.PlayerDamaged();
    }
}
