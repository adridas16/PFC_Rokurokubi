using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabable : MonoBehaviour
{
    private Rigidbody objectRigibody;
    private Transform objectGrabPointTransform;
    private void Awake()
    {
       objectRigibody = GetComponent<Rigidbody>();
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            objectRigibody.MovePosition(objectGrabPointTransform.position);
            Debug.Log("si");
        }
    }
}
