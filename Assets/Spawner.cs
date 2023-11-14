using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int AmountOfCircles;
    [SerializeField] private GameObject circle;
    [SerializeField] private CircleManager manager;
    
    void Start()
    {
        for (int i = 0; i < AmountOfCircles; i++)
        {
            manager.circles.Add(Instantiate(circle, transform));
        }
    }
}
