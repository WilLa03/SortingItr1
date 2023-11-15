using System.Diagnostics;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

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
                    //TODO gör så att den fortsätter genom hela listan på samma sätt
                    if (_manager.circles[i].distance >
                        _manager.circles[i + 1].distance)
                    {
                        (_manager.circles[i + 1].distance, _manager.circles[i].distance) = (_manager.circles[i].distance, _manager.circles[i + 1].distance);
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
