using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] WordsListManager wordsListManager;
    [SerializeField] GridManager gridManager;

    [SerializeField] int GridSize = 9;
    [SerializeField] int NumberOfWords = 6;

   
    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        gridManager.GenerateGrid(GridSize);
        gridManager.InsertWords(wordsListManager.GenerateWords(NumberOfWords));
    }


    public void CheckEndGame()
    {

        if (wordsListManager.wordsToChecks.TrueForAll(x=>x.wordChecked))
        {
            StartGame();
        }
    }
}
