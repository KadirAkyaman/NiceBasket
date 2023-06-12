using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ball Type", menuName = "Ball Type")]

public class BallType : ScriptableObject
{
    public float throwPower;
    public Vector3 ballScale;
    public Material mainColor;
    public Material lineColor;
}
