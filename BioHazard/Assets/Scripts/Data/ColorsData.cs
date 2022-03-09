using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorsData", menuName = "Data/ColorData", order = 51)]
public class ColorsData : ScriptableObject
{
    [SerializeField] private List<NodeColor> _nodeColors;

    public Color DefaultColor => Color.white;
    public List<NodeColor> NodeColors => _nodeColors;

    public Color GetColorByName(string name)
    {
        if (_nodeColors != null)
        {
            foreach (var color in _nodeColors)
            {
                if (name == color.ColorName)
                    return color.ColorNode;
            }
        }

        return DefaultColor;
    }
}
