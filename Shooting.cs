using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _shootDelay;
    [SerializeField] private Transform _target;
    [SerializeField] private bool _isWork;

    void Start() 
    {
           StartCoroutine(FireBurst());
    }
   
    IEnumerator FireBurst()
    {
        var waitForDelay = new WaitForSeconds(_shootDelay);

        while (_isWork)
        {
            var targetDirection = (_target.position - transform.position).normalized;
            var bullet = Instantiate(_bullet, transform.position + targetDirection, Quaternion.identity);

            bullet.GetComponent<Rigidbody>().transform.up = targetDirection;
            bullet.GetComponent<Rigidbody>().velocity = targetDirection * _force;

            yield return waitForDelay;
        }
    }
}