using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCamera : MonoBehaviour
{
    [SerializeField] private Behaviour[] componentsToDisable;

    public void DisableComponents()
    {
        foreach (Behaviour component in componentsToDisable)
        {
            component.enabled = false;
        }
    }

    public void EnableComponents()
    {
        foreach (Behaviour component in componentsToDisable)
        {
            component.enabled = true;
        }
    }
}
