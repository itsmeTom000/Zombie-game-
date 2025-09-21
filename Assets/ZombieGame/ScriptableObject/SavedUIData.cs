using System;
using UnityEngine;

[CreateAssetMenu(fileName = "UIData", menuName = "Scriptable Objects/UIData")]
public class UIData : ScriptableObject
{
    #region Public_Variable
    public SavedUIData savedUIData;
    #endregion

    #region Public_Method

    public void SaveData()
    {
        string str = JsonUtility.ToJson(savedUIData);
        Debug.Log("SaveSettingData : " + str);
        PlayerPrefs.SetString(Constant.SettingData, str);
    }
    public void LoadData()
    {
        string str = PlayerPrefs.GetString(Constant.SettingData);
        Debug.Log("LoadSettingData : " + str);
        savedUIData = JsonUtility.FromJson<SavedUIData>(str);
    }
    #endregion
}

#region SettingData_Model

[Serializable]
public class SavedUIData
{
    public SettingData settingData;
    public LevelData levelData;
}

[Serializable]
public class SettingData
{
    public bool music;
    public bool sfx;
    public bool vibration;
    public string quality;
}

[Serializable]
public class LevelData
{
    public int totalLevel;
    public int currentLevel;
    public int unlockedLevel;
    public int defeatCount;
}
#endregion