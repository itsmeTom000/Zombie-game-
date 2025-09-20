using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class NewLevelPanel : MonoBehaviour
{
    #region Private_Variable
    [SerializeField] private Canvas canvas;
    [SerializeField] private TMP_Text levelNo;
    [SerializeField] private UnityEngine.UI.Button levelComplete;
    [SerializeField] private UnityEngine.UI.Button levelAbort;
    #endregion

    #region Public_Variable
    public VictoryPanel victoryPanel;
    #endregion

    #region Unity_Callback
    private void Start()
    {
        levelComplete.onClick.AddListener(LevelComplete);
        levelAbort.onClick.AddListener(LevelAbort);
        if(GameManager.Instance.uiData.savedUIData.levelData.currentLevel == GameManager.Instance.uiData.savedUIData.levelData.totalLevel)
        {
            levelNo.text = "You are at final level";
        }
        else
        { 
            levelNo.text = $"You are comming from level {GameManager.Instance.uiData.savedUIData.levelData.currentLevel}";
        }
    }
    #endregion

    #region Private_Callback
    private void LevelComplete()
    {
        SoundManager.Instance.PlaySfx();
        victoryPanel.Open("Victory");
        LevelIncrement();
    }

    public void LevelIncrement()
    {
        if (GameManager.Instance.uiData.savedUIData.levelData.currentLevel == GameManager.Instance.uiData.savedUIData.levelData.unlockedLevel)
        {
            if (!(GameManager.Instance.uiData.savedUIData.levelData.unlockedLevel >= GameManager.Instance.uiData.savedUIData.levelData.totalLevel))
            {
                GameManager.Instance.uiData.savedUIData.levelData.unlockedLevel++;
                GameManager.Instance.uiData.SaveData();
            }
        }
    }
    private void LevelAbort()
    {
        SoundManager.Instance.PlaySfx();
        victoryPanel.Open("Defeat");
    }
    #endregion

    #region Enable/Disable_Panel
    public void Open()
    {
        levelNo.text = $"You are comming from level {GameManager.Instance.uiData.savedUIData.levelData.unlockedLevel}";
        canvas.enabled = true;
    }

    public void Close()
    {
        canvas.enabled = false;
    }
    #endregion
}
