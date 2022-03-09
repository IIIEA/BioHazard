using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGroup : MonoBehaviour
{
    [SerializeField] private ColorsData _colors;

    private Color _groupColor;

    public ColorList ColorList;

    public Color GroupColor => _groupColor;

    private void OnValidate()
    {
        _groupColor = _colors.GetColorByName(ColorList.ToString());
    }
}
