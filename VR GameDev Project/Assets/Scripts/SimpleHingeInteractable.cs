using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


public class SimpleHingeInteractable : XRSimpleInteractable
{
    private Transform grabHand;
    
    protected virtual void Update()
    {
        if (grabHand != null)
        {
            transform.LookAt(grabHand, transform.forward);
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        
        // Get the interactor (controller/hand) transform instead
        if (args.interactorObject is XRBaseInteractor interactor)
        {
            grabHand = interactor.transform;
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        grabHand = null;
    }
}