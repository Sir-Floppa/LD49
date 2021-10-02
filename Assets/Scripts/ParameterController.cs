using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterController : MonoBehaviour
{
    public float targetParameter = 5f;

    public FMODUnity.StudioParameterTrigger trigger;

    public FMOD.Studio.EventInstance audioEvent;

    private void Start()
    {
        audioEvent = FMODUnity.RuntimeManager.CreateInstance("event:/Sanity");
    }

    private void OnEnable()
    {
        targetParameter -= 1f;
        audioEvent.getParameterByName("event:/Sanity", out targetParameter);
        gameObject.SetActive(false);
    }
}
