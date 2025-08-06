using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorLuz : MonoBehaviour
{
    public Light luz;  // Luz que controla este interruptor
    private bool jugadorCerca = false;

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.L))
        {
            luz.enabled = !luz.enabled;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }
}
