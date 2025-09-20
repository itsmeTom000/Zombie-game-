using UnityEngine;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    #region Private_Variable
    [Header("UI Panels")]
    public static UiManager Instance { get; private set; }

    public LoadingPanel loadingPanel;
    public ProgressBarPanel progressBarPanel;
    public SplashPanel splashPanel;
    public SettingPanel settingPanel;
    public LevelPanel levelPanel;
    public NewLevelPanel newLevelPanel;

    #endregion

    #region Unity_Callback
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        loadingPanel.Open();
    }
    #endregion
}
