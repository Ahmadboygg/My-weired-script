using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] crystalColor;
    [SerializeField] private MovingPlatform movingPlatform;
    [SerializeField] private LayerMask playerLayer;

    void Start()
    {
        movingPlatform.enabled = false;
        crystalColor[0].SetActive(true);
        crystalColor[1].SetActive(false);
    }
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,Vector2.up,0.15f,playerLayer);

        if(hitInfo.collider != null)
        {
            crystalColor[0].SetActive(false);
            crystalColor[1].SetActive(true);
            movingPlatform.enabled = true;
        }
    }
}
