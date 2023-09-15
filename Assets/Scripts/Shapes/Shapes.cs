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
    NotEatable,
}