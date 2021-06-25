using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
      int GridSize = 9;

    [SerializeField] Transform GridUI;
    [SerializeField] GameObject LetterPrefab;

    public LetterTile[,] letterTiles;


    public void GenerateGrid(int gridSize)
    {
        GridSize = gridSize;
        letterTiles = new LetterTile[GridSize, GridSize];

        for (int i = 0; i < GridUI.childCount; i++)
        {
            GridUI.GetChild(i).gameObject.SetActive(false);
        }

        for (int y = 0; y < GridSize; y++)
        {
            for (int x = 0; x < GridSize; x++)
            {
                SpawnLetterPrefab(x, y);
            }
        }
    }


    void SpawnLetterPrefab(int x, int y)
    {
        LetterTile letterTile = Instantiate(LetterPrefab, GridUI).GetComponent<LetterTile>();

        char c = (char)('A' + Random.Range(0, 26));

        letterTile.letter = c;
        letterTile.SetLetterUI();

        letterTile.xPos = x;
        letterTile.yPos = y;

        letterTiles[x,y] = letterTile;
    }

   public void InsertWords(List<string> words)
    {
        foreach (var word in words)
        {
            char[] wordArray = word.ToCharArray();

            bool goodSpot=false;

            while (!goodSpot)
            {
                goodSpot = true;

                int x = Random.Range(0, GridSize);
                int y = Random.Range(0, GridSize);

                switch (Random.Range(0, 4))
                {
                    //horizontal
                    case 0:
                        if ((GridSize - x) < wordArray.Length)
                        {
                            goodSpot = false;
                        }
                        else
                        {
                            for (int i = 0; i < wordArray.Length; i++)
                            {
                                if (letterTiles[i + x, y].wordLetterSetted)
                                {
                                    if (letterTiles[i + x, y].letter != wordArray[i])
                                    {
                                        goodSpot = false;
                                    }
                                }
                            }
                        }

                        if (goodSpot)
                        {
                            for (int i = 0; i < wordArray.Length; i++)
                            {
                                LetterTile letterTile = letterTiles[i + x, y];
                                letterTile.letter = wordArray[i];
                                letterTile.SetLetterUI();
                                letterTile.wordLetterSetted = true;
                              //  letterTile.SetDefaultColor(Color.yellow);
                            }
                        }
                        break;
                        //vertical
                    case 1:
                        if ((GridSize - y) < wordArray.Length)
                        {
                            goodSpot = false;
                        }
                        else
                        {
                            for (int i = 0; i < wordArray.Length; i++)
                            {
                                if (letterTiles[x, i + y].wordLetterSetted)
                                {
                                    if (letterTiles[x, i + y].letter != wordArray[i])
                                    {
                                        goodSpot = false;
                                    }
                                }
                            }
                        }

                        if (goodSpot)
                        {
                            for (int i = 0; i < wordArray.Length; i++)
                            {
                                LetterTile letterTile = letterTiles[x, i + y];
                                letterTile.letter = wordArray[i];
                                letterTile.SetLetterUI();
                                letterTile.wordLetterSetted = true;
                                //letterTile.SetDefaultColor(Color.yellow);
                            }
                        }
                        break;
                        //diagonal +x +y
                    case 2:

                        if ((GridSize - x) < wordArray.Length || (GridSize - y) < wordArray.Length)
                        {
                            goodSpot = false;
                        }
                        else
                        {
                            for (int i = 0; i < wordArray.Length; i++)
                            {
                                if (letterTiles[i + x, i + y].wordLetterSetted)
                                {
                                    if (letterTiles[i + x,i + y].letter != wordArray[i])
                                    {
                                        goodSpot = false;
                                    }
                                }
                            }
                        }

                        if (goodSpot)
                        {
                            for (int i = 0; i < wordArray.Length; i++)
                            {
                                LetterTile letterTile = letterTiles[i + x, i + y];
                                letterTile.letter = wordArray[i];
                                letterTile.SetLetterUI();
                                letterTile.wordLetterSetted = true;
                              //  letterTile.SetDefaultColor(Color.yellow);
                            }
                        }

                        break;
                        //diagonal +x -y
                    case 3:
                        if ((GridSize - x) < wordArray.Length || y  < wordArray.Length)
                        {
                            goodSpot = false;
                        }
                        else
                        {
                            for (int i = 0; i < wordArray.Length; i++)
                            {
                                if (letterTiles[i + x, y - i].wordLetterSetted)
                                {
                                    if (letterTiles[i + x,  y - i].letter != wordArray[i])
                                    {
                                        goodSpot = false;
                                    }
                                }
                            }
                        }

                        if (goodSpot)
                        {
                            for (int i = 0; i < wordArray.Length; i++)
                            {
                                LetterTile letterTile = letterTiles[i + x, y -i];
                                letterTile.letter = wordArray[i];
                                letterTile.SetLetterUI();
                                letterTile.wordLetterSetted = true;
                               // letterTile.SetDefaultColor(Color.yellow);
                            }
                        }
                        break;
                    default:
                        break;
                }
                }
            }
        }
    }
