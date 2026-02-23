using UnityEngine;

namespace Unity.Infrastructure.Camera
{
    public class CameraController : MonoBehaviour, ICameraController
    {
        
        [SerializeField] private UnityEngine.Camera _camera;
        
        public UnityEngine.Camera Camera => _camera;

        public Vector2 ScaleFactor =>
            new Vector2(_camera.orthographicSize * _camera.aspect, _camera.orthographicSize) * 2;


        public Vector3 ScreenToViewportPoint(Vector3 screenCoordinates) =>
            Camera.ScreenToViewportPoint(screenCoordinates) * ScaleFactor;

        public Vector3 ScreenToWorldPoint(Vector3 screenCoordinates) => Camera.ScreenToWorldPoint(screenCoordinates);

        public Ray GetCameraRay(Vector3 screenCoordinates) => Camera.ScreenPointToRay(screenCoordinates);

    }
}