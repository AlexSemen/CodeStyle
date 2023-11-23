using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _path;

    private Transform[] _points;
    private int _currentTargetPoint;

    void Start() 
    {
        _currentTargetPoint = 0;
        _points = _path.GetComponentsInChildren<Transform>();
    }

    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position , _points[_currentTargetPoint].position, _speed * Time.deltaTime);

        if (transform.position == _points[_currentTargetPoint].position)
        {
            TakeNextPointTarget();
            UpdateRotation();
        }
    }

    public void TakeNextPointTarget(){
        _currentTargetPoint++;

            if (_currentTargetPoint == _points.Length)
                _currentTargetPoint  = 0;
    }

    private void UpdateRotation()
    {
        var nextPointDirection = _points[_currentTargetPoint].transform.position;
        transform.forward = nextPointDirection - transform.position;
    }
}