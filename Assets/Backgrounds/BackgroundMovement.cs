using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private Transform _background1;
    [SerializeField] private Transform _background2;
    [SerializeField] private Transform _background3;
    [SerializeField] private SpriteRenderer _background1sp;
    [SerializeField] private SpriteRenderer _background2sp;
    [SerializeField] private SpriteRenderer _background3sp;
    [SerializeField] private Transform _cam;

    private float _currentLenght;

    private void Start()
    {
        _currentLenght = _background1sp.bounds.size.x;
    }

    private void Update()
    {
        if (_cam.position.x - _background1.position.x > _currentLenght)
        {
            _background1.position = new Vector3(_background3.position.x + _background3sp.bounds.size.x, _background1.position.y, _background1.position.z);
        }
        if (_cam.position.x - _background2.position.x > _currentLenght)
        {
            _background2.position = new Vector3(_background1.position.x + _background1sp.bounds.size.x, _background2.position.y, _background2.position.z);
        }
        if (_cam.position.x - _background3.position.x > _currentLenght)
        {
            _background3.position = new Vector3(_background2.position.x + _background2sp.bounds.size.x, _background3.position.y, _background3.position.z);
        }
    }
}