using UnityEngine;

public interface ICollectable 
{
    GameObject GetPlayerShape();
    EatableShapes GetMyShape();
}