using UnityEngine;

/// <summary>
/// This class inherits from TargetObject and represents a LapObject.
/// </summary>
public class LapObject : TargetObject
{
    [Header("LapObject")]
    [Tooltip("Is this the first/last lap object?")]
    public bool finishLap;

    [HideInInspector]
    public bool lapOverNextPass;

    void Start() {
        Register();
    }
    
    void OnEnable()
    {
        lapOverNextPass = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!((layerMask.value & 1 << other.gameObject.layer) > 0 && other.CompareTag("Player")))
            return;

        /*if (!((layerMask.value & 1 << other.gameObject.layer) > 0 && other.CompareTag("Player1")))
            return;
        if (!((layerMask.value & 1 << other.gameObject.layer) > 0 && other.CompareTag("Player2")))
            return;
        if (!((layerMask.value & 1 << other.gameObject.layer) > 0 && other.CompareTag("Player3")))
            return;
        if (!((layerMask.value & 1 << other.gameObject.layer) > 0 && other.CompareTag("Player4")))
            return;*/


        Objective.OnUnregisterPickup?.Invoke(this);
    }
}
