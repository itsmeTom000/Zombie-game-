using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    public UIData uiData;

    #region Unity_Callbacks
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
        LoadData();
    }

    private void Start()
    {
        SoundManager.Instance.PlayMusic();
    }
    private void OnDestroy()
    {
        uiData.SaveData();
    }
    #endregion

    private void LoadData()
    {
        if (PlayerPrefs.HasKey(Constant.SettingData))
        {
            uiData.LoadData();
        }
        else
        {
            uiData.savedUIData.settingData = new()
            {
                music = true,
                sfx = true,
                vibration = true,
                quality = "Low"
            };
            uiData.savedUIData.levelData = new()
            {
                currentLevel = 1,
                unlockedLevel = 1,
                totalLevel = 50,
            };
            Debug.Log("Default data set");
        }
    }
}
