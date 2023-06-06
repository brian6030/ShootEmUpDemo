using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace root {
    public class PlayerController : MonoBehaviour
    {
        [Header("Player")]
        [Range(0f, 20f)]
        [SerializeField] float speed = 5f;
        [Range(0f, 1f)]
        [SerializeField] float smoothness = 0.1f;
        [Range(0f, 90f)]
        [SerializeField] float leanAngle = 15f;
        [Range(0f, 20f)]
        [SerializeField] float leanSpeed = 5f;

        [SerializeField] GameObject model;

        [Header("Camera Bounds")]
        [SerializeField] Transform CameraFollow;

        [Range(-10f, 0f)]
        [SerializeField] float minX = -8f;
        [Range(0f, 10f)]
        [SerializeField] float maxX = 8f;
        [Range(-5f, 0f)]
        [SerializeField] float minY = -4f;
        [Range(0f, 5f)]
        [SerializeField] float maxY = 4f;

        InputReader input;

        Vector3 currentVelocity;
        Vector3 targetPosition;

        private void Start()
        {
            input = GetComponent<InputReader>();
        }

        private void Update()
        {
            // Update target position
            targetPosition += new Vector3(input.Move.x, input.Move.y, 0f) * (speed * Time.deltaTime);

            // Set boundary
            var minPlayerX = CameraFollow.position.x + minX;
            var minPlayerY = CameraFollow.position.y + minY;
            var maxPlayerX = CameraFollow.position.x + maxX;
            var maxPlayerY = CameraFollow.position.y + maxY;

            // Clamp the player's position to the camera view
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPlayerX, maxPlayerX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPlayerY, maxPlayerY);

            // Lerp the player's position to the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothness);

            // Calculate the rotation effect
            var targetRotationAngle = -input.Move.x * leanAngle;

            // Rotation
            var currentYRotation = transform.localEulerAngles.y;
            var newYRotation = Mathf.LerpAngle(currentYRotation, targetRotationAngle, leanSpeed * Time.deltaTime);

            // Apply rotation
            transform.localEulerAngles = new Vector3(0f, newYRotation, 0f);
        }
    }
}

