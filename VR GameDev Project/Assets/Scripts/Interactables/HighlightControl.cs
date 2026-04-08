using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class HighlightControl : MonoBehaviour
{
    [SerializeField] XRBaseInteractable interactableObject;
    [SerializeField] Material startMaterial;
    [SerializeField] Material emissionMaterial;
    [SerializeField] Renderer hightlightableObject;

    private void OnEnable()
    {
        if (interactableObject != null)
        {
            interactableObject.selectEntered.AddListener(HightlightObject);
            interactableObject.selectExited.AddListener(ResetObject);
        }
    }

    void OnDisable()
    {
        if (interactableObject != null)
        {
            interactableObject.selectEntered.RemoveListener(HightlightObject);
            interactableObject.selectExited.RemoveListener(ResetObject);
        }
    }

    private void ResetObject(SelectExitEventArgs arg0)
    {
        if (hightlightableObject != null && startMaterial != null)
        {
            hightlightableObject.material = startMaterial;
        }
    }

    private void HightlightObject(SelectEnterEventArgs arg0)
    {
        if (hightlightableObject != null && emissionMaterial != null)
        {
            hightlightableObject.material = emissionMaterial;
        }
    }
}
