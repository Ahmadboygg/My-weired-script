using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraForwardMove : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * 2 * Time.deltaTime);
    }
}
