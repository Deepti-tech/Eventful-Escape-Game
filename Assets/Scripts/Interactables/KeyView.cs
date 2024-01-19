using UnityEngine;

public class KeyView : MonoBehaviour, IInteractable
{
    
    public void Interact()
    {
        int currentkeys = GameService.Instance.GetPlayerController().KeysEquipped;
        GameService.Instance.GetInstructionView().HideInstruction();
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.KeyPickUp);
        currentkeys++;
        EventService.Instance.OnKeyPickedUp.InvokeEvent(currentkeys);
        gameObject.SetActive(false);
    }
}
