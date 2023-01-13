using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MyCharacterController
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        HandlePlayerInput();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        HandlePlayerMovement();
        HandlePlayerRotation();
    }



    #region CustomFunctions

    private void HandlePlayerInput()
    {
        _Movement = Vector3.zero;

        _Movement.x = Input.GetAxis(Constants.HORIZONTAL_AXIS);
        _Movement.z = Input.GetAxis(Constants.VERTICAL_AXIS);
    }

    private void HandlePlayerMovement()
    {
        if (_Movement == Vector3.zero)
        {
            return;
        }

        _Rb.MovePosition(transform.position + _Movement * Time.fixedDeltaTime * MoveSpeed);
    }

    private void HandlePlayerRotation()
    {
        if (_Movement == Vector3.zero)
        {
            return;
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation,
                    Quaternion.LookRotation(_Movement, Vector3.up),
                    RotateRate * Time.fixedDeltaTime);
    }

    #endregion
}
