using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FuctionPractice : MonoBehaviour
{
    // we can pass everything in return
    // 
    private int Number;
    public int Num_1;
    public int Num_2;
    public SettingData settingData;
    public float speed = 100000f;
    private List<String> names  = new List<string>();
    private List<String> names_  = new();
    public string playerName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    #region Unity_Callback
    void Start()
    {
        Number = GetAddition(2, 45) + GetMultiplication(23, 5);
        Debug.Log("Number : " + Number);
        Debug.Log("Statement : " + GetStatement(45, 567));
        if (GetStatement(Num_1, Num_2))
        {
            Debug.Log(GetMultiplication(Num_1, Num_2) + GetAddition(Num_1, Num_2));
        }
        else
        {
            Debug.Log(GetMultiplication(Num_1, Num_2) - GetAddition(Num_1, Num_2));
        }
        settingData = SetReturn();

        if (GetSpeed(speed) > 10)
        {
            Debug.Log("Speed : " + GetSpeed(speed));
            Debug.Log("You are going fast");
        }

        else
        {
            Debug.Log("Slow");
        }

        speed = GetSpeed(speed);
        Debug.Log(speed);

        PrintFunction("Saurabh");
        names.Add("saurabh");
        //Debug.Log(names);
        foreach(string name in names)
        {
            Debug.Log(name);
        }
        playerName = ReturnName("saurabh", "solanki");
        Debug.Log(playerName);
    }
    #endregion

    #region Private_Callback
    private int GetAddition(int y, int z)
    {
        int x = y + z;
        return x;
    }

    public SettingData SetReturn()
    {
        settingData = new SettingData()
        {
            music = false,
            sfx = false,
            vibration = true,
            quality = "Low"
        };
        return settingData;
    }

    private float GetAdditionFloat(int y, int z)
    {
        float x = y + z;
        return x;
    }

    private int GetMultiplication(int y, int z)
    {
        int x = y * z;
        return x;
    }

    private bool GetStatement(int y, int z)
    {
        return y >= z;
    }

    private float GetSpeed(float speed)
    {
        return speed * Time.deltaTime;
    }

    void PrintFunction(string s)
    {
        Debug.Log(s + " " + GetSpeed(speed));
    }

    private string ReturnName(string n , string x)
    {
        return n + " " + x;
    }
    #endregion
}
