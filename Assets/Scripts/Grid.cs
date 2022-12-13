using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid
{
    private int width;
    private int height;
    private int[,] gridArray;
    private float cellSize;
    public Grid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;


        gridArray = new int[width, height];
        for(int x = 0 ;x<gridArray.GetLength(0); x++)
        {
            for(int y = 0; y<gridArray.GetLength(1); y++)
            {
                UtilsClass.CreateWorldText(gridArray[x, y].ToString(),null, getWorldPosition(x,y),20,Color.white,TextAnchor.MiddleCenter);
                Debug.DrawLine(getWorldPosition(x,y),getWorldPosition(x, y+1),Color.white, 100f);
                Debug.DrawLine(getWorldPosition(x,y),getWorldPosition(x+1, y),Color.white, 100f);
                Debug.Log(x+ ", "+ y);
            }
        }
    }
    private Vector3 getWorldPosition(int x, int y)
    {
        return new Vector3(x, y)* cellSize;
    }
    
}
