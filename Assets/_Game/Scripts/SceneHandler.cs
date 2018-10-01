using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {

    public GameObject whiteSquare;
    SpriteRenderer spriteRenderer;
    public float fadeSpeed = 1.5f;
    private string sceneToLoad;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        spriteRenderer = whiteSquare.GetComponent<SpriteRenderer>();
        FadeFromWhite();
        SceneManager.activeSceneChanged += SceneManager_ActiveSceneChanged;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= SceneManager_ActiveSceneChanged;
    }

    void SceneManager_ActiveSceneChanged(Scene arg0, Scene arg1)
    {
        if (SceneManager.GetActiveScene().name != "LoadingScene")
            FadeFromWhite();
        else 
            StartCoroutine(LoadSceneAndChange(sceneToLoad));

    }


    public void ChangeScene(string sceneName) {
        sceneToLoad = sceneName;
        Color color = spriteRenderer.color;
        color.a = 0;
        spriteRenderer.color = color;
        whiteSquare.SetActive(true);
        LeanTween.alpha(whiteSquare, 1, fadeSpeed).setEaseInCubic().setOnComplete(() => {

            SceneManager.LoadScene("LoadingScene");

        });

    }

    IEnumerator LoadSceneAndChange(string sceneName) {

        yield return null;

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;

        yield return new WaitForSeconds(3f);
       
        async.allowSceneActivation = true;

        
    }

    void FadeFromWhite() {
        Color color = spriteRenderer.color;
        color.a = 1;
        spriteRenderer.color = color;
        whiteSquare.SetActive(true);
        LeanTween.alpha(whiteSquare, 0, fadeSpeed).setEaseInCubic().setOnComplete(() =>
        {
            whiteSquare.SetActive(false);
        });
    }
}
