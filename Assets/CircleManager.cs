using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour
{
    public List<CircleBehavior> circles;
    [SerializeField] private Transform target;
    void Start()
    {
        circles.Clear();
    }
    
    void Update()
    {
        foreach (var circle in circles)
        {
            circle.distance = Vector3.Distance(target.position, circle.transform.position);
        }
    }
}
