using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private Color _color;
    private RandomPoint _randomPoint;
    private Colors _colors;
    private Material _material;
    
    public void Initialize(RandomPoint randomPoint, Colors colors)
    {
        _colors = colors;
        _randomPoint = randomPoint;
        var renderer = transform.GetChild(0).GetComponent<Renderer>();
        _material = renderer.materials[0];
        SetPosition();
        SetColor();
        _material.color = _color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            player.SetColor(_color);
            SetPosition();
            //SetColor();
            var color = _colors.SetColor();
            while (color == _color)
            {
                color = _colors.SetColor();
            }

            _material.color = color;
            _color = color;
        }
    }

    private void SetPosition()
    {
        transform.position = _randomPoint.GetRandomPoint();
    }

    private void SetColor()
    {
        var color = _colors.SetColor();
        _material.color = color;
        _color = color;
    }
}
