using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MyCharacterController : MonoBehaviour
{
    #region Variables

    protected Rigidbody _Rb;

    protected Vector3 _Movement;
    public float MoveSpeed;

    public float RotateRate;

    public Vector3 Movement
    {
        get { return _Movement; }
    }

    #endregion

    #region UnityFunctions
    // Start is called before the first frame update
    protected virtual void Start()
    {
        _Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected virtual void FixedUpdate()
    {
        
    }


    #endregion

    
}
