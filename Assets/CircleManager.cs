using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour
{
    public List<CircleBehavior> circles;
    [SerializeField] private Transform target;
    void Awake()
    {
        circles = new List<CircleBehavior>();
        Random.InitState(0);
        circles.Clear();
    }
    
    void Update()
    {
        foreach (var circle in circles)
        {
            circle.distance = Vector3.Distance(target.position, circle.transform.position);
        }

        int halflenght=circles.Count /2;
        for (int i = 0; i < halflenght; i++)
        {
            circles[i].ChangeColorGrey();
        }
        for (int i = halflenght; i < circles.Count; i++)
        {
            circles[i].ChangeColorWhite();
        }
    }
}
