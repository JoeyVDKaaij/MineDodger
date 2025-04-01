using System;
using UnityEngine;
using FMODUnity;

public class FMODAnimationPlayer : MonoBehaviour
{
    [SerializeField, Tooltip("FMOD event that plays during animation.")]
    private EventReference eventRef;

    public bool togglePlay = false;

    private void Update()
    {
        if (togglePlay)
        {
            PlayEvent();
            togglePlay = false;
        }
    }

    public void PlayEvent()
    {
        RuntimeManager.PlayOneShot(eventRef, transform.position);
    }
}
