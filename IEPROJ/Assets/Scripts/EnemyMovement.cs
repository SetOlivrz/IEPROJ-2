using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 9;
    [SerializeField] private float _rotation = 1.5f;
    private Transform _target;

    private void Awake()
    {
        _target = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        var dir = _target.position - transform.position;
        transform.up = Vector3.MoveTowards(transform.up, dir, _rotation * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position,transform.position + transform.up, _speed * Time.deltaTime);
    }
}
