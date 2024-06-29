using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent<Color> _unityEvent1;
    [SerializeField] private UnityEvent _unityEvent;
    [SerializeField] private float _force = 200;
    public Color Color { get;  private set; }
    private Camera _mainCamera;
    private Rigidbody _rigidbody;
    private Material _material;
    
    private void Awake()
    {
        _mainCamera = Camera.main;
        _material = transform.GetComponent<Renderer>().materials[0];
        _rigidbody = transform.GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }
        var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            _rigidbody.velocity = Vector3.zero;
            MoveTowardsSelectedPoint(hit);
            _unityEvent.Invoke();
        }
    }
    
    private void MoveTowardsSelectedPoint(RaycastHit hitInfo)
    {
        var direction = (hitInfo.point - transform.position).normalized;
        _rigidbody.AddForce(new Vector3(direction.x, 0, direction.z) * _force);
    }

    public void SetColor(Color color)
    {
        Color = color;
        _material.color = color;
    }
}
