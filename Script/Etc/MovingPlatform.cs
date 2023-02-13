using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float platformMoveSpeed;
    [SerializeField] private Transform[] platformDirectionPoint;
    private int startPlatformMoveDirection = 1;
    private int i;
    void Start()
    {
        //pengaturan untuk arah pertama yang akan di ambil pada saat platform bergerak
        transform.position = platformDirectionPoint[startPlatformMoveDirection].position;
    }

    void Update()
    {
        //cek jika jarak antara platform dengan platformDirectionPoint kurang dari 0.2f
        if(Vector2.Distance(transform.position, platformDirectionPoint[i].position) < 0.2f)
        {
            i++; //maka nilai i bertambah

            //jika nilai i sama dengan jumlah seluruh array platform direction
            if(i == platformDirectionPoint.Length)
            {
                i = 0; //maka nilai i menjadi 0

            }

        }
        //platform bergerak ke posisi platformDirectionPoint sesuai dengan nilai i
        transform.position = Vector2.MoveTowards(transform.position,platformDirectionPoint[i].position, platformMoveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        other.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D other) {
        other.transform.SetParent(null);
    }
}
