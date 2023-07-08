using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _count;
    private int _currentPoint;

    void Start()
    {
        _count = _path.childCount;
        _points = new Transform[_count];

        for (int i = 0; i < _count; i++)
            _points[i] = _path.GetChild(i);
        
    }

    void Update()
    {
        Transform target = _points[_currentPoint];
        var direction = (target.position - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (target.position == transform.position) 
        {
            _currentPoint++;

            if (_currentPoint >= _count) 
            {
                _currentPoint = 0;
            }
        }
    }
}
