using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayMovingObject : MonoBehaviour
{
    [SerializeField]private Transform destinationPoint;
    [SerializeField]private float moveSpeed;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,destinationPoint.position,moveSpeed*Time.deltaTime);
    }
}
