using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private int _countUnits;
    [SerializeField] private int _maxCountUnits;
    [SerializeField] private TMP_Text _currentCountText;
    [SerializeField] private NodeGroup _nodeGroup;
    [SerializeField] public UnityEvent<Color> OnStColor;
    [SerializeField] public UnityEvent OnSelect;
    [SerializeField] public UnityEvent OnDiselect; 

    private bool _isSelected;

    public bool IsSelected => _isSelected;

    public int MaxCount { get => _maxCountUnits; set => _maxCountUnits = value; }

    public int Count
    {
        get => _countUnits;
        set
        {
            _countUnits = value;
            _currentCountText.text = Count.ToString();
        }
    }
    public NodeGroup Group
    {
        get => _nodeGroup;
        set
        {
            if (value != _nodeGroup)
            {
                _nodeGroup?.RemoveNode(this);
                _nodeGroup = value;

                if (_nodeGroup == null)
                {
                    OnStColor.Invoke(Color.white);
                }
                else
                {
                    _nodeGroup.AddNode(this);
                    OnStColor.Invoke(_nodeGroup.GroupColor);
                    Diselect();
                }
            }
        }
    }

    IEnumerator Increment()
    {
        while (true)
        {
            if (Group)
            {
                if (Count > MaxCount)
                {
                    Count--;
                }
                if (Count < MaxCount)
                {
                    Count++;
                }
                yield return new WaitForSeconds(1f / Group.Speed);
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    void Start()
    {
        StartCoroutine(Increment());
        
        if (_nodeGroup == null)
        {
            OnStColor.Invoke(Color.white);
        }
        else
        {
            _nodeGroup.AddNode(this);
            OnStColor.Invoke(_nodeGroup.GroupColor);

        }
    }

    public void SelectWhitOutLine()
    {
        _isSelected = true;
        OnSelect.Invoke();
    }

    public void Select()
    {
        OnSelect.Invoke();
        SelectWhitOutLine();
    }

    public void Diselect()
    {
        print(name);
        _isSelected = false;
        OnDiselect.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (TouchHandler.Instance.Group == Group)
        {
            if (TouchHandler.Instance.AddNode(this))
            {
                SelectWhitOutLine();
                TouchHandler.Instance.OnComplite.AddListener(Diselect);
            }
            else
            {
                TouchHandler.Instance.SelectNode = this;
                TouchHandler.Instance.Complite();
            }
        }
        else
        {
            TouchHandler.Instance.SelectNode = this;
            TouchHandler.Instance.Complite();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (TouchHandler.Instance.IsSwiper)
        {
            if (TouchHandler.Instance.Group == Group)
            {
                if (TouchHandler.Instance.AddNode(this))
                {
                    Select();
                    TouchHandler.Instance.OnComplite.AddListener(Diselect);
                }
            }

            TouchHandler.Instance.SelectNode = this;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (TouchHandler.Instance.SelectNode == this)
        {
            TouchHandler.Instance.SelectNode = null;
        }
    }
}
