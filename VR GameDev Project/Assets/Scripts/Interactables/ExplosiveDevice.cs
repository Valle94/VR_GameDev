using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.Events;

public class ExplosiveDevice : XRGrabInteractable
{
    public UnityEvent OnDetonated;
    private bool isActivated;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        if (args.interactorObject.transform.GetComponent<XRSocketInteractor>() != null)
        // if (args.interactorObject is XRSocketInteractor)
        {
            isActivated = true;
            Debug.Log("Explosive Device ARMED in socket.");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isActivated && other.gameObject.GetComponent<WandProjectile>() != null)
        {
            OnDetonated?.Invoke();
        }
    }
}
