using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterOrbitCamera : MonoBehaviour
{
    [Header("Camera")]
    public Transform cameraTransform;

    [Header("Rotation")]
    public float rotationSpeed = 0.15f;
    public float pitch = 10f;
    public float yaw = 180f;

    [Header("Zoom")]
    public float distance = 3f;
    public float minDistance = 1.2f;
    public float maxDistance = 5f;
    public float zoomSpeed = 0.01f;

    void LateUpdate()
    {
        if (Mouse.current == null || cameraTransform == null)
            return;

        // Вращение правой кнопкой мыши
        if (Mouse.current.rightButton.isPressed)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();

            yaw += mouseDelta.x * rotationSpeed;
            pitch -= mouseDelta.y * rotationSpeed;

            pitch = Mathf.Clamp(pitch, -25f, 70f);
        }

        // Приближение колесом
        float scroll = Mouse.current.scroll.ReadValue().y;

        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // Поворачиваем весь CameraRig
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);

        // Камера отодвигается от центра вращения
        cameraTransform.localPosition =
            new Vector3(0f, 0f, -distance);

        cameraTransform.localRotation =
            Quaternion.identity;
    }
}