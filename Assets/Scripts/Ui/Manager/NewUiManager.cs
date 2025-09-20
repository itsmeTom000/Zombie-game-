using TMPro;
using UnityEngine;

public class NewUiManager : MonoBehaviour
{
    #region Public_Variable
    public static NewUiManager Instance { get; private set; }
    public VictoryPanel victoryPanel;
    public ZombieController zombieController;
    public LevelGenerator levelGenerator;
    public TMP_Text zombieText;
    public TMP_Text currentLevel;
    #endregion

    #region Private_Variable
    public bool pauseOpen = false;
    #endregion

    #region Unity_Callbacks
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        zombieText.text = $"{zombieController.deadzombieCount} / {LevelGenerator.Instance.zombieLevelData.zombieCount + LevelGenerator.Instance.bossData.bossCount}";
        currentLevel.text = $"Level : {GameManager.Instance.uiData.savedUIData.levelData.currentLevel}";

    }

    private void Update()
    {
        
    }
    #endregion

    #region Update_UI
    public void UpdateDeadZombieCount()
    {
        zombieText.text = $"{zombieController.deadzombieCount} / {LevelGenerator.Instance.zombieLevelData.zombieCount + LevelGenerator.Instance.bossData.bossCount}";
    }

    public void UpdateNextLevel()
    {
        currentLevel.text = $"Level : {GameManager.Instance.uiData.savedUIData.levelData.currentLevel}";
    }
    #endregion
}