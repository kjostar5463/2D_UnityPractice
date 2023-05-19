using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed = 1.4f;

    [SerializeField] GameObject[] cherry;

    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < cherry.Length; i++)
        {
            int rand = Random.Range(0, 2);
            switch (rand)
            {
                case 0:
                    cherry[i].SetActive(false); break;
                case 1:
                    cherry[i].SetActive(true); break;
                default: break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(true);

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
