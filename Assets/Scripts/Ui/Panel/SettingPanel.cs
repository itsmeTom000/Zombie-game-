using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class SettingPanel : MonoBehaviour
{
    #region Private_Variable
    [Header("Toggle Data")]
    [SerializeField] private Toggle music;
    [SerializeField] private Toggle sfx;
    [SerializeField] private Toggle vibration;
    [SerializeField] private TextMeshProUGUI qualityField;
    [SerializeField] private Canvas canvas;

    [Header("Quality Button")]
    [SerializeField] private Button backButton;
    [SerializeField] private Button nextQualityButton;
    [SerializeField] private Button prevQualityButton;
    
    private List<string> qualitySetting = new() { "Low", "Medium", "High" };
    private int indexOfQuality = 1;
    #endregion

    #region Unity_Callback
    void Start()
    {
        nextQualityButton.onClick.AddListener(OnClickNextQuality);
        prevQualityButton.onClick.AddListener(OnClickPreviousQuality);
        backButton.onClick.AddListener(Close);
        music.onValueChanged.AddListener(OnMusicEnble);
        sfx.onValueChanged.AddListener(OnSFXEnble);
        vibration.onValueChanged.AddListener(OnVibrationEnble);
        indexOfQuality = qualitySetting.IndexOf(GameManager.Instance.uiData.savedUIData.settingData.quality);
        ShowQualityData();

        music.isOn = GameManager.Instance.uiData.savedUIData.settingData.music;
        sfx.isOn = GameManager.Instance.uiData.savedUIData.settingData.sfx;
        vibration.isOn = GameManager.Instance.uiData.savedUIData.settingData.vibration;
    }
    #endregion

    #region Toggle_Callback

    private void OnMusicEnble(bool changed)
    {
        SoundManager.Instance.PlaySfx();
        if (changed == true)
        {
            GameManager.Instance.uiData.savedUIData.settingData.music = true;
            SoundManager.Instance.PlayMusic();
        }
        else
        {
            GameManager.Instance.uiData.savedUIData.settingData.music = false;
            SoundManager.Instance.StopMusic();
        }

    }

    public void OnSFXEnble(bool changed)
    {
        SoundManager.Instance.PlaySfx();
        if (changed == true)
        {
            GameManager.Instance.uiData.savedUIData.settingData.sfx = true;
        }
        else
        {
            GameManager.Instance.uiData.savedUIData.settingData.sfx = false;
        }
    }

    public void OnVibrationEnble(bool changed)
    {
        SoundManager.Instance.PlaySfx();
        if (changed == true)
        {
            GameManager.Instance.uiData.savedUIData.settingData.vibration = true;
        }
        else
        {
            GameManager.Instance.uiData.savedUIData.settingData.vibration = false;
        }
    }
    #endregion

    #region Button_Click_Method

    private void OnClickNextQuality()
    {
        SoundManager.Instance.PlaySfx();
        indexOfQuality++;
        ShowQualityData();
    }

    private void OnClickPreviousQuality()
    {
        SoundManager.Instance.PlaySfx();
        indexOfQuality--;
        ShowQualityData();
    }

    #endregion

    #region Enable/Disable_Panel
    public void Open()
    {
        canvas.enabled = true;
    }

    public void Close()
    {
        SoundManager.Instance.PlaySfx();
        GameManager.Instance.uiData.SaveData();
        canvas.enabled = false;
    }
    #endregion

    #region Private_Method
    private void ShowQualityData()
    {
        prevQualityButton.gameObject.SetActive(indexOfQuality > 0);
        nextQualityButton.gameObject.SetActive(indexOfQuality < (qualitySetting.Count - 1));
        qualityField.text = qualitySetting[indexOfQuality];
        GameManager.Instance.uiData.savedUIData.settingData.quality = qualitySetting[indexOfQuality];
    }
    #endregion
}
