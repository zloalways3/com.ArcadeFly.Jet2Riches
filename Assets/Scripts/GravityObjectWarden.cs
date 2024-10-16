using UnityEngine;

public class GravityObjectWarden : MonoBehaviour
{
    [SerializeField] private float fallVelocity = 3f;
    [SerializeField] private float spawnBoundaryX = 2.3f;

    private void InitializePosition()
    {
        float randomX = Random.Range(-spawnBoundaryX, spawnBoundaryX);
        float spawnHeight = Camera.main.orthographicSize + 1;
        transform.position = new Vector3(randomX, spawnHeight, 0);
    }

    private void MoveObjectDown()
    {
        transform.Translate(Vector3.down * fallVelocity * Time.deltaTime);
    }

    private bool IsBelowScreen()
    {
        return transform.position.y < -Camera.main.orthographicSize - 1;
    }

    private void Update()
    {
        MoveObjectDown();
        
        if (IsBelowScreen())
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializePosition();
    }
}