using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Selector : MonoBehaviour 
{
    List<LetterTile> letterTilesSelected = new List<LetterTile>();
    
    [SerializeField] GridManager grid;
    [SerializeField] WordsListManager wordsListManager;
    [SerializeField] GameManager gameManager;

    [SerializeField]  GraphicRaycaster m_Raycaster;
    [SerializeField] EventSystem m_EventSystem;

    PointerEventData m_PointerEventData;

    LetterTile firstLetter;

    void ClearSelection()
    {
        foreach (var letter in letterTilesSelected)
        {
            letter.ClearColor();
        }
        letterTilesSelected.Clear();
    }

    void Update()
    {

        //Set up the new Pointer Event
        m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = Input.mousePosition;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("ended");
            ClearSelection();
            firstLetter = null;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("started");
            foreach (RaycastResult result in results)
            {
                LetterTile letterSelected = result.gameObject.GetComponent<LetterTile>();

                if (letterSelected != null)
                {
                    letterTilesSelected.Add(grid.letterTiles[letterSelected.xPos, letterSelected.yPos]);
                    grid.letterTiles[letterSelected.xPos, letterSelected.yPos].SetColor(Color.magenta);
                    firstLetter = letterSelected;
                }
            }

        }

        if (Input.GetMouseButton(0))
        {
            Debug.Log("Moved");

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                LetterTile letterSelected = result.gameObject.GetComponent<LetterTile>();

               if (letterSelected != null)
               {
                        if (firstLetter !=null )// (letterSelected ==    letterTilesSelected[0])
                        {
             
               
                        if (firstLetter == letterSelected)
                        {
                            ClearSelection();
                            letterTilesSelected.Add(grid.letterTiles[letterSelected.xPos, letterSelected.yPos]);
                            grid.letterTiles[letterSelected.xPos, letterSelected.yPos].SetColor(Color.magenta);
                        }
                        else
                        {
                            if (firstLetter.xPos == letterSelected.xPos)
                            {
                                ClearSelection();
                                if (firstLetter.yPos < letterSelected.yPos)
                                {
                                    for (int i = firstLetter.yPos; i < letterSelected.yPos + 1; i++)
                                    {
                                        letterTilesSelected.Add(grid.letterTiles[letterSelected.xPos, i]);
                                        grid.letterTiles[letterSelected.xPos, i].SetColor(Color.magenta);
                                    }
                                }
                                else if (firstLetter.yPos > letterSelected.yPos)
                                {
                                    for (int i = letterSelected.yPos; i < firstLetter.yPos + 1; i++)
                                    {
                                        letterTilesSelected.Add(grid.letterTiles[letterSelected.xPos, i]);
                                        grid.letterTiles[letterSelected.xPos, i].SetColor(Color.magenta);
                                    }
                                }
                            }

                            if (firstLetter.yPos == letterSelected.yPos)
                            {
                                ClearSelection();
                                if (firstLetter.xPos<letterSelected.xPos)
                                {
                                    for (int i = firstLetter.xPos; i < letterSelected.xPos + 1; i++)
                                    {
                                        letterTilesSelected.Add(grid.letterTiles[i, letterSelected.yPos]);
                                        grid.letterTiles[i, letterSelected.yPos].SetColor(Color.magenta);
                                    }
                                }
                                else if (firstLetter.xPos > letterSelected.xPos)
                                {
                                    for (int i = letterSelected.xPos; i < firstLetter.xPos + 1; i++)
                                    {
                                        letterTilesSelected.Add(grid.letterTiles[i, letterSelected.yPos]);
                                        grid.letterTiles[i, letterSelected.yPos].SetColor(Color.magenta);
                                    }
                                }
                            }

                            if (Mathf.Abs( firstLetter.xPos - firstLetter.yPos) == Mathf.Abs( letterSelected.xPos-letterSelected.yPos) ||
                               firstLetter.xPos + firstLetter.yPos == letterSelected.xPos + letterSelected.yPos)
                            {
                                ClearSelection();
                                //x++ y++
                                if (firstLetter.xPos < letterSelected.xPos && firstLetter.yPos < letterSelected.yPos)
                                {
                                    for (int i = firstLetter.xPos, j = firstLetter.yPos; i < letterSelected.xPos + 1; i++, j++)
                                    {
                                        letterTilesSelected.Add(grid.letterTiles[i, j]);
                                        grid.letterTiles[i, j].SetColor(Color.magenta);
                                    }
                                }
                                //x++ y--
                                else if (firstLetter.xPos < letterSelected.xPos && firstLetter.yPos > letterSelected.yPos)
                                {
                                    for (int i = firstLetter.xPos, j = firstLetter.yPos; i < letterSelected.xPos + 1; i++, j--)
                                    {
                                        letterTilesSelected.Add(grid.letterTiles[i, j]);
                                        grid.letterTiles[i, j].SetColor(Color.magenta);
                                    }
                                }
                                //x-- y--
                                else if (firstLetter.xPos > letterSelected.xPos && firstLetter.yPos > letterSelected.yPos)
                                {
                                    for (int i = letterSelected.xPos, j = letterSelected.yPos; i < firstLetter.xPos + 1; i++, j++)
                                    {
                                        letterTilesSelected.Add(grid.letterTiles[i, j]);
                                        grid.letterTiles[i, j].SetColor(Color.magenta);
                                    }
                                }
                                //x-- y++
                                else if (firstLetter.xPos > letterSelected.xPos && firstLetter.yPos < letterSelected.yPos)
                                {
                                    for (int i = letterSelected.xPos, j = letterSelected.yPos; i < firstLetter.xPos + 1; i++, j--)
                                    {
                                        letterTilesSelected.Add(grid.letterTiles[i, j]);
                                        grid.letterTiles[i, j].SetColor(Color.magenta);
                                    }
                                }
                            }
                        }


                        

                           string wordSelected = string.Empty;

                            foreach (var letter in letterTilesSelected)
                           {
                               wordSelected = wordSelected + letter.letter.ToString();
                           }


                            if (wordsListManager.IsAWordToCheck(wordSelected))
                           {
                                foreach (var letter in letterTilesSelected)
                                {
                                    letter.SetDefaultColor(Color.white);
                                    letter.EnableBackground();
                                }
                            ClearSelection();
                            firstLetter = null;
                                gameManager.CheckEndGame();
                           }
                        }
                    
                }
            }
        }
    } 
}
