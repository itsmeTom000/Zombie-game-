using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.HDROutputUtils;

public class LoadingPanel : MonoBehaviour
{
    #region Private_Variable
    [SerializeField] private GameObject loadingImage;
    [SerializeField] private Canvas canvas;
    #endregion

    #region Public_Variable
    public int limit;
    #endregion

    #region Enable/Disable_Panel
    public void Open()
    {
        if(Time.timeScale == 0f)
            Time.timeScale = 1f;
        canvas.enabled = true;
        if (limit != 0)
            loadingImage.transform.DOLocalRotate(new Vector3(0, 0, 360), 1, RotateMode.FastBeyond360)
                .SetRelative(true)
                .SetEase(Ease.Linear)
                .SetLoops(limit)
                .onComplete = Close;
    }

    public void Close()
    {
        canvas.enabled = false;
        UiManager.Instance.progressBarPanel.Open();
    }

    public void SceneOpen()
    {
        StartCoroutine(Loadsceneasync("NextScene"));
    }

    IEnumerator Loadsceneasync(string sceneName)
    {
        AsyncOperation loadingScene = SceneManager.LoadSceneAsync(sceneName);
        loadingScene.allowSceneActivation = false;

        canvas.enabled = true;
        loadingImage.transform.DOLocalRotate(new Vector3(0, 0, 360), 1, RotateMode.FastBeyond360)
                            .SetRelative(true)
                            .SetEase(Ease.Linear)
                            .SetLoops(-1);

        while (loadingScene.progress < 0.9f)
        {
            yield return null;
        }

        SceneClose();
        loadingScene.allowSceneActivation = true;

        DOTween.Kill(loadingImage.transform);
    }

    public void SceneClose() { 
        canvas.enabled = false;
    }
    #endregion
}
