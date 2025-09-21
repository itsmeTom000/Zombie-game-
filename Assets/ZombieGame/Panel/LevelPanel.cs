using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class LevelPanel : MonoBehaviour
{
    #region Private_Variable
    [SerializeField] private Canvas canvas;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private GameObject buttonPrefeb;
    [SerializeField] private Transform parentPanel;
    [SerializeField] private Button backButton;
    [SerializeField] private LevelPrefeb buttonPrefebH;
    #endregion

    #region Unity_Callback
    private void Start()
    {
        backButton.onClick.AddListener(OnClickBackButton);
        SetupLevelButton();
    }
    #endregion

    #region Private_Callback

    void SetupLevelButton()
    {
        for( int i = 1; i <= GameManager.Instance.uiData.savedUIData.levelData.totalLevel; i++)
        {
            LevelPrefeb button = Instantiate(buttonPrefebH, parentPanel);
            button.levelText.text = $"Level : {i}";
            button.level = i;
            button.lockObj.SetActive(!(i <= GameManager.Instance.uiData.savedUIData.levelData.unlockedLevel));
            button.levelText.enabled = (i <= GameManager.Instance.uiData.savedUIData.levelData.unlockedLevel);
        }
    }

    private void OnClickBackButton()
    {
        SoundManager.Instance.PlaySfx();
        Close();
        UiManager.Instance.splashPanel.Open();
    }

    #endregion

    #region Enable/Disable_Panel
    public void Open()
    {

        canvas.enabled = true;
    }

    public void Close()
    {
        canvas.enabled = false;
    }
    #endregion
}
