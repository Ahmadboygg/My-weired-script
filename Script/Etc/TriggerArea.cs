using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    [SerializeField] private GameObject objectTrigger;
    [SerializeField] private LayerMask playerLayer;
    void Start()
    {
        objectTrigger.SetActive(false);
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,Vector2.left,1,playerLayer);

        if(hitInfo.collider != null)
        {
            if(hitInfo.collider.gameObject.CompareTag("Player"))
            objectTrigger.SetActive(true);
        }
    }
}
