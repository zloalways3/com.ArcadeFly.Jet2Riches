using UnityEngine;

public class AdversaryAIConductor : MonoBehaviour
{
    private AudioSource audioComponent;

    private void InitializeAudioSource()
    {
        audioComponent = GetComponent<AudioSource>();
    }

    private void HandleCollisionWithPlayer(Collider2D collider)
    {
        if (IsPlayer(collider))
        {
            PlayEnemySound();
            DisableEnemyVisuals();
            NotifyGameManager();
            DestroyEnemyAfterSound();
        }
    }

    private bool IsPlayer(Collider2D collider)
    {
        return collider.CompareTag(GameConstants.PlayerIdentifier);
    }

    private void PlayEnemySound()
    {
        audioComponent.Play();
    }

    private void DisableEnemyVisuals()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    private void NotifyGameManager()
    {
        GameSessionSupervisor.Instance.LoseLife();
    }

    private void DestroyEnemyAfterSound()
    {
        Destroy(gameObject, audioComponent.clip.length);
    }

    private void Awake()
    {
        InitializeAudioSource();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollisionWithPlayer(collision);
    }
}