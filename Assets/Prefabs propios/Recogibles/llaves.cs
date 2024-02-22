using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class llaves : MonoBehaviour
{
    [SerializeField]
    private string colliderScript;

    [SerializeField]
    private UnityEvent collisionEnter;
    [SerializeField] 
    private UnityEvent collisionExit;
   
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.GetComponent(colliderScript))
        {
            collisionEnter?.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.GetComponent(colliderScript))
        {
            collisionExit?.Invoke();
        }
    }

}
