using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridController : MonoBehaviour
{
    public List<GameObject> Buttons;
    [SerializeField] private List<GameObject> currentButtons, checkedButtons;
    [SerializeField] int coloumCount;
    [SerializeField] private TextMeshProUGUI matchCountText;
    public int _matchCount;

    public void ChangeColomCount(int aIndex)
    {
        coloumCount = aIndex;
    }

    public void checkLeadNeighbors(int aIndex)
    {
        if (!currentButtons.Contains(Buttons[aIndex]))
        {
            currentButtons.Add(Buttons[aIndex]);
           
        }
        #region GridEdges

        if (aIndex == 0)
        {
            Debug.Log("Left Up");
            CheckDown(aIndex);
            CheckRight(aIndex);
        }
        else if (aIndex == coloumCount - 1)
        {
            Debug.Log("Right Up");
            CheckDown(aIndex);
            CheckLeft(aIndex);
        }
        else if (aIndex == (coloumCount * coloumCount) - coloumCount)
        {
            Debug.Log("Left Down");
            CheckUp(aIndex);
            CheckRight(aIndex);
        }
        else if (aIndex == (coloumCount * coloumCount) - 1)
        {
            Debug.Log("Right Down");
            CheckUp(aIndex);
            CheckLeft(aIndex);
        }

        #endregion

        #region EdgesColoum

        else if (aIndex % coloumCount == 0)
        {
            Debug.Log("Left Edge");
            CheckUp(aIndex);
            CheckDown(aIndex);
            CheckRight(aIndex);
        }
        else if (aIndex % coloumCount == coloumCount - 1)
        {
            Debug.Log("Right Edge");
            CheckUp(aIndex);
            CheckDown(aIndex);
            CheckLeft(aIndex);
        }

        #endregion

        #region FirstAndLastRow

        else if (aIndex / coloumCount == 0 && aIndex % coloumCount < coloumCount - 1)
        {
            Debug.Log("First Row");
            CheckDown(aIndex);
            CheckRight(aIndex);
            CheckLeft(aIndex);
        }
        else if (aIndex / coloumCount == coloumCount - 1 && aIndex % coloumCount < coloumCount - 1)
        {
            Debug.Log("Last Row");
            CheckUp(aIndex);
            CheckRight(aIndex);
            CheckLeft(aIndex);
        }

        #endregion

        #region Middle

        else
        {
            Debug.Log("Midlle");
            CheckUp(aIndex);
            CheckDown(aIndex);
            CheckRight(aIndex);
            CheckLeft(aIndex);
        }

        #endregion
        
        if(currentButtons.Count<3){currentButtons.Clear();}
        else
        {
            Debug.Log("Win baby");
            foreach (var item in currentButtons)
            {
                item.GetComponent<CheckNeighbors>().Reset();
            }
            currentButtons.Clear();
            _matchCount++;
            matchCountText.text = "Match Count: " + _matchCount.ToString();
        }
       
        
       
    }
     public void checkNeighbors(int aIndex)
    {
        if (!currentButtons.Contains(Buttons[aIndex]))
        {
            currentButtons.Add(Buttons[aIndex]);
        }
      

        #region GridEdges

        if (aIndex == 0)
        {
            Debug.Log("Left Up");
            CheckDown(aIndex);
            CheckRight(aIndex);
        }
        else if (aIndex == coloumCount - 1)
        {
            Debug.Log("Right Up");
            CheckDown(aIndex);
            CheckLeft(aIndex);
        }
        else if (aIndex == (coloumCount * coloumCount) - coloumCount)
        {
            Debug.Log("Left Down");
            CheckUp(aIndex);
            CheckRight(aIndex);
        }
        else if (aIndex == (coloumCount * coloumCount) - 1)
        {
            Debug.Log("Right Down");
            CheckUp(aIndex);
            CheckLeft(aIndex);
        }

        #endregion

        #region EdgesColoum

        else if (aIndex % coloumCount == 0)
        {
            Debug.Log("Left Edge");
            CheckUp(aIndex);
            CheckDown(aIndex);
            CheckRight(aIndex);
        }
        else if (aIndex % coloumCount == coloumCount - 1)
        {
            Debug.Log("Right Edge");
            CheckUp(aIndex);
            CheckDown(aIndex);
            CheckLeft(aIndex);
        }

        #endregion

        #region FirstAndLastRow

        else if (aIndex / coloumCount == 0 && aIndex % coloumCount < coloumCount - 1)
        {
            Debug.Log("First Row");
            CheckDown(aIndex);
            CheckRight(aIndex);
            CheckLeft(aIndex);
        }
        else if (aIndex / coloumCount == coloumCount - 1 && aIndex % coloumCount < coloumCount - 1)
        {
            Debug.Log("Last Row");
            CheckUp(aIndex);
            CheckRight(aIndex);
            CheckLeft(aIndex);
        }

        #endregion

        #region Middle

        else
        {
            Debug.Log("Midlle");
            CheckUp(aIndex);
            CheckDown(aIndex);
            CheckRight(aIndex);
            CheckLeft(aIndex);
        }

        #endregion
        
        
       
        
       
    }

    #region CheckingGridByIndexFuctions

    void CheckRight(int aIndex)
    {
        if (Buttons[aIndex + 1].tag == "Checked")
        {
            if (!currentButtons.Contains(Buttons[aIndex+1]))
            {
                currentButtons.Add(Buttons[aIndex+1]);
                checkNeighbors(aIndex+1);
                
            }
     
        }
        else return;
    }

    void CheckLeft(int aIndex)
    {
        if (Buttons[aIndex - 1].tag == "Checked")
        {
            
            if (!currentButtons.Contains(Buttons[aIndex-1]))
            {
                currentButtons.Add(Buttons[aIndex-1]);
                checkNeighbors(aIndex-1);
            }
        }
        else return;
    }

    void CheckUp(int aIndex)
    {
        if (Buttons[aIndex - coloumCount].tag == "Checked")
        {

            if (!currentButtons.Contains(Buttons[aIndex-coloumCount]))
            {
                currentButtons.Add(Buttons[aIndex-coloumCount]);
                checkNeighbors(aIndex-coloumCount);
            }
        }
        else return;
    }

    void CheckDown(int aIndex)
    {
        if (Buttons[aIndex + coloumCount].tag == "Checked")
        {
            if (!currentButtons.Contains(Buttons[aIndex + coloumCount]))
            {
                currentButtons.Add(Buttons[aIndex + coloumCount]);
                checkNeighbors(aIndex+coloumCount);
            }
        }
        else return;
    }

    #endregion

    public void Reset()
    {
        _matchCount = 0; 
        matchCountText.text = "Match Count: " + _matchCount.ToString();
    }
}