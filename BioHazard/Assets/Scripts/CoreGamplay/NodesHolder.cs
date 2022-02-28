using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NodesHolder : MonoBehaviour
{
    [SerializeField] private List<Node> _allNodes;

    private float _time;

    public List<Node> AllNodes { get => _allNodes; set => _allNodes = value; }

    private void Start()
    {
        _allNodes = FindObjectsOfType<Node>().ToList();
        _time = Time.time;
    }
}
