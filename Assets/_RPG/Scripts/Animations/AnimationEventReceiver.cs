using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventReceiver : MonoBehaviour
{
    public System.Action OnHitStarted;
    public System.Action OnHitEnded;

    public void OnHitStart()
    {
        Debug.Log("Hit Started!");
        OnHitStarted?.Invoke();
    }
    
    public void OnHitEnd()
    {
        Debug.Log("Hit Ended!");
        OnHitEnded?.Invoke();
    }
}
