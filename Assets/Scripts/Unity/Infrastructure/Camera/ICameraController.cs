using UnityEngine;

namespace Unity.Infrastructure.Camera
{
    public interface ICameraController
    {
        UnityEngine.Camera Camera { get; }
        Vector2 ScaleFactor { get; }
        Vector3 ScreenToViewportPoint(Vector3 screenCoordinates);
        Vector3 ScreenToWorldPoint(Vector3 screenCoordinates);
        Ray GetCameraRay(Vector3 screenCoordinates);
    }
}