// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""14bdf4fd-a6ec-4693-8db6-b47d02bd72a9"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4e7e6a27-b4c8-4ce2-a891-8be6026051f4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""89afb8ff-bb86-424c-b5f6-09ad90fa5902"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""e6bbb856-d4d0-4ca1-8a58-ca4081a18f74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Overdrive"",
                    ""type"": ""Button"",
                    ""id"": ""f4a3b4ca-5565-44e7-b648-42a7234cd685"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""aabe27be-fa66-46fb-847e-72deeaa1cde6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Launch Missile"",
                    ""type"": ""Button"",
                    ""id"": ""cd50d22f-aa53-49ea-a974-2b537ecafab4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""15b404e9-9954-4bc5-9909-51f777431993"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""680fab5b-0572-405c-b540-405c391fa96e"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""b97110f0-b39f-4285-b53b-4a0db9662b59"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dffef768-6417-4a79-8cc9-17528c3b78c4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""46e80302-774c-4d87-89c9-d5de19d87d98"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""19b64b0a-0a4d-4e73-ba20-b940e167edc6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cc597171-d3ab-4b4c-bfc5-545a975308b1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""92ad5f56-aa07-4a42-bece-ec5cc88cbc7f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""67fb3060-599d-4be8-b29c-49eb18931c49"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e1a93f17-c090-421c-834f-c906e7d45c33"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fc392cd8-6181-48fb-83cd-6b3c3df570b4"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""594a89f1-c3c9-4838-b21f-874ae2d10948"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""655592c9-94b1-4ae1-9ed1-f97e37c520db"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b56aafb-115a-4392-bbfa-4f6a753aebbb"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa08cc3a-8059-444a-afa9-0a7b25bf58d9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7baa709-e2e4-4cec-95a0-1a9fa939860a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1569b6da-b7bf-42c5-8c9d-0d4fc9b457e0"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Overdrive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4f24054-f12d-4a4c-9ec5-152fa826b07c"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Overdrive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7ce982d-0d70-4041-be29-c94e823e38a2"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbec2c27-da7d-49eb-af20-653ff33d0304"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20b39250-7f44-4d21-919f-857b7e96e778"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Launch Missile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e988a4fb-acb1-4e4c-b5c6-5accba00b62a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Launch Missile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PauseMenu"",
            ""id"": ""d970ef77-0d42-4ece-aa9e-7c7f72a92ad1"",
            ""actions"": [
                {
                    ""name"": ""Unpause"",
                    ""type"": ""Button"",
                    ""id"": ""f716a4a0-028e-4773-a269-4e3a0bbd3980"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""964580e3-83f9-49fe-a26d-fd52a73524ec"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Unpause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6351e991-6c0d-4d7e-a5de-4c01da94fce5"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Unpause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GameOverScreen"",
            ""id"": ""0f6bc12f-d3e5-4afb-8204-9b0352e6e312"",
            ""actions"": [
                {
                    ""name"": ""ConfirmGameOver"",
                    ""type"": ""Button"",
                    ""id"": ""a22e16c0-21e8-4126-838a-8dec17635688"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3fc93e0f-264c-416a-ba54-2c469ad0487d"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ConfirmGameOver"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42959747-f9be-438f-9bfc-416051ba68eb"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ConfirmGameOver"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33207f21-c068-4867-8043-4566a290de51"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ConfirmGameOver"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc34f1d1-cf99-4044-a67c-4b8d7c63b82d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ConfirmGameOver"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_Move = m_GamePlay.FindAction("Move", throwIfNotFound: true);
        m_GamePlay_Fire = m_GamePlay.FindAction("Fire", throwIfNotFound: true);
        m_GamePlay_Dodge = m_GamePlay.FindAction("Dodge", throwIfNotFound: true);
        m_GamePlay_Overdrive = m_GamePlay.FindAction("Overdrive", throwIfNotFound: true);
        m_GamePlay_Pause = m_GamePlay.FindAction("Pause", throwIfNotFound: true);
        m_GamePlay_LaunchMissile = m_GamePlay.FindAction("Launch Missile", throwIfNotFound: true);
        // PauseMenu
        m_PauseMenu = asset.FindActionMap("PauseMenu", throwIfNotFound: true);
        m_PauseMenu_Unpause = m_PauseMenu.FindAction("Unpause", throwIfNotFound: true);
        // GameOverScreen
        m_GameOverScreen = asset.FindActionMap("GameOverScreen", throwIfNotFound: true);
        m_GameOverScreen_ConfirmGameOver = m_GameOverScreen.FindAction("ConfirmGameOver", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Move;
    private readonly InputAction m_GamePlay_Fire;
    private readonly InputAction m_GamePlay_Dodge;
    private readonly InputAction m_GamePlay_Overdrive;
    private readonly InputAction m_GamePlay_Pause;
    private readonly InputAction m_GamePlay_LaunchMissile;
    public struct GamePlayActions
    {
        private @InputActions m_Wrapper;
        public GamePlayActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_GamePlay_Move;
        public InputAction @Fire => m_Wrapper.m_GamePlay_Fire;
        public InputAction @Dodge => m_Wrapper.m_GamePlay_Dodge;
        public InputAction @Overdrive => m_Wrapper.m_GamePlay_Overdrive;
        public InputAction @Pause => m_Wrapper.m_GamePlay_Pause;
        public InputAction @LaunchMissile => m_Wrapper.m_GamePlay_LaunchMissile;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Fire.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFire;
                @Dodge.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDodge;
                @Overdrive.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOverdrive;
                @Overdrive.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOverdrive;
                @Overdrive.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOverdrive;
                @Pause.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPause;
                @LaunchMissile.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLaunchMissile;
                @LaunchMissile.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLaunchMissile;
                @LaunchMissile.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLaunchMissile;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @Overdrive.started += instance.OnOverdrive;
                @Overdrive.performed += instance.OnOverdrive;
                @Overdrive.canceled += instance.OnOverdrive;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @LaunchMissile.started += instance.OnLaunchMissile;
                @LaunchMissile.performed += instance.OnLaunchMissile;
                @LaunchMissile.canceled += instance.OnLaunchMissile;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);

    // PauseMenu
    private readonly InputActionMap m_PauseMenu;
    private IPauseMenuActions m_PauseMenuActionsCallbackInterface;
    private readonly InputAction m_PauseMenu_Unpause;
    public struct PauseMenuActions
    {
        private @InputActions m_Wrapper;
        public PauseMenuActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Unpause => m_Wrapper.m_PauseMenu_Unpause;
        public InputActionMap Get() { return m_Wrapper.m_PauseMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseMenuActions set) { return set.Get(); }
        public void SetCallbacks(IPauseMenuActions instance)
        {
            if (m_Wrapper.m_PauseMenuActionsCallbackInterface != null)
            {
                @Unpause.started -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnUnpause;
                @Unpause.performed -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnUnpause;
                @Unpause.canceled -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnUnpause;
            }
            m_Wrapper.m_PauseMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Unpause.started += instance.OnUnpause;
                @Unpause.performed += instance.OnUnpause;
                @Unpause.canceled += instance.OnUnpause;
            }
        }
    }
    public PauseMenuActions @PauseMenu => new PauseMenuActions(this);

    // GameOverScreen
    private readonly InputActionMap m_GameOverScreen;
    private IGameOverScreenActions m_GameOverScreenActionsCallbackInterface;
    private readonly InputAction m_GameOverScreen_ConfirmGameOver;
    public struct GameOverScreenActions
    {
        private @InputActions m_Wrapper;
        public GameOverScreenActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ConfirmGameOver => m_Wrapper.m_GameOverScreen_ConfirmGameOver;
        public InputActionMap Get() { return m_Wrapper.m_GameOverScreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameOverScreenActions set) { return set.Get(); }
        public void SetCallbacks(IGameOverScreenActions instance)
        {
            if (m_Wrapper.m_GameOverScreenActionsCallbackInterface != null)
            {
                @ConfirmGameOver.started -= m_Wrapper.m_GameOverScreenActionsCallbackInterface.OnConfirmGameOver;
                @ConfirmGameOver.performed -= m_Wrapper.m_GameOverScreenActionsCallbackInterface.OnConfirmGameOver;
                @ConfirmGameOver.canceled -= m_Wrapper.m_GameOverScreenActionsCallbackInterface.OnConfirmGameOver;
            }
            m_Wrapper.m_GameOverScreenActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ConfirmGameOver.started += instance.OnConfirmGameOver;
                @ConfirmGameOver.performed += instance.OnConfirmGameOver;
                @ConfirmGameOver.canceled += instance.OnConfirmGameOver;
            }
        }
    }
    public GameOverScreenActions @GameOverScreen => new GameOverScreenActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IGamePlayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnOverdrive(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnLaunchMissile(InputAction.CallbackContext context);
    }
    public interface IPauseMenuActions
    {
        void OnUnpause(InputAction.CallbackContext context);
    }
    public interface IGameOverScreenActions
    {
        void OnConfirmGameOver(InputAction.CallbackContext context);
    }
}
