using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class ImageController : MonoBehaviour
{
    [SerializeField] private Image[] _images;
    private Color[] _imageColors;
    private Color[] _colors;

    public void Initialize(Colors colors)
    {
        //_colors = colors.GetColors();
        for (int i = 0; i < _images.Length - 1; i++)
        {
            //_images[i].color = _colors[i];
        }
    }
}
