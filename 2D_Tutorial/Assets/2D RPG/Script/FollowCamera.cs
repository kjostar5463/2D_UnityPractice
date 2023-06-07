using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private GameObject target;
    [SerializeField] Vector2 minCameraScope;
    [SerializeField] Vector2 maxCameraScope;
    [SerializeField] float camSpeed;

    private Vector3 targetDirection;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Character");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetDirection = new Vector3
            (
                target.transform.position.x,
                target.transform.position.y,
                this.transform.position.z
            );

        targetDirection.x = Mathf.Clamp(targetDirection.x, minCameraScope.x, maxCameraScope.x);
        targetDirection.y = Mathf.Clamp(targetDirection.y, minCameraScope.y, maxCameraScope.y);

        transform.position = Vector3.Lerp(transform.position, targetDirection, Time.deltaTime * camSpeed);
    }
}
