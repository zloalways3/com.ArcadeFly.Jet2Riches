using UnityEngine;

public class CurrencyDispenserChief : MonoBehaviour
{
    [SerializeField] private AudioSource audioComponent;

    private void InitializeAudioSource()
    {
        audioComponent = GetComponent<AudioSource>();
    }

    private void HandleCollision(Collider2D collider)
    {
        if (IsPlayer(collider))
        {
            PlayCoinSound();
            DisableCoinVisuals();
            DestroyCoinAfterSound();
        }
    }

    private bool IsPlayer(Collider2D collider)
    {
        return collider.CompareTag(GameConstants.PlayerIdentifier);
    }

    private void PlayCoinSound()
    {
        audioComponent.Play();
    }

    private void DisableCoinVisuals()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    private void DestroyCoinAfterSound()
    {
        Destroy(gameObject, audioComponent.clip.length);
    }

    private void Awake()
    {
        InitializeAudioSource();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollision(collision);
    }
}