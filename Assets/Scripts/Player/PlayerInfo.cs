using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

public class PlayerInfo : MonoBehaviour
{
    private TMP_Text setPlayerName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setPlayerName = GetComponent<TMP_Text>();
    }

}
