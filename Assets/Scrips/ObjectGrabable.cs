using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabable : MonoBehaviour
{
    private Rigidbody objectRigibody;
    private Transform objectGrabPointTransform;
    [SerializeField] private float PickUpForce = 150f;

   

    private void Awake()
    {
        objectRigibody = GetComponent<Rigidbody>();
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigibody.useGravity = false;
        
        objectRigibody.constraints = RigidbodyConstraints.FreezeRotation;
        
        objectRigibody.mass = 1;
        objectRigibody.drag = 5;
    }

    public void Drop()
    {
        
        this.objectGrabPointTransform = null;
        objectRigibody.useGravity = true;
        
        objectRigibody.constraints = RigidbodyConstraints.None;

        objectRigibody.drag = 1;
    }

    private void FixedUpdate()
    {
        
    }
    public void MoveObject()
    {
        if (Vector3.Distance(objectRigibody.transform.position, objectGrabPointTransform.position) > 0.1f)
        {
            Vector3 moveDirection = (objectGrabPointTransform.position - transform.position).normalized;
            objectRigibody.AddForce(moveDirection * moveDirection.magnitude * PickUpForce, ForceMode.Force);
            
            

        }
        else
        {
           
            objectRigibody.velocity = Vector3.zero;
        }
    }
}
