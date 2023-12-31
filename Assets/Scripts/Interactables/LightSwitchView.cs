using System.Collections.Generic;
using UnityEngine;

public partial class LightSwitchView : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Light> lightsources = new List<Light>();
    private SwitchState currentState;

    public delegate void LightSwitchDelegate();
    public LightSwitchDelegate LightSwitch;
    private void OnEnable()
    {
        LightSwitch = OnLightsToggled;
        LightSwitch += OnLightSwitchSoundEffects;
    }

    private void OnDisable()
    {
        EventService.Instance.LightSwitchToggleEvent.RemoveListener(OnLightsToggled);
        EventService.Instance.LightsOffByGhostEvent.RemoveListener(OnLightsOffByGhostEvent);
    }

    private void Start()
    {
        currentState = SwitchState.Off;
    }
    public void Interact()
    {
        LightSwitch.Invoke();
    }
    private void ToggleLights()
    {
        bool lights = false;

        switch (currentState)
        {
            case SwitchState.On:
                currentState = SwitchState.Off;
                lights = false;
                break;
            case SwitchState.Off:
                currentState = SwitchState.On;
                lights = true;
                break;
            case SwitchState.Unresponsive:
                break;
        }
        foreach (Light lightSource in lightsources)
        {
            lightSource.enabled = lights;
        }
    }

    private void SetLights(bool lights)
    {
        if (lights)
            currentState = SwitchState.On;
        else
            currentState = SwitchState.Off;

        foreach (Light lightSource in lightsources)
        {
            lightSource.enabled = lights;
        }
    }
    private void OnLightsOffByGhostEvent()
    {
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.SwitchSound);
        SetLights(false);
    }
    private void OnLightsToggled()
    {
        ToggleLights();
        GameService.Instance.GetInstructionView().HideInstruction();
    }
    private void OnLightSwitchSoundEffects()
    {
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.SwitchSound);
    }
}
