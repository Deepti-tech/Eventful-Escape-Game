using UnityEngine;

public class KeyView : MonoBehaviour, IInteractable
{
    
    public void Interact()
    {
        GameService.Instance.GetInstructionView().HideInstruction();
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.KeyPickUp);
        GameService.Instance.GetPlayerController().KeysEquipped++;
        //EventService.Instance.OnKeyPickedUp.InvokeEvent()
        gameObject.SetActive(false);
    }
}
