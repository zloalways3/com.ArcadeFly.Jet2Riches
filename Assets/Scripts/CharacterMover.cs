using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float smoothingFactor = 0.1f;
    private Vector3 targetPosition;
    private bool isDragging = false;
    private Camera mainCamera;

    private void InitializeCamera()
    {
        mainCamera = Camera.main;
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            UpdateTargetPosition();
            MoveCharacter();
        }
    }

    private void UpdateTargetPosition()
    {
        targetPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 0;
        ClampPosition(ref targetPosition);
    }

    private void ClampPosition(ref Vector3 position)
    {
        float cameraWidth = mainCamera.orthographicSize * mainCamera.aspect;
        position.x = Mathf.Clamp(position.x, -cameraWidth, cameraWidth);
        position.y = Mathf.Clamp(position.y, -mainCamera.orthographicSize, mainCamera.orthographicSize);
    }

    private void MoveCharacter()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothingFactor);
    }

    private void Start()
    {
        InitializeCamera();
    }

    private void Update()
    {
        HandleInput();
    }
}