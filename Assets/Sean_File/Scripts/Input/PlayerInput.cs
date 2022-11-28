using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
namespace Sean
{
    [CreateAssetMenu(fileName = "Player Input")]
    public class PlayerInput : ScriptableObject, InputActions.IGamePlayActions,InputActions.IPauseMenuActions
    {
        //Move
        public event UnityAction<Vector2> onMove;
        public event UnityAction onStopMove;
        //Fire
        public event UnityAction onFire;
        public event UnityAction onStopFire;
        public event UnityAction onDodge;
        public event UnityAction onOverdrive;
        public event UnityAction onPause;
        public event UnityAction onUnpause;
        InputActions inputActions;

        private void OnEnable()
        {
            inputActions = new InputActions();
            inputActions.GamePlay.SetCallbacks(this);
            inputActions.PauseMenu.SetCallbacks(this);
        }
        private void OnDisable()
        {
            DisableAllInputs();
        }
        void SwitchActionMap(InputActionMap actionMap,bool isUIInput)
        {
            inputActions.Disable();
            actionMap.Enable();

            if (isUIInput)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        public void SwitchToDynamicUpdateMode() => InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate;
        public void SwitchToFixedUpdateMode() => InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
        public void DisableAllInputs()=>inputActions.Disable();
        
        public void EnableGamePlayInput() => SwitchActionMap(inputActions.GamePlay,false);
        public void EnablePauseMenuInput() => SwitchActionMap(inputActions.PauseMenu,true);
     
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

        public void OnDodge(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                onDodge?.Invoke();
            }
        }

        public void OnOverdrive(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                onOverdrive.Invoke();
            }
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                onPause.Invoke();
            }
        }

        public void OnUnpause(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                onUnpause.Invoke();
            }
        }
    }
}