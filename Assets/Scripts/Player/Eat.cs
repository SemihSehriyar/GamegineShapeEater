using DG.Tweening;
using UnityEngine;

public class Eat : MonoBehaviour
{
    [SerializeField] private Missions _mission;
    [SerializeField] private GameObject _square;
    [SerializeField] private GameObject _circle;
    [SerializeField] private GameObject _hexagon;
    [SerializeField] private AudioSource _eatSrc;

    [SerializeField] private float _duration;
    [SerializeField] private float _strength;
    [SerializeField] private int _vibrato;
    [SerializeField] private float _randomness;

    private void OnTriggerEnter2D(Collider2D collider)
    {  
        if(collider.GetComponent<Shapes>() != null) 
        {
            Shapes shape = collider.GetComponent<Shapes>();
            _mission.EatedShape(shape.eatables);
            switch (shape.eatables) 
            {
                case EatableShapes.None: 
                    break;

                case EatableShapes.Circle:

                    _eatSrc.Play();
                    Destroy(shape.gameObject);
                    _square.gameObject.SetActive(false);
                    _circle.gameObject.SetActive(true);
                    _hexagon.gameObject.SetActive(false);
                    break;

                case EatableShapes.Square:

                    _eatSrc.Play();
                    Destroy(shape.gameObject);
                    _square.gameObject.SetActive(true);
                    _circle.gameObject.SetActive(false);
                    _hexagon.gameObject.SetActive(false);
                    break;

                case EatableShapes.Hexagon:

                    _eatSrc.Play();
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