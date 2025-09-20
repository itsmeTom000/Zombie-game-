using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    string output_1 = string.Empty;
    //int number = 5;
    //int incrementNumber = 0;
    //int decrementNumber = 5;
    //bool state = true;
    int tmp;
    public int new_number;

    public List <string> languages = new();
    public List <int> numbers = new();
    public List <int> index_of = new List<int>();
    //public int index_of;

    public int value;
    void Start()
    {
        //Print_List();
        //Print_In_Increment();
        //Print_sorted_inDecrement();
        find_indexof();
    }

    void Print_List()
    {
        languages.Add("Gujrati");
        languages.Add("English");
        languages.Add("Spanish");
        foreach(string languages_names in languages)
        {
            Debug.Log(languages_names);
        }
    }

    void Print_In_Increment()
    {
        numbers.Sort();
       
    }

    void Print_sorted_inDecrement()
    {
        numbers.Sort();
        numbers.Reverse();
        
    }

    void find_indexof()
    {
        // indexof doesn't accept lambda expression
        index_of = numbers.FindAll(n => n == 98);
        //index_of = numbers.IndexOf(98);
    }

    [ContextMenu("check_num")]
    public void check_num()
    {
        int tmp_2 = new_number/2;
        int tmp_3 = tmp_2 * 2;
        
        if(tmp_3 == new_number)
        {
            Debug.Log(new_number + " Number is Even ");
        }
        else
        {
            Debug.Log(new_number + " Number is odd ");
        }
    }
    void Check()
    {
        if (value / 2 == 0)
        {
            Debug.Log(value/2 + " Number is Even ");
        }
        else
        {
            Debug.Log(value/2 + " Number is odd ");
        }
    }

    //void Patten()
    //{
        //for (int i = 0; i <= number; i++)
        //{
        //    for (int j = 0; j <= number-i; j++)
        //    {
        //        output_1 += "   ";
        //    }
        //    for (int j = 0; j <= i; j++)
        //    {
        //        if (incrementNumber < 5)
        //        {
        //            incrementNumber++;
        //            //Debug.Log(incrementNumber);
        //            tmp = incrementNumber;
        //            if(incrementNumber == 5)
        //            {
        //                decrementNumber = 5;
        //            }
        //        }
        //        else if (decrementNumber >= 1)
        //        {
        //            decrementNumber--;
        //            tmp = decrementNumber;
        //            if (decrementNumber == 1)
        //            {
        //            incrementNumber = 1;
        //            }
        //        }
        //        output_1 += "   ";
        //        output_1 += tmp.ToString();
        //    }

        //    Debug.Log(output_1);
        //    output_1 = string.Empty;

        //}

        //for (int i = 0; i <= number; i++)
        //{
        //    for (int j = 0; j <= number - i; j++)
        //    {
        //        output_1 += "   ";
        //    }
        //    for (int j = 0; j <= i; j++)
        //    {
        //        if (state)
        //        {
        //            incrementNumber++;
        //            tmp = incrementNumber;
        //            if (incrementNumber > 4)
        //            {
        //                state = false;
        //            }
        //        }
        //        else
        //        {
        //            incrementNumber--;
        //            tmp = incrementNumber;
        //            if (incrementNumber < 2)
        //            {
        //                state = true;
        //            }
        //        }
        //        output_1 += "   ";
        //        output_1 += tmp.ToString();
        //    }

        //    Debug.Log(output_1);
        //    output_1 = string.Empty;


        //}
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
