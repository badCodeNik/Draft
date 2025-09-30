using UnityEngine;

namespace _Project.Scripts.UI
{
    public class CameraLooker : MonoBehaviour
    {
        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if (mainCamera == null)
            {
                Debug.LogWarning("Main camera is not found!");
                return;
            }

            LookAtCamera();
        }

        private void LookAtCamera()
        {
            Vector3 directionToCamera = mainCamera.transform.position - transform.position;

            directionToCamera.y = 0;

            if (directionToCamera != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(-directionToCamera);
            }
        }
    }}