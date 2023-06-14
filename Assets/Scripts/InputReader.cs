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
        InputAction fireAction;

        public Vector2 Move => moveAction.ReadValue<Vector2>();

        /*public bool Fire
        {
            get { return fireAction.ReadValue<float>() > 0f; }
        }*/
        public bool Fire => fireAction.ReadValue<float>() > 0f;

        private void Start()
        {
            playerInput = GetComponent<PlayerInput>();
            moveAction = playerInput.actions["Move"];
            fireAction = playerInput.actions["Fire"];
    }
    }
}
