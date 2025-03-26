using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public string NextLevel;

    public float AutoSkipDelay = 0f;

    public bool SkipLoading = true;

    [Header("Fades")]
    public float FadeInDuraion = 1f;

    public int FadeId = 0;

    public bool UseFadein = true;

    public MMTweenType Tween;


    protected virtual void Awake()
    {
        if (AutoSkipDelay > 0f)
        {
            StartCoroutine(LoadNextLevel());
            Debug.Log("SplashScreen---Awake");
        }
    }

    private void Update()
    {
        Debug.Log("SplashScreen---Update");
    }

    private void OnEnable()
    {
        Debug.Log("SplashScreen---OnEnable");
    }

    protected virtual IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(AutoSkipDelay);
        Debug.Log("SplashScreen---LoadNextLevel---1");
        if (UseFadein)
        {
            Debug.Log("SplashScreen---LoadNextLevel---2");
            MMFadeInEvent.Trigger(FadeInDuraion, Tween, FadeId, true);
            yield return new WaitForSeconds(FadeInDuraion + 0.5f);
        }

        if (SkipLoading)
        {
            Debug.Log("SplashScreen---LoadNextLevel---3");
            SceneManager.LoadScene(NextLevel);
        }
        else 
        {
            Debug.Log("SplashScreen---LoadNextLevel---3");
            MMSceneLoadingManager.LoadScene(NextLevel);
        }
    }
}
