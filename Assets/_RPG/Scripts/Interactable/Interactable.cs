using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class Interactable : MonoBehaviour
{
    public float Radius;

    private void Awake()
    {
        GetComponent<SphereCollider>().radius = Radius;
        GetComponent<SphereCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.PLAYER))
        {
            Interact(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Constants.PLAYER))
        {
            InteractExit(other);
        }
    }

    public virtual void Interact(Collider other)
    {
        Debug.Log($"Interact {other.name}");
    }

    public virtual void InteractExit(Collider other)
    {
        Debug.Log($"Interact Exit {other.name}");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
