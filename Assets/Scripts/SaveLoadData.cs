using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/*
Script from BMo on YouTube
https://www.youtube.com/watch?v=x-5lrUSBwXY
*/

public class SaveLoadData : MonoBehaviour
{
    public TMP_InputField inputField;

    public void SaveData()
    {
        PlayerPrefs.SetString("username", inputField.text);
        inputField.text = "";

    }//end save data

    public void LoadData()
    {
        if (!(string.IsNullOrEmpty(PlayerPrefs.GetString("username"))))
        {
            inputField.text = "Hello, " + PlayerPrefs.GetString("username");
        }
        else
        {
            inputField.text = "No user found";
        }


    }//end load data

    public void DeleteData()
    {
        PlayerPrefs.DeleteKey("username");
        inputField.text = "";

    }//end delete data
}
