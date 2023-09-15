using DG.Tweening;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Eat : MonoBehaviour
{
    [SerializeField] private GameObject _square;
    [SerializeField] private GameObject _circle;
    [SerializeField] private GameObject _hexagon;

    [SerializeField] private float _duration;
    [SerializeField] private float _strength;
    [SerializeField] private int _vibrato;
    [SerializeField] private float _randomness;

    private Rigidbody2D _players;

    private void Start()
    {
        _square.gameObject.SetActive(true);
        _circle.gameObject.SetActive(false);
        _hexagon.gameObject.SetActive(false);

        _players = GetComponent<Rigidbody2D>();
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

                case EatableShapes.NotEatable:
                    transform.DOShakePosition(_duration, _strength, _vibrato, _randomness);
                    break;
            }
        }
    }
}