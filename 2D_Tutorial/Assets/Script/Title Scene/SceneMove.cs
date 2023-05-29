using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMove : MonoBehaviour
{
    [SerializeField] GameObject screen;
    [SerializeField] Image progressImage;
    [SerializeField] GameObject player;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject canvas;

    public int sceneIndex = 0;
    public void NextScene()
    {
        if (sceneIndex == 0)
            GameManager.Instance.death = false;
        Time.timeScale = 1.0f;
        canvas.GetComponent<Canvas>().sortingLayerName = "OpenUI";
        StartCoroutine(LoadScene(sceneIndex));
        player.SetActive(true);
    }

    IEnumerator LoadScene(int index)
    {
        screen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        audioSource.Stop();

        progressImage.fillAmount = 0;

        // allowSceneActivation : ¾À ÀÌµ¿ Á¦¾î

        operation.allowSceneActivation = false;
        
        float progress = 0;

        while (!operation.isDone) 
        {
            progress = Mathf.MoveTowards(progress, operation.progress, Time.deltaTime);

            progressImage.fillAmount = progress;

            // 0.9f¿¡¼­ ¾À ·ÎµùÀ» ³¡³À´Ï´Ù.
            if(progress >= 0.9f)
            {
                progressImage.fillAmount = 1f;
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }



    public void QuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
