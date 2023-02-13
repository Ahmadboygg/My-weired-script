using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    [SerializeField]private GameObject trapObject;
    [SerializeField]private Transform  trapSpawnPoint;
    [SerializeField]private LayerMask characterLayer;

    void Update()
    {
        Collider2D hitInfo = Physics2D.OverlapCircle(transform.position,0.8f,characterLayer);
        if(hitInfo != null)
        {
            if(hitInfo.gameObject.CompareTag("Player"))
            InstantiateTrap();
        }
    }

    void InstantiateTrap()
    {
        if(trapObject != null)
        {
            trapObject.gameObject.SetActive(true);
        }
        else
        {
            return;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position,0.8f);
    }
}
