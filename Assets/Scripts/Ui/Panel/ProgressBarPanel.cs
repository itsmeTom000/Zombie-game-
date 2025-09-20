using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarPanel : MonoBehaviour
{
    #region Private_Variable
    [SerializeField] private Slider slider;
    [SerializeField] private Canvas canvas;
    private readonly int speeed = 2;
    private readonly float endValue = 1;
    #endregion

    #region Enable/Disable_Panel
    public void Open()
    {
        canvas.enabled = true;
        slider.DOValue(endValue, speeed).onComplete = Close;
    }

    public void Close()
    {
        canvas.enabled = false;
        UiManager.Instance.splashPanel.Open();
    }
    #endregion
}
