using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _follow;
    [SerializeField] private float _speed;

    private Vector3 _position;
    private Vector3 _cameraEndPosition;
    private Vector3 _cameraStartPosition;

    private void Start()
        => _position = transform.position - _follow.transform.position;

    private void Update()
    {
        _cameraStartPosition = transform.position;
        _cameraEndPosition = new Vector3(_follow.transform.position.x + _position.x, _cameraStartPosition.y, _cameraStartPosition.z);
        transform.position = Vector3.MoveTowards(_cameraStartPosition, _cameraEndPosition, _speed * Time.deltaTime);
    }
}
