using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForwardDirection : MonoBehaviour
{
    [SerializeField] private LayerMask characterLayer;

    void Start()
    {
        Invoke("DestroyBullet", 1f); //bullet destroy as timer set
    }

    void Update()
    {
        transform.Translate(Vector2.right * 2 * Time.deltaTime);
        //check if bullet collider hit other collider with character layer
        Collider2D collider2D = Physics2D.OverlapBox(transform.position,new Vector2(0.01f,0.01f),0,characterLayer);
        if(collider2D!= null)
        {
            if(collider2D.gameObject.CompareTag("Enemy"))
            {
                collider2D.gameObject.GetComponent<EnemyStat>().TakeDamage(1);
                DestroyBullet();
            }
            else if(collider2D.gameObject.CompareTag("Player"))
            {
                collider2D.gameObject.GetComponent<CharacterStat>().TakeDamage(1);
                DestroyBullet();
            }
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
