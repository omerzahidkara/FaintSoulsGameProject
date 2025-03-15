
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    [SerializeField] private Dialog dialog; // NPC'nin diyalog verisi


    public void Interact()
    {
        // Diyalog ba�lat
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }

}

