using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int AmountOfCircles;
    [SerializeField] private GameObject circle;
    [SerializeField] private CircleManager manager;
    public int AdditionalBalls;
    private int loop;
    
    void Start()
    {
        for (int i = 0; i < AmountOfCircles; i++)
        {
            manager.circles.Add(Instantiate(circle, transform).GetComponent<CircleBehavior>());
        }
        manager.halfLenght=manager.circles.Count /2;
        loop++;
    }

    public void InstantiateCircles()
    {
        for (int i = 0; i < AmountOfCircles; i++)
        {
            manager.circles.Add(Instantiate(circle, transform).GetComponent<CircleBehavior>());
        }

        for (int i = 0; i < loop; i++)
        {
            for (int j = 0; j < AdditionalBalls; j++)
            {
                manager.circles.Add(Instantiate(circle, transform).GetComponent<CircleBehavior>());
            }
        }
        manager.halfLenght=manager.circles.Count /2;
        loop++;
    }
}
