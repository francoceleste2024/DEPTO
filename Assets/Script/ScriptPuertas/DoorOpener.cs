using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public float openAngle = 90f;
    public float openSpeed = 2f;
    private bool isOpen = false;
    private bool playerIsNear = false;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(0, openAngle, 0) * closedRotation;
    }

    void Update()
    {
        if (playerIsNear && Input.GetKeyDown(KeyCode.C))
        {
            isOpen = !isOpen;
        }

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            isOpen ? openRotation : closedRotation,
            Time.deltaTime * openSpeed
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
        }
    }
}
