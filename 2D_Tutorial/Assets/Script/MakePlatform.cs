using UnityEngine;

public class MakePlatform : MonoBehaviour
{
    [SerializeField] GameObject[] platform;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < platform.Length; i++)
        {
            
            float randPos = Random.Range(-1.25f, 1.25f);
            Debug.Log(GameManager.Instance.tilePos.y + randPos);
            if (GameManager.Instance.tilePos.y + randPos > 2.0f)
            {
                platform[i].transform.localPosition = new Vector2(platform[i].transform.localPosition.x, 2.0f);
            }
            else if (GameManager.Instance.tilePos.y + randPos < -3.5f)
            {
                platform[i].transform.localPosition = new Vector2(platform[i].transform.localPosition.x, -3.5f);
            }
            else
            {
                platform[i].transform.localPosition = new Vector2(platform[i].transform.localPosition.x, GameManager.Instance.tilePos.y + randPos);
            }
            GameManager.Instance.tilePos = platform[i].transform.localPosition;
        }
    }

}
