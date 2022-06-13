using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TransitionManager : Singleton<TransitionManager>
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;

    private bool m_IsFade;

    public bool isFade
    {
        get
        {
            return m_IsFade;
        }
    }

    /// <summary>
    /// 跳转场景
    /// </summary>
    /// <param name="_from">当前场景</param>
    /// <param name="_to">目标场景</param>
    public void Transition(string _from,string _to)
    {
        if(!m_IsFade)
            StartCoroutine(TransitionToScene(_from,_to));
    }

    //跳转场景
    private IEnumerator TransitionToScene(string _from,string _to)
    {
        yield return Fade(1);
        yield return SceneManager.UnloadSceneAsync(_from);
        yield return SceneManager.LoadSceneAsync(_to, LoadSceneMode.Additive);

        Scene newScene = SceneManager.GetSceneByName(_to);
        SceneManager.SetActiveScene(newScene);

        yield return Fade(0);
    }

    /// <summary>
    /// 淡入淡出场景
    /// </summary>
    /// <param name="_targetAlpha"></param>
    /// <returns></returns>
    private IEnumerator Fade(float _targetAlpha)
    {
        m_IsFade = true;
        fadeCanvasGroup.blocksRaycasts = true;
        float speed = Mathf.Abs(fadeCanvasGroup.alpha - _targetAlpha) / fadeDuration;
        while(!Mathf.Approximately(fadeCanvasGroup.alpha, _targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, _targetAlpha, speed*Time.deltaTime);
            yield return null;
        }

        m_IsFade = false;
        fadeCanvasGroup.blocksRaycasts = false;
    }

}
