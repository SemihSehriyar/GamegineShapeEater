using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
   
    private void LateUpdate()
    {
        transform.position = new Vector3(_player.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}