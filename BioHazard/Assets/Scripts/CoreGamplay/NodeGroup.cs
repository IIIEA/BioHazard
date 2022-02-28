using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class NodeGroup : MonoBehaviour
{
    [SerializeField] private Color _groupColor;
    [SerializeField] private float _speed;
    [SerializeField] private List<Node> _nodes = new List<Node>();

    public float Speed => _speed;
    public Color GroupColor { get => _groupColor; set => _groupColor = value; }

    public void AddNode(Node node)
    {

    }

    public void RemoveNode(Node node)
    {

    }
}
