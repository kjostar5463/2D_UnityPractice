using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector3 offset;
    [SerializeField] float camSpeed;

    private Vector3 targetDirection;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        targetDirection = offset + target.transform.position;

        transform.position = Vector3.Lerp(transform.position, targetDirection, Time.deltaTime * camSpeed);
    }
}
