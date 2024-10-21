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
        objectRigibody.useGravity = false;
        objectRigibody.drag = 5;
    }
    
    public void Drop()
    {
        this.objectGrabPointTransform=null;
        objectRigibody.useGravity = true;
        objectRigibody.drag = 0.05f;
    }
    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position,objectGrabPointTransform.position,Time.deltaTime*lerpSpeed);
            objectRigibody.MovePosition(objectGrabPointTransform.position);
            Debug.Log("Grabable");
        }
    }
}
