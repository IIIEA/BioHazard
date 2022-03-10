using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGroup : MonoBehaviour
{
    [SerializeField] private ColorsData _colors;
    [SerializeField] private ColorList _colorList;
    [SerializeField] protected List<Node> GroupNodes = new List<Node>();
    public Color GroupColor { get; private set; }
    public List<Node> Nodes { get => GroupNodes; set => GroupNodes = value; }

    private void OnValidate()
    {
        GroupColor = _colors.GetColorByName(_colorList.ToString());
    }
}
