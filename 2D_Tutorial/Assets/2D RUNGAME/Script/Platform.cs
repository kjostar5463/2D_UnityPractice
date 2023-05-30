using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class Platform : MonoBehaviour
{
    private float speed = 1.3f;

    [SerializeField] GameObject[] cherry;
    [SerializeField] GameObject[] gem;
    [SerializeField] GameObject[] tile;
    private GameObject[] thron;

    // Start is called before the first frame update
    void Start()
    {
        thron = new GameObject[tile.Length];

        bool thronAppear = false;

        for (int i = 0; i < tile.Length; i++)
        {
            if(tile[i].transform.GetChild(0).gameObject.name != "spikes")
            {
                thron[i] = null;
            }
                
            thron[i] = tile[i].transform.GetChild(0).gameObject;
        }

        for (int i = 0; i < tile.Length; i++)
        {
            float rand = Random.Range(0.0f, 1.0f);
            float randPos = Random.Range(0.0f, 0.35f);
            if (thron[i] != null)
            {
                if (!thronAppear && rand < 0.2f)
                {
                    thron[i].SetActive(true);
                    thronAppear = true;
                }
                else
                {
                    thron[i].SetActive(false);
                }
            }
            rand = Random.Range(0.0f, 1.0f);
            if (rand < 0.2f)
            {
                if (thron[i].activeSelf)
                {
                    if (randPos < 0.1f)
                    {
                        cherry[i].transform.localPosition = new Vector2(
                            cherry[i].transform.localPosition.x,
                            0.25f);
                    }
                    else
                    {
                        cherry[i].transform.localPosition = new Vector2(
                        cherry[i].transform.localPosition.x,
                        0.15f + randPos);
                    }
                }
                else
                {
                    cherry[i].transform.localPosition = new Vector2(
                        cherry[i].transform.localPosition.x,
                        0.15f + randPos);
                }
                cherry[i].SetActive(true);
                gem[i].SetActive(false);
            }
            
            else if (rand >= 0.2f && rand < 0.6f)
            {
                if (thron[i].activeSelf)
                {
                    if (randPos < 0.1f)
                    {
                        gem[i].transform.localPosition = new Vector2(
                            gem[i].transform.localPosition.x,
                            0.25f);
                    }
                    else
                    {
                        gem[i].transform.localPosition = new Vector2(
                        gem[i].transform.localPosition.x,
                        0.15f + randPos);
                    }
                }
                else
                {
                    gem[i].transform.localPosition = new Vector2(
                        gem[i].transform.localPosition.x,
                        0.15f + randPos);
                }

                gem[i].SetActive(true);
                cherry[i].SetActive(false);
            }
            else
            {
                cherry[i].SetActive(false);
                gem[i].SetActive(false);
            }
        }
        float randGem = Random.Range(0.0f, 1.0f);
        float gemPos = Random.Range(0.0f, 0.35f);
        GameObject airGem = transform.Find("gem Zone").gameObject;
        if (randGem < 0.5f)
        {
            airGem.SetActive(true);
            airGem.transform.localPosition = new Vector2(
                airGem.transform.localPosition.x, 
                0.15f + gemPos);
        }
        else
        {
            airGem.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(true);

        transform.parent.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnDisable()
    {
        transform.parent.position = new Vector2(10.0f, -1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObjectPoolManager.Instance.InsertQueue(transform.parent.gameObject);
    }
}
