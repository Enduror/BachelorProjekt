using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTypeAchievementSave : MonoBehaviour {


    public InputField primaryInputField;
    public InputField secondaryInputField;
    public GameObject PlayerTypeSaveObject;

    public string primaryType;
    public string secondaryType;

    public void SetPrimaryType(string s)
    {
        primaryType = s;
    }
    public void SetSecondaryType(string s)
    {
        secondaryType = s;
    }
    public void StartGame()
    {
        if ((primaryInputField.text == "Type1" || primaryInputField.text == "Type2" || primaryInputField.text == "Type3" ) && (secondaryInputField.text == "Type1" || secondaryInputField.text == "Type2" || secondaryInputField.text == "Type3") && (primaryInputField.text != secondaryInputField.text))
        {
            primaryType = primaryInputField.text;
            secondaryType = secondaryInputField.text;
            
        }
        else
        {
            primaryInputField.text = " ";
            secondaryInputField.text = " ";
            Debug.Log("Die Eingabe ist ungültig");
        }

           
    }

}

