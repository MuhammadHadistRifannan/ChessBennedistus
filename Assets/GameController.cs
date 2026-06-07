using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public LayerMask chessPieceLayer;
    public BoardManager boardManager;

    public GameObject blockMovePrefab;

    private bool gameOver;
    private bool whiteTurn; 

    private List<GameObject> GetAllLegalMoves(ChessPiece cp)
    {
        var piece = cp.GetPiece();
                Debug.Log(boardManager.positions[cp.GetXPos() , cp.GetYPos()].GetComponent<ChessPiece>().GetPiece().ToString());

        switch (piece)
        {
            //Slide
            case Piece.white_queen:
                int sc = 0;
                int stepLeft = SlideMoveLeft(cp , cp.GetXPos()-1 , sc);
                int stepRight = SlideMoveRight(cp , cp.GetXPos()+1 , sc);
                int stepUp = SlideMoveUp(cp , cp.GetYPos()+1 , sc);
                int stepDown = SlideMoveDown(cp , cp.GetYPos()-1 , sc);
                int stepDiagonalL = SlideMoveDiagonalLeft(cp.GetXPos()-1 , cp.GetYPos()+1 , sc);
                int stepDiagonalR = SlideMoveDiagonalRight(cp.GetXPos()+1 , cp.GetYPos()+1 , sc);
                
                break; 
            case Piece.white_rook:

                break;
            case Piece.white_bishop:
                break;

            //Step 
            case Piece.white_king: 
                break; 
            case Piece.white_knight: 
                break; 
            case Piece.white_pawn:
                break;
        }

        return null;
    }


    private int SlideMoveUp(ChessPiece piece , int y, int score)
    {
        if (y > 8) return score;

        if (CheckHorizontal(piece , boardManager , y))
        {
            int yPos = y;
            ChessPiece cp = boardManager.positions[piece.GetXPos() , y].GetComponent<ChessPiece>();
            var bl = Instantiate(blockMovePrefab , cp.transform.position , Quaternion.identity);
            Destroy(bl , 0.5f);
            Debug.Log("Atas Nabrak : " + cp.GetPiece().ToString());
            return score;
        }

        return SlideMoveLeft(piece , y+1 , score+1);
    }
    private int SlideMoveDown(ChessPiece piece , int y, int score)
    {
        if (y < 0) return score;

        if (CheckHorizontal(piece , boardManager , y))
        {
            int yPos = y;
            ChessPiece cp = boardManager.positions[piece.GetXPos() , y].GetComponent<ChessPiece>();
            var bl = Instantiate(blockMovePrefab , cp.transform.position , Quaternion.identity);
            Destroy(bl , 0.5f);
            Debug.Log("Bawah Nabrak : " + cp.GetPiece().ToString());
            return score;
        }

        return SlideMoveLeft(piece , y-1 , score+1);
    }

    private int SlideMoveLeft(ChessPiece piece , int x, int score)
    {
        if (piece.GetXPos() - x < 0) return score;

        if (CheckHorizontal(piece , boardManager , x))
        {
            int xPos = x;
            ChessPiece cp = boardManager.positions[xPos , piece.GetYPos()].GetComponent<ChessPiece>();
            var bl = Instantiate(blockMovePrefab , cp.transform.position , Quaternion.identity);
            Destroy(bl , 0.5f);
            Debug.Log("Kiri Nabrak : " + cp.GetPiece().ToString());
            return score;
        }

        return SlideMoveLeft(piece , x-1 , score+1);
    }
    private int SlideMoveRight(ChessPiece piece , int x, int score)
    {
        if (x > 8) return score;

        if (CheckHorizontal(piece , boardManager , x))
        {
            int xPos = x;
            ChessPiece cp = boardManager.positions[xPos , piece.GetYPos()].GetComponent<ChessPiece>();
            Debug.Log("Kanan Nabrak : " + cp.GetPiece().ToString());
            var bl = Instantiate(blockMovePrefab , cp.transform.position , Quaternion.identity);
            Destroy(bl , 0.5f);
            return score;
        }

        return SlideMoveLeft(piece , x+1 , score+1);
    }

    private int SlideMoveDiagonalLeft(int x , int y , int score)
    {
        if (x  < 0 && y > 8) return score; 

        if (CheckDiagonal(boardManager , x , y))
        {
            int xPos = x; 
            int yPos = y;
            ChessPiece cp = boardManager.positions[xPos , yPos].GetComponent<ChessPiece>();
            Debug.Log("Diagonal Kiri Nabrak : " + cp.GetPiece().ToString());
            var bl = Instantiate(blockMovePrefab , cp.transform.position , Quaternion.identity);
            Destroy(bl , 0.5f);
            return score;
        }

        return SlideMoveDiagonalLeft(x - 1 , y+1 , score);
    }
    private int SlideMoveDiagonalRight(int x , int y , int score)
    {
        if (x  > 8 && y > 8) return score; 

        if (CheckDiagonal(boardManager , x , y))
        {
            int xPos = x; 
            int yPos = y;
            ChessPiece cp = boardManager.positions[xPos , yPos].GetComponent<ChessPiece>();
            Debug.Log("Diagonal Kanan Nabrak : " + cp.GetPiece().ToString());
            var bl = Instantiate(blockMovePrefab , cp.transform.position , Quaternion.identity);
            Destroy(bl , 0.5f);
            return score;
        }

        return SlideMoveDiagonalLeft(x - 1 , y+1 , score);
    }

    private bool CheckDiagonal(BoardManager board , int x , int y)
    {
        return board.positions[x , y].GetComponent<ChessPiece>() != null;
    }
    

    private bool CheckVertical(ChessPiece cp , BoardManager board, int y)
    {
        return board.positions[cp.GetXPos() , cp.GetYPos() + y].GetComponent<ChessPiece>() != null;
    }

    private bool CheckHorizontal(ChessPiece cp , BoardManager board , int x)
    {
        return board.positions[x, cp.GetYPos()].GetComponent<ChessPiece>() != null;
    }

    private void Move()
    {
        
    }


    private void DetectTouch()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePos , Vector2.zero , chessPieceLayer);
            if (hit)
            {
                ChessPiece cp = hit.collider.GetComponent<ChessPiece>();
                var moves = GetAllLegalMoves(cp);
                // Debug.Log(cp.GetPiece().ToString());
            }
        }
    }
    void Update()
    {
        DetectTouch();
    }
}
