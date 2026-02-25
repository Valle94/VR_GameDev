using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


public class SimpleHingeInteractable : XRSimpleInteractable
{
    private Transform grabHand;
    [SerializeField] bool isLocked;
    private const string Default_Layer = "Default";
    private const string Grab_Layer = "Grab";
    void Start()
    {
        
    }

    public void LockHinge()
    {
        isLocked = true;
    }


    public void UnlockHinge()
    {
        isLocked = false;
    }

    protected virtual void Update()
    {
        if (grabHand != null)
        {
            transform.LookAt(grabHand, transform.forward);
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!isLocked)
        {
            base.OnSelectEntered(args);
            if (args.interactorObject is XRBaseInteractor interactor)
            {
                grabHand = interactor.transform;
            }
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        grabHand = null;
        ChangeLayerMask(Grab_Layer);
    }

    public void ReleaseHinge()
    {
        ChangeLayerMask(Default_Layer);
    }

    private void ChangeLayerMask(string mask)
    {
        interactionLayers = InteractionLayerMask.GetMask(mask);
    }
}