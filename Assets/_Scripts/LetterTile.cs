using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterTile : MonoBehaviour
{
    [SerializeField] Text txtLetter;
    [SerializeField] GameObject backgroundImage;

    public char letter;
    public int xPos;
    public int yPos;
    public bool wordLetterSetted;

    Color defaultColor = Color.black;

    public void SetLetterUI()
    {
        txtLetter.text = letter.ToString();
    }

    public void EnableBackground()
    {
        txtLetter.color = Color.white;
        backgroundImage.SetActive(true);
    }

    public void SetDefaultColor(Color color)
    {
        defaultColor = color;
        ClearColor();
    }

    public void ClearColor()
    {
        txtLetter.color = defaultColor;
    }

    public void SetColor(Color color)
    {
        txtLetter.color = color;
    }
}