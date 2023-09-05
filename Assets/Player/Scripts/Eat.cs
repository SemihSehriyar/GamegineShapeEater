using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

                    break;
                case EatableShapes.Square:
                    Destroy(shape.gameObject);
                    break;
                case EatableShapes.Hexagon:
                    Destroy(shape.gameObject);
                    break;

            }
        }
    }
}