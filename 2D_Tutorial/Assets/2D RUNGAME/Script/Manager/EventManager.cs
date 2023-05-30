using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public void Ready()
    {
        GameObject.Find("Canvas").transform.Find("GO Text").gameObject.SetActive(true);

    } 

    public void Go()
    {
        Debug.Log("���~");
        var player = GameObject.Find("player");
        player.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
        
        Time.timeScale = 1.0f;
    }
}
