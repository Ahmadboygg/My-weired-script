using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField]private Transform bulletPoint;
    [SerializeField]private LayerMask characterLayer;
    [SerializeField]private GameObject bulletObject;
    [SerializeField]private float bulletDirectionRange;
    [SerializeField]private float shootSpeed;
    private bool isPlayerDetect;
    private float currentShootSpeed;
    private Vector2 bulletDirection;
    void Start()
    {
        bulletDirection = new Vector2(-1 ,0);
    }

    void Update()
    {
        //check if player detected or not detected by shootDetector
        RaycastHit2D shootDetector = Physics2D.Raycast(bulletPoint.position,bulletDirection,bulletDirectionRange,characterLayer);
        if(shootDetector.collider != null)
        {
            isPlayerDetect = true;
            Debug.DrawRay(bulletPoint.position,bulletDirection * bulletDirectionRange,Color.red);
            if(currentShootSpeed <=0)
            {
                Instantiate(bulletObject,bulletPoint.position,bulletPoint.rotation);
                currentShootSpeed = shootSpeed;

            }
            else
            {
                currentShootSpeed -= Time.deltaTime;
            }
        }
        else
        {
            isPlayerDetect = false;
            Debug.DrawRay(bulletPoint.position,bulletDirection * bulletDirectionRange,Color.green);
            currentShootSpeed -= Time.deltaTime;

        }
    }
}
