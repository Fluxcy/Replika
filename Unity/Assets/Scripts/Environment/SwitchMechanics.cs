using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMechanics : MonoBehaviour
{
    [SerializeField] bool isToggled;

    [SerializeField] float flipSpeed = 10f;

    [SerializeField] private Vector3 offRotation;
    [SerializeField] private Vector3 onRotation;

    public LightMechanics linkedLight;

    private void Awake()
    {
        if (linkedLight != null) linkedLight.emitting = isToggled;
    }

    public void toggle()
    {
        isToggled = !isToggled;
        if (linkedLight != null) linkedLight.toggleEmission();
    }

    private void Update()
    {
        if (isToggled)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(onRotation), Time.deltaTime * flipSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(offRotation), Time.deltaTime * flipSpeed);
        }
    }
}

