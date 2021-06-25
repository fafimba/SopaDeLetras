using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordToCheck : MonoBehaviour
{
    [SerializeField] Text txtWord;

    public string word;
    public bool wordChecked;

    public void Set(string word)
    {
        this.word = word;
        txtWord.text = word;
    }

    public void SetChecked()
    {
        wordChecked = true;
        txtWord.color = Color.green;
    }
}
