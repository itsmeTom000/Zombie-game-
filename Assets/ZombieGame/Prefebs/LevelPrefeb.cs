using TMPro;
using UnityEngine;

public class LevelPrefeb : MonoBehaviour
{
    #region public_Variable
    public TMP_Text levelText;
    public GameObject lockObj;
    public int level;
    #endregion

    public void OnClickLevel()
    {
        SoundManager.Instance.PlaySfx();
        GameManager.Instance.uiData.savedUIData.levelData.currentLevel = level;
        UiManager.Instance.loadingPanel.SceneOpen();
    }
}
