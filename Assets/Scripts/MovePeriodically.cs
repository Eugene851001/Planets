using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePeriodically : MonoBehaviour
{
    [SerializeField] private float _amplitide;
    [SerializeField] private float _periodSeconds;
    [SerializeField] private Vector3 _moveTo;

    private float _speed;
    private Vector3 _startPosition;
    private Vector3 _moveVector;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 4 * _amplitide / (_periodSeconds * 1000);
        _startPosition = transform.position;
        _moveVector = (transform.position - _moveTo).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_startPosition, transform.position) > _amplitide)
        {
            _moveVector = -_moveVector;
        }

        transform.Translate(_moveVector * _speed * Time.deltaTime);
    }
}
