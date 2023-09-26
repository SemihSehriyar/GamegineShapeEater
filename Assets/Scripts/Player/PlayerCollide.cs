using DG.Tweening;
using System;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    [SerializeField] private ShapeInfo _currentObj;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;


    public static event Action OnHit;

    private void OnTriggerEnter2D(Collider2D collider)
    {
		if (collider.TryGetComponent(out ICollectable collectable)) 
        {
            _currentObj = collectable.OnHit();
            _spriteRenderer.sprite = _currentObj.sprite;
            _animator.runtimeAnimatorController = _currentObj.animator;
            _spriteRenderer.color = _currentObj.color;
           
        }
    }
}