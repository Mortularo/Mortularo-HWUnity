using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public bool open = false;
    public float openAngle = 80f;
    public float closeAngle = 0f;
    public AudioClip clip;
    
    
    public void DoorState()
    {
        open = !open;
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
        
    void Update()
    {
        if (open)
        {
            Quaternion targetRotation = Quaternion.Euler(0, openAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, closeAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, Time.deltaTime);
        }
    }
    
}
