using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsListManager : MonoBehaviour
{
    [SerializeField] Transform WordListUI;
    [SerializeField] GameObject WordPrefab;

    public List<WordToCheck> wordsToChecks;

    public List<string> GenerateWords(int numberOfWords)
    {
        for (int i = 0; i < WordListUI.childCount; i++)
        {
            //Destroy(WordListUI.GetChild(i).gameObject);
           WordListUI.GetChild(i).gameObject.SetActive(false);
        }

        List<string> words = new List<string>();
        wordsToChecks = new List<WordToCheck>();

        foreach (var randomNumber in GetRandoms(0, Collections.Words.Length, numberOfWords))
        {
            string word = Collections.Words[randomNumber].ToUpper();
            words.Add(word);

            WordToCheck wordToCheck = Instantiate(WordPrefab, WordListUI).GetComponent<WordToCheck>();
            wordToCheck.Set(word);
            wordsToChecks.Add(wordToCheck);
        }
        return words;
    }


    List<int> GetRandoms(int min, int max, int count)
    {
        List<int> numbers = new List<int>();

        int rand = Random.Range(min, max);

        for (int i = 0; i < count; i++)
        {
            while (numbers.Contains(rand))
                rand = Random.Range(min, max);
            numbers.Add(rand);
        }

        return numbers;
    }

    public bool IsAWordToCheck(string wordToCheck)
    {
        foreach (var word in wordsToChecks)
        {
            if ((word.word == wordToCheck) && !word.wordChecked)
            {
                word.SetChecked();
                return true;
            }
        }
        return false;
    }
}
