using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameData", menuName = "UserData/Game Data", order = 1)]
public class UGameData : ScriptableObject
{
    

    [SerializeField] private int widthTable, heightTable;
    //[SerializeField] private float pivot_x, pivot_y;
    [SerializeField] private int countToWin;

    public int WidthTable { get => widthTable; }
    public int HeightTable { get => heightTable; }
    //public float PivotX { get => pivot_x; }
    //public float PivotY { get => pivot_y; }
    public int CountToWin { get => countToWin; }
}
