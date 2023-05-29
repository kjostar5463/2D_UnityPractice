using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    private int cScore = 0;
    private int bScore = 0;
    [SerializeField] Text bestScoreText;
    [SerializeField] Text currentScoreText;
    public Vector2 tilePos = new Vector2(0.0f, 0.0f);
    public bool death = false;
    private int deathCnt = 0;

    public int Score
    {
        set {
            cScore = value;
            currentScoreText.text = "Current Score : " + cScore;
        }
        get { return cScore; }
    }

    private void Awake()
    {
        Load();
        bestScoreText.text = "Best Score : " + bScore;
        Time.timeScale = 0.0f;
        bestScoreText.gameObject.SetActive(false);
        currentScoreText.gameObject.SetActive(false);
    }
    

    public void Save()
    {
        if (PlayerPrefs.GetInt("BestScore") <= cScore)
        {
            bScore = cScore;
            PlayerPrefs.SetInt("BestScore", bScore);
        }
    }

    public void Load()
    {
        bScore = PlayerPrefs.GetInt("BestScore");
    }



    private void OnApplicationQuit()
    {
        Save();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        if (Time.timeScale > 0.9f)
        {
            bestScoreText.gameObject.SetActive(true);
            currentScoreText.gameObject.SetActive(true);
        }
        if (death)
        {
            if (deathCnt == 0)
            {
                Invoke("isDeath", 2f);
                deathCnt++;
            }
                
        }
    }
    void isDeath()
    {
        Time.timeScale = 0.0f;
    }

}
