using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class WandControl : XRGrabInteractable
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform projectileSpawnpoint;
    private bool isFiring;
    
    protected override void OnActivated(ActivateEventArgs args)
    {
        base.OnActivated(args);
        if (projectilePrefab != null)
        {
            Instantiate(projectilePrefab, projectileSpawnpoint.position, projectileSpawnpoint.rotation);
        }
    }

    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        base.OnDeactivated(args);
    }
}
