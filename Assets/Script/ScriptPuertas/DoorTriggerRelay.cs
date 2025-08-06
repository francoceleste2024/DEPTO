using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerRelay : MonoBehaviour
{
    private DoorOpener door;

    private void Start()
    {
        door = GetComponentInParent<DoorOpener>();
    }

    private void OnTriggerEnter(Collider other)
    {
        door?.SendMessage("OnTriggerEnter", other);
    }

    private void OnTriggerExit(Collider other)
    {
        door?.SendMessage("OnTriggerExit", other);
    }
}
