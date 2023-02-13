using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class FollowingCamera : MonoBehaviour
{
    private GameObject followingObject;
    private CinemachineVirtualCameraBase cinemachineVirtualCameraBase;

    void Start()
    {
        cinemachineVirtualCameraBase = GetComponent<CinemachineVirtualCameraBase>();
    }

    void Update()
    {
        followingObject = GameObject.FindGameObjectWithTag("Player");
        if(followingObject != null)
        {
            cinemachineVirtualCameraBase.Follow = followingObject.transform;
            transform.position = new Vector3(followingObject.transform.position.x,transform.position.y,transform.position.z);
        }
        else
        {
            return;
        }
        
    }
}
