using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    public GameObject[,] positions = new GameObject[8,8]; 
    private List<GameObject> playerBlack;
    private List<GameObject> playerWhite;


    private GameObject[] cols;

    public GameObject  piece; 
    public GameObject colPiece;

    public GameObject rowPiece; 

    public float offset; 
    void InitializePiece()
    {
        playerWhite = new List<GameObject>
        {
            Create(Piece.white_rook , 0 , 0), Create(Piece.white_rook , 7, 0) , 
            Create(Piece.white_knight , 1, 0) , Create(Piece.white_knight , 6 , 0),
            Create(Piece.white_bishop , 2 , 0), Create(Piece.white_bishop , 5,0),
            Create(Piece.white_king , 3 , 0) , Create(Piece.white_queen , 4,0) 
        };

        playerBlack = new List<GameObject>
        {
            Create(Piece.black_rook , 0,7) , Create(Piece.black_rook , 7 , 7)   ,
            Create(Piece.black_knight , 1,7) , Create(Piece.black_knight , 6 , 7),
            Create(Piece.black_bishop , 2, 7) , Create(Piece.black_bishop , 5,7),
            Create(Piece.black_king , 3, 7),Create(Piece.black_queen , 4, 7)
        };

        for (int i = 0; i < 8; i++)
        {
            playerWhite.Add(Create(Piece.white_pawn , i  , 1));
        }

        for (int i = 0; i < 8; i++)
        {
            playerBlack.Add(Create(Piece.black_pawn , i  , 6));
        }

        Debug.Log(playerWhite.Count);

        for (int i = 0; i < playerWhite.Count; i++)
        {
            SetPositionBoard(playerWhite[i]);
        }

        for (int j = 0; j < playerBlack.Count; j++)
        {
            SetPositionBoard(playerBlack[j]);
        }
    }


    public GameObject Create(Piece pc , int x , int y)
    {
        GameObject obj = Instantiate(piece , new Vector3(x , y) , Quaternion.identity);
        ChessPiece cp = obj.GetComponent<ChessPiece>();
        cp.SetPiece(pc);    
        cp.SetXPos(x);
        cp.SetYPos(y);  
        cp.Activate();
        return obj;
    }


    public void InitializeColsAndRow()
    {
        int x = 0 , y = 0; 
        char[] letter = "abcdefgh".ToCharArray();
        char[] numbers = "01234567".ToCharArray();
        while (x < 8)
        {
            GameObject obj = Instantiate(colPiece , new Vector3(x , y) , Quaternion.identity);
            ColPiece cp = obj.GetComponent<ColPiece>(); 
            cp.name = letter[x].ToString();
            cp.ActivateCol(x , y);
            x++;
        }
        x = 0;
        while (y < 8)
        {
            GameObject obj = Instantiate(rowPiece , new Vector3(x , y) , Quaternion.identity);
            RowPiece rp = obj.GetComponent<RowPiece>();
            rp.name = numbers[y].ToString();
            rp.ActivateRow(x , y);
            y++;
        }

    }

    public void SetPositionBoard(GameObject piece)
    {
        ChessPiece cp = piece.GetComponent<ChessPiece>();
        positions[cp.GetXPos(), cp.GetYPos()] = piece;
    }


    void Start()
    {
        InitializePiece();
        InitializeColsAndRow();
    }
}
