using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using UnityEngine.UI;
using NUnit.Framework;

public class CombinationLock : MonoBehaviour
{
    [SerializeField] TMP_Text userInputText;
    [SerializeField] XRButtonInteractable[] comboButtons;
    [SerializeField] Image lockedPanel;
    [SerializeField] Color unlockedColor;
    [SerializeField] TMP_Text lockedText;
    private const string unlockedString = "Unlocked";
    [SerializeField] bool isLocked;
    [SerializeField] int[] comboValues = new int[4];
    [SerializeField] int[] inputValues;
    private int maxButtonPresses;
    private int buttonPresses;

    void Start()
    {
        maxButtonPresses = comboValues.Length;
        ResetUserValues();

        for (int i = 0; i < comboButtons.Length; i++)
        {
            comboButtons[i].selectEntered.AddListener(OnComboButtonPressed);
        }
    }

    private void OnComboButtonPressed(SelectEnterEventArgs arg0)
    {
        if (buttonPresses >= maxButtonPresses)
        {
            // Too many buttons
        }
        else
        {
            for (int i = 0; i < comboButtons.Length; i++)
            {
                if (arg0.interactableObject.transform.name == comboButtons[i].transform.name)
                {
                    userInputText.text += i.ToString();
                    inputValues[buttonPresses] = i;
                }
                else
                {
                    comboButtons[i].ResetColor();
                }
            }
            buttonPresses++;
            if (buttonPresses == maxButtonPresses)
            {
                CheckCombo();
            }
        }
    }

    private void CheckCombo()
    {
        int matches = 0;

        for (int i = 0; i < maxButtonPresses; i++)
        {
            if (inputValues[i] == comboValues[i])
            {
                matches++;
            }
        }

        if (matches == maxButtonPresses)
        {
            isLocked = false;
            lockedPanel.color = unlockedColor;
            lockedText.text = unlockedString;
        }
        else
        {
            ResetUserValues();
        }
    }

    private void ResetUserValues()
    {
        inputValues = new int[maxButtonPresses];
        userInputText.text = "";
        buttonPresses = 0;
    }

}
