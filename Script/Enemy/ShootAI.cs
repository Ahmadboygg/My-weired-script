using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAI : MonoBehaviour
{
    [SerializeField]private Transform bulletPoint;
    [SerializeField]private Transform groundPoint;
    [SerializeField]private LayerMask characterLayer;
    [SerializeField]private LayerMask groundLayer;
    [SerializeField]private GameObject bulletObject;
    [SerializeField]private float bulletDirectionRange;
    [SerializeField]private float shootSpeed;
    private float currentStandbyTime;
    private bool isPlayerDetect;
    private bool isTurnRight;
    private float currentShootSpeed;
    private Vector2 bulletDirection;
    private Vector2 bulletDirectionRay;

    void Start()
    {
        isTurnRight = false;
    }

    void Update()
    {
        if(isPlayerDetect)
        {
            transform.Translate(Vector2.left * 0f * Time.deltaTime);
            currentStandbyTime = 1.5f;
        }
        else
        {
            if(groundPoint != null)
            {
                if(currentStandbyTime < 0)
                {
                    transform.Translate(Vector2.left * 0.2f * Time.deltaTime);

                }
                else
                {
                    currentStandbyTime -= Time.deltaTime;
                }

                RaycastHit2D groundDetector = Physics2D.Raycast(groundPoint.position,Vector2.down,0.3f,groundLayer);
                if(groundDetector.collider == null)
                {
                    if(isTurnRight)
                    {
                        transform.rotation = Quaternion.Euler(0,180,0);
                        bulletDirection = new Vector2(1 ,0);
                        isTurnRight = false;
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0,0,0);
                        bulletDirection = new Vector2(-1 ,0);
                        isTurnRight = true;
                    }
                }
            }
            else
            {
                return;
            }
        }

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
