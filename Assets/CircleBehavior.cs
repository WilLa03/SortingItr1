using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CircleBehavior : MonoBehaviour
{
    private Vector3 position;
    private Vector2 direction;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    void Start()
    {
        while (direction.x == 0 && direction.y == 0)
        {
            direction.x = Random.Range(-10, 11);
            direction.y = Random.Range(-10, 11);
            direction=direction.normalized; 
        }

        
        
    }
    void FixedUpdate()
    {
        position = gameObject.transform.position;
        if (position.y > 4.5f || position.y < -4.5f)
        {
            direction.y *= -1;
            position = gameObject.transform.position;
        }
        if (position.x > 8.4f || position.x < -8.4f)
        {
            direction.x *= -1;
            position = gameObject.transform.position;
        }
        Vector3 newpos = new Vector3(position.x + direction.x*Time.deltaTime, position.y + direction.y*Time.deltaTime, position.z);
        gameObject.transform.position = newpos;
    }

    public void ChangeColor()
    {
        if (_spriteRenderer.color==Color.white)
        {
            _spriteRenderer.color = Color.gray;
        }
        else if (_spriteRenderer.color==Color.gray)
        {
            _spriteRenderer.color = Color.white;
        }
    }
}
