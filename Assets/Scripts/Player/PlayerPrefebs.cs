using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerPrefebs : MonoBehaviour
{
    #region Private_Variable
    private string playerName;
    private int playerScore;
    private float playerHealth;
    #endregion

    #region Unity_Callback
    private void Start()
    {
        TestP();
    }
    #endregion

    #region Call_Back
    [ContextMenu("TestP")]
    public void TestP()
    {
        if (PlayerPrefs.HasKey(Constant.PlayerName))
        {
            playerName = PlayerPrefs.GetString(Constant.PlayerName);
            playerScore = PlayerPrefs.GetInt(Constant.PlayerScore);
            playerHealth = PlayerPrefs.GetFloat(Constant.PlayerHealth);
            Debug.Log(playerName + " " + playerScore + " " + playerHealth);
        }
        else
        {
            playerName = PlayerPrefs.GetString(Constant.PlayerName);
            playerScore = PlayerPrefs.GetInt(Constant.PlayerScore);
            Debug.Log(playerName);
            Debug.Log(playerScore);
            Debug.Log("Player Doesn't exist");
        }
    }

    [ContextMenu("GetData")]
    public void GetData()
    {
        PlayerPrefs.SetString(Constant.PlayerName, "Saurabh");
        PlayerPrefs.SetInt(Constant.PlayerScore, 10);
        PlayerPrefs.SetFloat(Constant.PlayerHealth, 10.50f);
    }

    [ContextMenu("DeleteData")]
    public void DeleteData()
    {
        PlayerPrefs.DeleteKey(Constant.PlayerName);
        PlayerPrefs.DeleteAll();
    }
    #endregion
}
