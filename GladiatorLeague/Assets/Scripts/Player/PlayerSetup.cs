using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField] private Behaviour[] componentsToDisable;

    private SceneCamera sceneCamera;
	
	private void Start()
    {
        if (Camera.main != null)
            sceneCamera = Camera.main.GetComponent<SceneCamera>();

        // If not local, disable components, else disable sceneCamera
        if (!isLocalPlayer)
        {
            DisableComponents();
        }
        else
        {
            if (sceneCamera != null)
                sceneCamera.DisableComponents();
        }
    }

    private void OnDisable()
    {
        if (sceneCamera != null)
            sceneCamera.EnableComponents();
    }

    private void DisableComponents()
    {
        foreach (Behaviour component in componentsToDisable)
        {
            component.enabled = false;
        }
    }
}
