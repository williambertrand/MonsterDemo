using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class AreaEventAction : UnityEvent<int>
{
}

[RequireComponent(typeof(Collider))]
public class AreaEvent : MonoBehaviour
{
    public int level;
    public AreaEventAction action;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            action.Invoke(level);
        }
    }
}
