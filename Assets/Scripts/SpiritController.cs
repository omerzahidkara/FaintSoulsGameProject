
using UnityEngine;

public class SpiritController : MonoBehaviour, Interactable
{
    private int spiritHealthValue;
    [SerializeField] public AudioClip collectedSound;
    public void Start()
    {
        spiritHealthValue = 2;
    }

    public void Interact()
    {
        spiritHealthValue = UnityEngine.Random.Range(4, 9); // ruh�uklar 4 - 8 aras� can sa�larlar
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (PlayerController.Instance.spiritNum < PlayerController.Instance.maxHealth)
        {
            PlayerController.Instance.spiritNum += spiritHealthValue;
            PlayerController.Instance.spiritNumOnTheScene--;
            PlayerController.Instance.isGatheredAnySouls = true;
            //blip!
            SoundFXManager.instance.PlaySoundFXClip(collectedSound, transform, 1f);
            // Ruh �ld���nde, pozisyonu spiritSpawnedPositions listesine ekleyebiliriz
            PlayerController.Instance.RemoveSpiritPosition(transform.position);
        }
    }
}
