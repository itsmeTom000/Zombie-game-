using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UI;

public class SplashPanel : MonoBehaviour
{
    #region Private_Variable
    [SerializeField] private Canvas canvas;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button skinButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button rewardButton;
    [SerializeField] private Button playButton;
    #endregion

    #region Unity_Callback

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        shopButton.onClick.AddListener(OnShopButtonClick);
        skinButton.onClick.AddListener(OnSkinButtonClick);
        settingButton.onClick.AddListener(OnSettingButtonClick);
        rewardButton.onClick.AddListener(OnRewardButtonClick);
        playButton.onClick.AddListener(OnPlayButtonClick);
    }
    #endregion

    #region Button_Callback
    public void OnShopButtonClick()
    {
        SoundManager.Instance.PlaySfx();
    }

    public void OnSkinButtonClick()
    {
        SoundManager.Instance.PlaySfx();
    }

    public void OnSettingButtonClick()
    {
        SoundManager.Instance.PlaySfx();
        UiManager.Instance.settingPanel.Open();
    }

    public void OnRewardButtonClick()
    {
        SoundManager.Instance.PlaySfx();
    }

    public void OnPlayButtonClick()
    {
        SoundManager.Instance.PlaySfx();
        UiManager.Instance.levelPanel.Open();
        Close();
    }

    public void EnableSplashScreenCanvas()
    {
        SoundManager.Instance.PlaySfx();
        canvas.enabled = true;
    }

    public void DisableSplashScreenCanvas()
    {
        SoundManager.Instance.PlaySfx();
        canvas.enabled = false;
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
