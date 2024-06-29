using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _texts;
    [SerializeField] private Image[] _images;
    private int _moveCount;
    private readonly List<Color> _colors = new ();
    private readonly List<int> _count = new();

    public void GetMove()
    {
        _moveCount++;
        _texts[3].text = _moveCount.ToString();
    }

    public void SetInitialNumberOfGifts(Dictionary<Color,int> dictionary)
    {
        foreach (var i in dictionary)
        {
            _colors.Add(i.Key);
            _count.Add(i.Value);
        }

        for (int i = 0; i < _texts.Length - 1; i++)
        {
            _texts[i].text = _count[i].ToString();
        }
        //SetColors(_colors);
    }

    private void SetColors(List<Color> colors)
    {
        for (int i = 0; i < _images.Length - 1; i++)
        {
            _images[i].color = colors[i];
        }
    }

    public void CountTheRemainingGifts(Color color)
    {
        for (int i = 0; i < _colors.Count; i++)
        {
            if (color == _colors[i])
            {
                var q= --_count[i];
                _texts[i].text = q.ToString();
            }
        }
    }
    
    private void Awake()
    {
        foreach (var text in _texts)
        {
            text.text = 0.ToString();
        }
    }
}
