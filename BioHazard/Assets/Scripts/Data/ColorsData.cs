using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorsData", menuName = "Data/ColorData", order = 51)]
public class ColorsData : ScriptableObject
{
    [SerializeField] private List<NodeColor> _nodeColors;

    public List<NodeColor> NodeColors => _nodeColors;
}
