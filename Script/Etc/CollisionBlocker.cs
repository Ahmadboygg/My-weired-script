using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBlocker : MonoBehaviour
{
    [SerializeField]private BoxCollider2D colliderObject;
    [SerializeField]private BoxCollider2D colliderBlocker;
    void Start()
    {
        Physics2D.IgnoreCollision(colliderObject,colliderBlocker,true);
    }
   
}
