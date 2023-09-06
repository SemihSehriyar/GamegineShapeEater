using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Eat : MonoBehaviour
{
    [SerializeField] private GameObject _square;
    [SerializeField] private GameObject _circle;
    [SerializeField] private GameObject _hexagon;

    private void Start()
    {
        _square.gameObject.SetActive(true);
        _circle.gameObject.SetActive(false);
        _hexagon.gameObject.SetActive(false);   
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        
        if(collider.GetComponent<Shapes>() != null) 
        {
            var shape = collider.GetComponent<Shapes>();
            switch (shape.eatables) 
            {
                case EatableShapes.None: 
                    break;
                case EatableShapes.Circle:
                    Destroy(shape.gameObject);
                    _square.gameObject.SetActive(false);
                    _circle.gameObject.SetActive(true);
                    _hexagon.gameObject.SetActive(false);
                    break;
                case EatableShapes.Square:
                    Destroy(shape.gameObject);
                    _square.gameObject.SetActive(true);
                    _circle.gameObject.SetActive(false);
                    _hexagon.gameObject.SetActive(false);
                    break;
                case EatableShapes.Hexagon:
                    Destroy(shape.gameObject);
                    _square.gameObject.SetActive(false);
                    _circle.gameObject.SetActive(false);
                    _hexagon.gameObject.SetActive(true);
                    break;
            }
        }
    }
}