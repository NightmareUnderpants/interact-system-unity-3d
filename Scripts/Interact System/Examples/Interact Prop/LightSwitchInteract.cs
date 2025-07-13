using System;
using System.Collections;
using UnityEngine;

public class LightSwitchInteract : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject lightMesh;

    [Header("Unavailiable Interaction")]
    [SerializeField]
    private string UnInteractiveText;
    [SerializeField]
    private bool isInteract = false;

    [Header("Speed turn off light")]
    [SerializeField]
    private float offSpeed = 0.005f;


    [Header("Optional: Add height to InteractIcon transform")]
    [SerializeField]
    private float addHeight;

    private float intensity;
    private Light[] lightSwitch;

    [SerializeField]
    private int idSwitchLight;
    public static event Action<int> LightOn;
    public static event Action<int> LightOff;

    private void Start()
    {
        lightSwitch = GetComponentsInChildren<Light>();
    }

    void IInteractable.Interact(Transform interactorTransform)
    {
        foreach (Light light in lightSwitch)
        {
            if (light == null) return;

            if (light.enabled == false)
            {
                intensity = light.intensity;
                light_on(light, intensity);
            }
            else StartCoroutine(light_off(light, intensity));
        }
    }

    private void light_on(Light light, float intensity)
    {
        LightOn?.Invoke(idSwitchLight);
        light.intensity = intensity;
        light.enabled = true;

        if (lightMesh != null) lightMesh.SetActive(true);
    }

    private IEnumerator light_off(Light light, float intensity)
    {
        LightOff?.Invoke(idSwitchLight);
        while (!Mathf.Approximately(light.intensity, 0f))
        {
            light.intensity -= offSpeed;
            yield return new WaitForSeconds(0.01f);
        }
        light.enabled = false;
        light.intensity = intensity;

        if (lightMesh != null) lightMesh.SetActive(false);
    }

    public bool LightIsOn()
    {
        if (intensity > 0f) return true;
        else return false;
    }

    public Vector3 GetInteractVector3()
    {
        return new Vector3(transform.position.x, transform.position.y + addHeight, transform.position.z);
    }

    public bool IsInteractable()
    {
        return isInteract;
    }
}
