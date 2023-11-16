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
                    int temp = i;
                    //TODO gör så att den fortsätter genom hela listan på samma sätt
                    if (_manager.circles[temp].distance >
                        _manager.circles[temp + 1].distance)
                    {
                        while (_manager.circles[temp].distance >
                               _manager.circles[temp + 1].distance)
                        {
                            (_manager.circles[temp + 1].distance, _manager.circles[temp].distance) = (_manager.circles[temp].distance, _manager.circles[temp + 1].distance);
                            if (temp < _manager.circles.Count - 2)
                            {
                                temp++;
                            }
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
