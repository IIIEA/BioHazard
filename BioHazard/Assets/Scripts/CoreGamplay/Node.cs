using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private int _countUnits;
    [SerializeField] private int _maxCountUnits;
    [SerializeField] private TMP_Text _countText;



    public int Count
    {
        get => _countUnits;
        set
        {
            _countUnits = value;
            _countText.text = Count.ToString();
        }
    }
}
