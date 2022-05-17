using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
namespace Sean
{
    [CreateAssetMenu(fileName = "Player Input")]
    public class PlayerInput : ScriptableObject, InputActions.IGamePlayActions
    {
        //Move
        public event UnityAction<Vector2> onMove;
        public event UnityAction onStopMove;
        //Fire
        public event UnityAction onFire;
        public event UnityAction onStopFire;
        InputActions inputActions;

        private void OnEnable()
        {
            inputActions = new InputActions();
            inputActions.GamePlay.SetCallbacks(this);
        }
        private void OnDisable()
        {

        }
        public void DisableAllInputs()
        {
            inputActions.GamePlay.Disable();
        }
        public void EnableGamePlayInput()
        {
            inputActions.GamePlay.Enable();

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                onMove?.Invoke(context.ReadValue<Vector2>());
            }
            if (context.canceled)
            {
                onStopMove?.Invoke();
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnFire(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                onFire?.Invoke();
            }
            if (context.canceled)
            {
                onStopFire?.Invoke();
            }
        }
    }
}