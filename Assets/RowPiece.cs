using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowPiece : MonoBehaviour
{
    public Sprite one,two,three,four,five,six,seven,zero;
    
    public void ActivateRow(int x , int y)
    {
        SetPos(x , y);
        switch (this.name)
        {
            case "0" : GetComponent<SpriteRenderer>().sprite = zero; break;
            case "1" : GetComponent<SpriteRenderer>().sprite = one; break;
            case "2" : GetComponent<SpriteRenderer>().sprite = two; break;
            case "3" : GetComponent<SpriteRenderer>().sprite = three; break;
            case "4" : GetComponent<SpriteRenderer>().sprite = four; break;
            case "5" : GetComponent<SpriteRenderer>().sprite = five; break;
            case "6" : GetComponent<SpriteRenderer>().sprite = six; break;
            case "7" : GetComponent<SpriteRenderer>().sprite = seven; break;
        }
    }

    public void SetPos(int x , int y)
    {
        float xPos = x; 
        float yPos = y; 

        xPos -= 4.5f;
        yPos -= 4f; 
        transform.position = new Vector2(xPos , yPos);        

    }
}
