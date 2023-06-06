using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace root
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputReader : MonoBehaviour
    {
        PlayerInput playerInput;
        InputAction moveAction;

        public Vector2 Move => moveAction.ReadValue<Vector2>();

        private void Start()
        {
            playerInput = GetComponent<PlayerInput>();
            moveAction = playerInput.actions["Move"];
    }
    }
}
