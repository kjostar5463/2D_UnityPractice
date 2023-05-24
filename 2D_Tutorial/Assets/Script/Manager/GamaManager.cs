using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamaManager : MonoBehaviour
{
    private int cScore = 0;
    private int bScore = 0;
    [SerializeField] Text bestScoreText;
    [SerializeField] Text currentScoreText;

    public int Score
    {
        set {
            cScore = value;
            currentScoreText.text = "Current Score : " + cScore;
        }
        get { return cScore; }
    }
    public static GamaManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;

        Load();
        bestScoreText.text = "Best Score : " + bScore;
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
}
