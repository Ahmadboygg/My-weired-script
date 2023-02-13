using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask characterLayer;

    void Start()
    {
        Invoke("DestroyBullet", 1.5f); //bullet destroy as timer set
    }

    void Update()
    {
        //check if bullet collider hit other collider with character layer
        Collider2D collider2D = Physics2D.OverlapBox(transform.position,new Vector2(0.01f,0.01f),0,characterLayer);
        if(collider2D!= null)
        {
            collider2D.gameObject.GetComponent<CharacterStat>().TakeDamage(1);
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position,new Vector2(0.1f,0.1f));
    }

    
}
