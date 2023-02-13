using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    private CharacterStat characterStat;

    void Update()
    {
        characterStat = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStat>();
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,Vector2.left,0.2f,playerLayer);
        if(hitInfo.collider != null)
        {
            if(hitInfo.collider.gameObject.CompareTag("Player"))
            {
                characterStat.Heal(8);
                Invoke("DestroyObject",0.2f);
            }
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
