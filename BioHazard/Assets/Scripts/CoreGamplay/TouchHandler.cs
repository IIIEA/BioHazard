using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TouchHandler : Singletone<TouchHandler>, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    [SerializeField] private List<Node> _nodes = new List<Node>();
    [SerializeField] private Transform _cursor;
    [SerializeField] private NodeGroup _group;
    [SerializeField] private GameObject _branchPrefab;
    [SerializeField] bool isSwiper;

    public UnityEvent OnComplite;
    public UnityEvent OnCreateBranch;
    public Transform canvas;
    public Node SelectNode;

    public List<Node> Nodes { get => _nodes; set => _nodes = value; }
    public NodeGroup Group { get => _group; set => _group = value; }
    public bool IsSwiper { get => isSwiper; set => isSwiper = value; }
    public Vector3 CursorPosition => _cursor.position;

    public bool AddNode(Node node)
    {
        if (_nodes.Contains(node)) return false;
        _nodes.Add(node);
        return true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _cursor.position = eventData.pointerCurrentRaycast.screenPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isSwiper = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Complite();
    }

    public void Complite()
    {
        if (SelectNode)
        {
            OnCreateBranch.Invoke();
            CreateBranchs();
        }

        Nodes.Clear();
        OnComplite.Invoke();
        isSwiper = false;
        OnComplite.RemoveAllListeners();
    }

    private void CreateBranchs()
    {
        foreach (var item in _nodes)
        {
            if (item.Group != Group) continue;
            if (item.Count == 0) continue;
            if (item == SelectNode) continue;
            var t = Instantiate(_branchPrefab, canvas);
            var value = item.Count / 2;
            item.Count -= value;

        }
    }
}
