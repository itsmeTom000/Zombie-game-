using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Test_2 : MonoBehaviour
{

    public List<Player_data> numbers = new();
    public List<int> listNumbers = new();
    //public int indexOf;
    public List<int> indexOf = new();
    public List<Player_data> player_name = new();
    public bool contain;

    public Player_data player;
    void Start()
    {
        //Print_list();
        //Print_sorted();
        //Print_reverse();
        //Print_indexof();
        //Print_all();
        //Print_class();
        //Print_iscontain();
        //Print_removed();
    }

    void Print_list()
    {
        foreach (Player_data number in numbers)
        {
            Debug.Log(number.playerName);
        }
    }

    void Print_sorted()
    {
        listNumbers.Sort();
        foreach (int number in listNumbers) {
            Debug.Log(number);
        }
    }

    void Print_reverse()
    {
        listNumbers.Sort();
        listNumbers.Reverse();
        foreach (int number in listNumbers)
        {
            Debug.Log(number);
        }
    }

    void Print_indexof()
    {
        //indexOf = listNumbers.FindIndex(n => n == 9);
        //indexOf = listNumbers.IndexOf(9);
    }

    void Print_all()
    {
        indexOf = listNumbers.FindAll(n => n == 9);
    }

    void Print_class()
    {
        foreach(Player_data player_name in player_name)
        {
            Debug.Log(player_name.playerName);
        }
    }

    void Print_iscontain()
    {
        contain = listNumbers.Contains(9);
    }

    void Print_removed()
    {
        listNumbers.Insert(7, 10);
        listNumbers.RemoveAll(n => n > 8);
        listNumbers.ForEach(n => Debug.Log(n));
    }
}

[Serializable]
public class Player_data 
{
    public string playerName;
    public int playerHealth;
}