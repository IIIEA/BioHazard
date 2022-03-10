using UnityEngine;
using UnityEngine.Events;

public class NodeColorSetter : MonoBehaviour
{
    [SerializeField] private NodeGroup _group;
    [SerializeField] public UnityEvent<Color> OnStartColor;

    public NodeGroup Group
    {
        get => _group;
        set
        {
            if(value != _group)
            {
                _group = value;

                if(_group == null)
                {
                    OnStartColor.Invoke(Color.white);
                }
                else
                {
                    OnStartColor.Invoke(_group.GroupColor);
                }
            }
        }
    }

    void Start()
    {
        if (Group == null)
        {
            OnStartColor.Invoke(Color.white);
        }
        else
        {
            OnStartColor.Invoke(_group.GroupColor);
        }
    }
}
