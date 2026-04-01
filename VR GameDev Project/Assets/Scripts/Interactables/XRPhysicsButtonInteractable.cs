using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.Events;

public class XRPhysicsButtonInteractable : XRSimpleInteractable
{
    public UnityEvent OnBaseEnter;
    public UnityEvent OnBaseExit;
    [SerializeField] Collider baseCollider;
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
    }

    void OnTriggerEnter(Collider other)
    {
        if (isHovered && baseCollider != null)
        {
            if (other == baseCollider)
            {
                OnBaseEnter?.Invoke();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (baseCollider != null)
        {
            if (other == baseCollider)
            {
                OnBaseExit?.Invoke();
            }
        }
    }
}
