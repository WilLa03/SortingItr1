using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CircleBehavior : MonoBehaviour
{
    private Vector3 position;

    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction.x = Random.Range(-10, 11);
        direction.y = Random.Range(-10, 11);
        direction=direction.normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        position = gameObject.transform.position;
        Vector3 newpos = new Vector3(position.x + direction.x*Time.deltaTime, position.y + direction.y*Time.deltaTime, position.z);
        gameObject.transform.position = newpos;
    }
}
