using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public Dropdown myDropdown;

    void Start(){
        SetDropdownOptions();
    }

    void SetDropdownOptions(){
        myDropdown.ClearOptions();

        List<string> options = new List<string> { "Wheel", "Engine", "Lever", "Pump", "Compass", "Coal", "Wire"};
        myDropdown.AddOptions(options);
    }

    public void OnDropdownValueChanged(){
        int selectedIndex = myDropdown.value;
        string selectedOption = myDropdown.options[selectedIndex].text;

        Debug.Log("Selected Option: " + selectedOption);
    }
}
