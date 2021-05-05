using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface MonsterEvent
{
}

public struct LightOnEvent: MonsterEvent
{
    public Transform light;
    public float param;
    public string id;
}
public class MonsterEventQueue : MonoBehaviour
{
    // All events related to the monsters should be sent to this "queue"
    //public Queue<MonsterEvent> q;

    public List<Monster> allMonsters;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitEvent(MonsterEvent e)
    {
        if(e.GetType() == typeof(LightOnEvent))
        {
            foreach (Monster m in allMonsters)
            {
                m.OnLightOn(e);
            }
        }
    }
}
