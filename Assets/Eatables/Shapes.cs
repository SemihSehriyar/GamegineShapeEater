using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes : MonoBehaviour
{
    public EatableShapes eatables;   
}

public enum EatableShapes 
{
    None,
    Circle,
    Square,
    Hexagon,
}