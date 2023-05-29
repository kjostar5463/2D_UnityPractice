using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{

    public GameObject platform; // 생성할 오브젝트
    public int objectCount = 10;

    public Queue<GameObject> queue= new Queue<GameObject>();
    // Start is called before the first frame update
    private void Awake()
    {

        for (int i = 0; i < objectCount; i++)
        {
            GameObject prefeb = Instantiate(platform);
            platform.transform.position = new Vector2(10f, -1.0f);
            queue.Enqueue(prefeb);
            prefeb.SetActive(false);
        }
    }

    public void InsertQueue(GameObject prefabObject)
    {
        queue.Enqueue(prefabObject);
        prefabObject.SetActive(false);
    }

    public void GetQueue()
    {
        queue.Dequeue().SetActive(true);
    }
}
