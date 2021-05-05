using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFog(int level)
    {
        float val = 0.0f;
        if (level == 1)
        {
            val = 0.025f;
        }
        else if (level == 2)
        {
            val = 0.05f;
        }
        else if (level == 3)
        {
            val = 0.1f;
        }
        RenderSettings.fogDensity = val;
    }
}
