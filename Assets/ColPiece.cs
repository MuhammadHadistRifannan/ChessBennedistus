using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class ColPiece : MonoBehaviour
{
    public Sprite a,b,c,d,e,f,g,h;


    public void ActivateCol(int xP , int yP)
    {
        SetPos(xP , yP);
        switch (this.name)
        {
            case "a" : GetComponent<SpriteRenderer>().sprite = a; break;
            case "b" : GetComponent<SpriteRenderer>().sprite = b; break;
            case "c" : GetComponent<SpriteRenderer>().sprite = c; break;
            case "d" : GetComponent<SpriteRenderer>().sprite = d; break;
            case "e" : GetComponent<SpriteRenderer>().sprite = e; break;
            case "f" : GetComponent<SpriteRenderer>().sprite = f; break;
            case "g" : GetComponent<SpriteRenderer>().sprite = g; break;
            case "h" : GetComponent<SpriteRenderer>().sprite = h; break;
        }
    }

    private void SetPos(int xP , int yP)
    {
        float xPos = xP;
        float yPos = yP; 
        xPos -= 3.5f; 
        yPos -= 5; 
        transform.position = new Vector2(xPos , yPos); 
    }
}
