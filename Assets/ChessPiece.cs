using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

    public enum Piece
    {
        black_pawn , black_knight , black_rook , black_king , black_queen , black_bishop,
        white_pawn , white_knight , white_rook , white_king , white_queen , white_bishop,
    }

public class ChessPiece : MonoBehaviour
{
    private Piece currentpiece; 

    private int xPos = -1 , yPos = -1;

    public Sprite blackpawn , blackknight , blackrook , blackbishop , blackking , blackqueen; 
    public Sprite whitepawn , whiteknight , whiterook , whitebishop , whiteking , whitequeen; 
    
    public void Activate()
    {
        AdjustPos();

        switch (this.currentpiece)
        {
            case Piece.black_king : GetComponent<SpriteRenderer>().sprite = blackking; break; 
            case Piece.black_queen : GetComponent<SpriteRenderer>().sprite = blackqueen; break; 
            case Piece.black_rook : GetComponent<SpriteRenderer>().sprite = blackrook; break; 
            case Piece.black_knight : GetComponent<SpriteRenderer>().sprite = blackknight; break; 
            case Piece.black_bishop : GetComponent<SpriteRenderer>().sprite = blackbishop; break; 
            case Piece.black_pawn : GetComponent<SpriteRenderer>().sprite = blackpawn; break; 

            case Piece.white_king : GetComponent<SpriteRenderer>().sprite = whiteking; break; 
            case Piece.white_queen : GetComponent<SpriteRenderer>().sprite = whitequeen; break; 
            case Piece.white_rook : GetComponent<SpriteRenderer>().sprite = whiterook; break; 
            case Piece.white_knight : GetComponent<SpriteRenderer>().sprite = whiteknight; break; 
            case Piece.white_bishop : GetComponent<SpriteRenderer>().sprite = whitebishop; break;
            case Piece.white_pawn : GetComponent<SpriteRenderer>().sprite = whitepawn; break;

        }
    }

    private void AdjustPos()
    {
        float x = xPos;
        float y = yPos; 
        // // x *= 0.66f; 
    

        x += -3.5f;
        y += -4f;
        
        transform.position = new Vector3(x, y);
    }

    public void SetPiece(Piece piece)
    {
        currentpiece = piece;
    }

    public Piece GetPiece()
    {
        return currentpiece;
    }

    public int GetXPos()
    {
        return xPos; 
    }

    public int GetYPos()
    {
        return yPos; 
    }

    public void SetXPos(int x)
    {
        xPos = x;
    }

    public void SetYPos(int y)
    {
        yPos = y;
    }


}
