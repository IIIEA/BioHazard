using System;
using UnityEngine;

[Serializable]
public struct NodeColor
{
    [SerializeField] private string _colorName;
    [SerializeField] private Color _colorNode;

    public string ColorName => _colorName;
    public Color ColorNode => _colorNode; 
}
