using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MyCharacterController
{
    private NavMeshAgent _Agent;
    public float DetectRadius;
    public CharacterStats Target;

    private CharacterCombat _CharacterCombat;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        _Agent = GetComponent<NavMeshAgent>();
        _CharacterCombat= GetComponent<CharacterCombat>();

        Target = PlayerManager.Instance.PlayerStats;

        _Agent.speed = MoveSpeed;
        _Agent.angularSpeed = RotateRate;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if(Target == null)
        {
            return;
        }

        if(Vector3.Distance(transform.position, Target.transform.position) <= DetectRadius)
        {
            _Agent.SetDestination(Target.transform.position);

            if(_Movement == Vector3.zero)
            {
                _CharacterCombat.Attack();
            }
        }

        _Movement = _Agent.velocity;
    }
}
