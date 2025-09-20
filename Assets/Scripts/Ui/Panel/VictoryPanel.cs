using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryPanel : MonoBehaviour
{
    #region Private_Variable
    [SerializeField] private Canvas canvas;
    [SerializeField] private Button nextLevel;
    [SerializeField] private Button homePanel;
    [SerializeField] private Button retryLevel;
    #endregion

    #region Public_Variable
    public TMP_Text text;
    #endregion

    #region Unity_Callbacks
    private void Start()
    {
        nextLevel.onClick.AddListener(OnClickNextLevelButton);
        homePanel.onClick.AddListener(OnClickHomeButtonClick);
        retryLevel.onClick.AddListener(OnClickRetryButtonClick);
    }
    #endregion

    #region Private_Callbacks

    private void OnClickNextLevelButton()
    {
        SoundManager.Instance.PlaySfx();

        if (GameManager.Instance.uiData.savedUIData.levelData.currentLevel <=
            GameManager.Instance.uiData.savedUIData.levelData.unlockedLevel)
        {
            GameManager.Instance.uiData.savedUIData.levelData.currentLevel++;
        }
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    private void OnClickHomeButtonClick()
    {
        SoundManager.Instance.PlaySfx();
        GameManager.Instance.uiData.SaveData();
        SceneManager.LoadSceneAsync("SampleScene");
    }

    private void OnClickRetryButtonClick()
    {
        SoundManager.Instance.PlaySfx();
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    #endregion

    #region Enable/Disable_Panel
    public void Open(string message)
    {
        text.text = message;
        if (text.text == "Defeat" )
        {
            nextLevel.enabled = false;
            nextLevel.gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
        canvas.enabled = true;
    }

    public void Close() {
        Time.timeScale = 1f;
        canvas.enabled = false;
    }
    #endregion
}
