using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLight : Interactable
{
    // Start is called before the first frame update

    public bool OnState = false;
    public Material emissionMaterial;
    public Material offMaterial;
    public GameObject lightObject;
    public Light light;
    void Start()
    {
        this.TurnOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        this.OnState = !this.OnState;

        if (OnState)
        {
            TurnOn();
        }
        else
        {
            TurnOff();
        }
    }

    public void TurnOff()
    {
        //Switch material to non-emissive
        lightObject.GetComponent<MeshRenderer>().material = offMaterial;
        this.interactionString = "Turn On";
        if (light != null)
        {
            light.intensity = 0.0f;
        }
    }

    public void TurnOn()
    {
        //Siwtch material to emmisive
        lightObject.GetComponent<MeshRenderer>().material = emissionMaterial;
        this.interactionString = "Turn Off";

        if (light != null)
        {
            light.intensity = 1.0f;
        }
    }

    public override void Interact()
    {
        this.Toggle();
    }
}
