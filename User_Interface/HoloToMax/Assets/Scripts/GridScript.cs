using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public int[,] grid;

    void Start()
    {
        grid = new int[8, 16];
    }
}
