using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInteraction : MonoBehaviour
{
    public Camera playerCam;

    //UI Fields for pickup and drop - SET IN EDITOR
    public Text interactField;

    // Ignore player on checking for interactions
    public LayerMask PlayerLayerMask;

    private void Awake()
    {
        if (interactField)
        {
            interactField.enabled = false;
        }
        else
        {
            Debug.LogError("Player carry interact field not set!");
        }
    }

    void Update()
    {
        RaycastHit hit;

        int layerMask = 1 << 10;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        //TODO: Look at raycast forward from camera  
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, PlayerConstants.InteractionDist, layerMask))
        {
            //Debug.Log("HIT: " + hit.collider.gameObject);
            //Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * hit.distance, Color.red);
            if (hit.collider.CompareTag("Interactable"))
            {

                //TODO: Check for generic interactable -> get type -> handle action

                Interactable focus = hit.collider.gameObject.GetComponent<Interactable>();
                if(focus == null)
                {
                    //Try in parent
                    focus = hit.collider.gameObject.GetComponentInParent<Interactable>();
                }
                if (focus)
                {  
                    //Handle generic interaction
                    ShowInteraction(focus.GetInteractionString());

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        focus.Interact();
                    }
                    
                }
                else
                {
                    Debug.Log("no interactable component found");
                    HideInteraction();
                }
            }

        }
        else
        {
            HideInteraction();
        }
    }




    void ShowInteraction(string message)
    {
        interactField.text = message;
        interactField.enabled = true;
    }

    void HideInteraction()
    {
        interactField.enabled = false;
    }

}