using System;
using UnityEngine;

[Serializable]
public struct NodeColor
{
    [SerializeField] private string _colorName;
    [SerializeField] private Color _centerNodeColor;

    public string ColorName => _colorName;
    public Color CenterNodeColor => _centerNodeColor; 
}
