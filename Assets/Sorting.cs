using System.Diagnostics;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;

public class Sorting : MonoBehaviour
{
    [SerializeField] private CircleManager _manager;
    public SortingType sortingType;
    void Start()
    {
        
    }
    public enum SortingType
    {
        Insert,
        Merge,
        Bubble
    }
    
    // Update is called once per frame
    void Update()
    {
        switch (sortingType)
        {
            case SortingType.Bubble:
                for (int i = 0; i < _manager.circles.Count-1; i++)
                {
                    for (int j = 0; j < _manager.circles.Count-i-1; j++)
                    {
                        if (_manager.circles[j].distance >
                            _manager.circles[i].distance)
                        {
                            var data = _manager.circles[j].distance;
                            _manager.circles[j].distance = _manager.circles[j+1].distance;
                            _manager.circles[j+1].distance = data;
                            Debug.Log("hej");
                        }
                    }
                }
                break;
            case SortingType.Insert:
                break;
            case SortingType.Merge:
                break;
        }
    }
}
