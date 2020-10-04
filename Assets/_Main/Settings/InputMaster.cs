// GENERATED AUTOMATICALLY FROM 'Assets/_Main/Settings/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Global"",
            ""id"": ""96e21e6e-e563-4d7e-9b7c-6239163a8ca2"",
            ""actions"": [
                {
                    ""name"": ""Reload Scene"",
                    ""type"": ""Button"",
                    ""id"": ""9ad17b2b-b4cb-4a4a-8933-45ec241728d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit To Main Menu"",
                    ""type"": ""Button"",
                    ""id"": ""ff1f1a3a-dda8-4f01-88f1-9628c931a8ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9678ed98-0bd7-4597-8aa9-33885dd2dbff"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Reload Scene"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc5da659-484a-4119-bb2b-e501f643f62c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Exit To Main Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""0cb770c9-8d3a-4b5e-a127-cb17c475b30a"",
            ""actions"": [
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""c7c43e71-f1f1-4b26-9bc7-8dd46ece7bf9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4de8eccc-df9e-4c0a-99b3-842e051f64f4"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfd65358-7394-4640-bf2f-ca571d4b699f"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed3c5d76-eb69-48d6-a4a4-82d69920b064"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Tower Defense"",
            ""id"": ""d097eb97-2aaf-4167-bab3-59e6cd82f91a"",
            ""actions"": [
                {
                    ""name"": ""Speedx1"",
                    ""type"": ""Button"",
                    ""id"": ""b7c97c13-c683-4337-8026-c408686aca1c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Speedx2"",
                    ""type"": ""Button"",
                    ""id"": ""f135f295-eb66-4a76-ad98-d7c75e1219ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Speedx3"",
                    ""type"": ""Button"",
                    ""id"": ""2804cc61-599c-4190-831c-b8620955d535"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Speedx4"",
                    ""type"": ""Button"",
                    ""id"": ""0d53d48e-03f0-44fd-b93b-29c2277fde9f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Speedx5"",
                    ""type"": ""Button"",
                    ""id"": ""5d670af6-d89c-49d6-a1af-a08a77c61eb0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skip Wave"",
                    ""type"": ""Button"",
                    ""id"": ""39df5c88-8611-4024-b6ce-ef596184bc29"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fa0f4d1c-9eb5-4250-81c5-5b2b7dac2783"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Speedx1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d5a308e-18c4-42d3-aa16-437bcbb277da"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Speedx2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e452630-c2d4-41e3-837c-47e2c0f7f022"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Speedx3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2667bc08-9ca5-4551-84ce-633faf8445c9"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Speedx4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae7a847c-1c32-4fe5-b43e-504efcf216be"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Speedx5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""495374d4-9ceb-48cd-9cfc-b5eeebfa24d9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Skip Wave"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Endless Runner"",
            ""id"": ""494a0c87-7590-4e30-964f-8c1a7979a003"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""9e9e14af-3530-46ab-901f-cf799bd295f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Slide"",
                    ""type"": ""Button"",
                    ""id"": ""24fe9e40-7024-4728-af74-2d01575d1fd3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""040186d4-b39b-42be-8153-98689cd20d3b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6631d5a-7d25-4fa0-a7ae-314b72381aa9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d816721-7d7d-4a2b-bc90-3a841510d6ec"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5d2e5db-6982-4dae-a00a-3fe8da521625"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""caf73e15-9468-448c-9974-47fe1b2cc05f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c91d5a4-91f2-493b-99a6-1695eead7108"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Twin Stick Shooter"",
            ""id"": ""643edcef-f905-42d9-ade8-60ce8c3d3a72"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""83b20b9b-ab1e-4574-8ded-dc4e0d3404e5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""7cfc4a68-6f78-47fe-8f83-62b220769bda"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""996e9ed8-5c81-4314-bdbc-104c66c256c7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ba2112d4-d002-434a-ae34-690ed4f0d458"",
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
                    ""id"": ""d8861874-0573-4473-bede-a93ebe3437cd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""00bfbec8-10dd-4bbd-9cc8-7e32cd6f37c2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""438e56ea-c761-4297-8863-348a61ac89ab"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6e49aa4b-053c-4048-9f16-a34fc7ff28d7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""08c1864c-e699-4bd3-b4cb-e8a2feef7896"",
                    ""path"": ""*/{Point}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2afa7824-4e5c-417f-a720-356ea80099f9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6317a518-492c-4e1a-9c83-c9336f0f7c6a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KBM"",
            ""bindingGroup"": ""KBM"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Global
        m_Global = asset.FindActionMap("Global", throwIfNotFound: true);
        m_Global_ReloadScene = m_Global.FindAction("Reload Scene", throwIfNotFound: true);
        m_Global_ExitToMainMenu = m_Global.FindAction("Exit To Main Menu", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Confirm = m_UI.FindAction("Confirm", throwIfNotFound: true);
        // Tower Defense
        m_TowerDefense = asset.FindActionMap("Tower Defense", throwIfNotFound: true);
        m_TowerDefense_Speedx1 = m_TowerDefense.FindAction("Speedx1", throwIfNotFound: true);
        m_TowerDefense_Speedx2 = m_TowerDefense.FindAction("Speedx2", throwIfNotFound: true);
        m_TowerDefense_Speedx3 = m_TowerDefense.FindAction("Speedx3", throwIfNotFound: true);
        m_TowerDefense_Speedx4 = m_TowerDefense.FindAction("Speedx4", throwIfNotFound: true);
        m_TowerDefense_Speedx5 = m_TowerDefense.FindAction("Speedx5", throwIfNotFound: true);
        m_TowerDefense_SkipWave = m_TowerDefense.FindAction("Skip Wave", throwIfNotFound: true);
        // Endless Runner
        m_EndlessRunner = asset.FindActionMap("Endless Runner", throwIfNotFound: true);
        m_EndlessRunner_Jump = m_EndlessRunner.FindAction("Jump", throwIfNotFound: true);
        m_EndlessRunner_Slide = m_EndlessRunner.FindAction("Slide", throwIfNotFound: true);
        // Twin Stick Shooter
        m_TwinStickShooter = asset.FindActionMap("Twin Stick Shooter", throwIfNotFound: true);
        m_TwinStickShooter_Move = m_TwinStickShooter.FindAction("Move", throwIfNotFound: true);
        m_TwinStickShooter_Aim = m_TwinStickShooter.FindAction("Aim", throwIfNotFound: true);
        m_TwinStickShooter_Shoot = m_TwinStickShooter.FindAction("Shoot", throwIfNotFound: true);
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

    // Global
    private readonly InputActionMap m_Global;
    private IGlobalActions m_GlobalActionsCallbackInterface;
    private readonly InputAction m_Global_ReloadScene;
    private readonly InputAction m_Global_ExitToMainMenu;
    public struct GlobalActions
    {
        private @InputMaster m_Wrapper;
        public GlobalActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @ReloadScene => m_Wrapper.m_Global_ReloadScene;
        public InputAction @ExitToMainMenu => m_Wrapper.m_Global_ExitToMainMenu;
        public InputActionMap Get() { return m_Wrapper.m_Global; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GlobalActions set) { return set.Get(); }
        public void SetCallbacks(IGlobalActions instance)
        {
            if (m_Wrapper.m_GlobalActionsCallbackInterface != null)
            {
                @ReloadScene.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnReloadScene;
                @ReloadScene.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnReloadScene;
                @ReloadScene.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnReloadScene;
                @ExitToMainMenu.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnExitToMainMenu;
                @ExitToMainMenu.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnExitToMainMenu;
                @ExitToMainMenu.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnExitToMainMenu;
            }
            m_Wrapper.m_GlobalActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ReloadScene.started += instance.OnReloadScene;
                @ReloadScene.performed += instance.OnReloadScene;
                @ReloadScene.canceled += instance.OnReloadScene;
                @ExitToMainMenu.started += instance.OnExitToMainMenu;
                @ExitToMainMenu.performed += instance.OnExitToMainMenu;
                @ExitToMainMenu.canceled += instance.OnExitToMainMenu;
            }
        }
    }
    public GlobalActions @Global => new GlobalActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Confirm;
    public struct UIActions
    {
        private @InputMaster m_Wrapper;
        public UIActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Confirm => m_Wrapper.m_UI_Confirm;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Confirm.started -= m_Wrapper.m_UIActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnConfirm;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // Tower Defense
    private readonly InputActionMap m_TowerDefense;
    private ITowerDefenseActions m_TowerDefenseActionsCallbackInterface;
    private readonly InputAction m_TowerDefense_Speedx1;
    private readonly InputAction m_TowerDefense_Speedx2;
    private readonly InputAction m_TowerDefense_Speedx3;
    private readonly InputAction m_TowerDefense_Speedx4;
    private readonly InputAction m_TowerDefense_Speedx5;
    private readonly InputAction m_TowerDefense_SkipWave;
    public struct TowerDefenseActions
    {
        private @InputMaster m_Wrapper;
        public TowerDefenseActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Speedx1 => m_Wrapper.m_TowerDefense_Speedx1;
        public InputAction @Speedx2 => m_Wrapper.m_TowerDefense_Speedx2;
        public InputAction @Speedx3 => m_Wrapper.m_TowerDefense_Speedx3;
        public InputAction @Speedx4 => m_Wrapper.m_TowerDefense_Speedx4;
        public InputAction @Speedx5 => m_Wrapper.m_TowerDefense_Speedx5;
        public InputAction @SkipWave => m_Wrapper.m_TowerDefense_SkipWave;
        public InputActionMap Get() { return m_Wrapper.m_TowerDefense; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TowerDefenseActions set) { return set.Get(); }
        public void SetCallbacks(ITowerDefenseActions instance)
        {
            if (m_Wrapper.m_TowerDefenseActionsCallbackInterface != null)
            {
                @Speedx1.started -= m_Wrapper.m_TowerDefenseActionsCallbackInterface.OnSpeedx1;
                @Speedx1.performed -= m_Wrapper.m_TowerDefenseActionsCallbackInterface.OnSpeedx1;
                @Speedx1.canceled -= m_Wrapper.m_TowerDefenseActionsCallbackInterface.OnSpeedx1;
                @Speedx2.started -= m_Wrapper.m_TowerDefenseActionsCallbackInterface.OnSpeedx2;
                @Speedx2.performed -= m_Wrapper.m_TowerDefenseActionsCallbackInterface.OnSpeedx2;
                @Speedx2.canceled -= m_Wrapper.m_TowerDefenseActionsCallbackInterface.OnSpeedx2;
                @Speedx3.started -= m_Wrapper.m_TowerDefenseActionsCallbackInterface.OnSpeedx3;
                @Speedx3.performed -= m_Wrapper.m_TowerDefenseActionsCallbackInterface.OnSpeedx3;
                @Speedx3.canceled -= m_Wrapper.m_TowerDefenseActionsCallbackInterface.OnSpeedx3;
                @Speedx4.started -= m_Wrapper.m_TowerDefenseActionsCallbackInterface.OnSpeedx4;
                @Speedx4.performed -= m_Wrapper.m_TowerDefenseActionsCallbackInterface.OnSpeedx4;
                @Speedx4.canceled -= m_Wrapper.m_TowerDefenseActionsCallbackInterface.OnSpeedx4;
                @Speedx5.started -= m_Wrapper.m_TowerDefenseActionsCallbackInterface.OnSpeedx5;
                @Speedx5.performed -= m_Wrapper.m_TowerDefenseActionsCallbackInterface.OnSpeedx5;
                @Speedx5.canceled -= m_Wrapper.m_TowerDefenseActionsCallbackInterface.OnSpeedx5;
                @SkipWave.started -= m_Wrapper.m_TowerDefenseActionsCallbackInterface.OnSkipWave;
                @SkipWave.performed -= m_Wrapper.m_TowerDefenseActionsCallbackInterface.OnSkipWave;
                @SkipWave.canceled -= m_Wrapper.m_TowerDefenseActionsCallbackInterface.OnSkipWave;
            }
            m_Wrapper.m_TowerDefenseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Speedx1.started += instance.OnSpeedx1;
                @Speedx1.performed += instance.OnSpeedx1;
                @Speedx1.canceled += instance.OnSpeedx1;
                @Speedx2.started += instance.OnSpeedx2;
                @Speedx2.performed += instance.OnSpeedx2;
                @Speedx2.canceled += instance.OnSpeedx2;
                @Speedx3.started += instance.OnSpeedx3;
                @Speedx3.performed += instance.OnSpeedx3;
                @Speedx3.canceled += instance.OnSpeedx3;
                @Speedx4.started += instance.OnSpeedx4;
                @Speedx4.performed += instance.OnSpeedx4;
                @Speedx4.canceled += instance.OnSpeedx4;
                @Speedx5.started += instance.OnSpeedx5;
                @Speedx5.performed += instance.OnSpeedx5;
                @Speedx5.canceled += instance.OnSpeedx5;
                @SkipWave.started += instance.OnSkipWave;
                @SkipWave.performed += instance.OnSkipWave;
                @SkipWave.canceled += instance.OnSkipWave;
            }
        }
    }
    public TowerDefenseActions @TowerDefense => new TowerDefenseActions(this);

    // Endless Runner
    private readonly InputActionMap m_EndlessRunner;
    private IEndlessRunnerActions m_EndlessRunnerActionsCallbackInterface;
    private readonly InputAction m_EndlessRunner_Jump;
    private readonly InputAction m_EndlessRunner_Slide;
    public struct EndlessRunnerActions
    {
        private @InputMaster m_Wrapper;
        public EndlessRunnerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_EndlessRunner_Jump;
        public InputAction @Slide => m_Wrapper.m_EndlessRunner_Slide;
        public InputActionMap Get() { return m_Wrapper.m_EndlessRunner; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(EndlessRunnerActions set) { return set.Get(); }
        public void SetCallbacks(IEndlessRunnerActions instance)
        {
            if (m_Wrapper.m_EndlessRunnerActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_EndlessRunnerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_EndlessRunnerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_EndlessRunnerActionsCallbackInterface.OnJump;
                @Slide.started -= m_Wrapper.m_EndlessRunnerActionsCallbackInterface.OnSlide;
                @Slide.performed -= m_Wrapper.m_EndlessRunnerActionsCallbackInterface.OnSlide;
                @Slide.canceled -= m_Wrapper.m_EndlessRunnerActionsCallbackInterface.OnSlide;
            }
            m_Wrapper.m_EndlessRunnerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Slide.started += instance.OnSlide;
                @Slide.performed += instance.OnSlide;
                @Slide.canceled += instance.OnSlide;
            }
        }
    }
    public EndlessRunnerActions @EndlessRunner => new EndlessRunnerActions(this);

    // Twin Stick Shooter
    private readonly InputActionMap m_TwinStickShooter;
    private ITwinStickShooterActions m_TwinStickShooterActionsCallbackInterface;
    private readonly InputAction m_TwinStickShooter_Move;
    private readonly InputAction m_TwinStickShooter_Aim;
    private readonly InputAction m_TwinStickShooter_Shoot;
    public struct TwinStickShooterActions
    {
        private @InputMaster m_Wrapper;
        public TwinStickShooterActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_TwinStickShooter_Move;
        public InputAction @Aim => m_Wrapper.m_TwinStickShooter_Aim;
        public InputAction @Shoot => m_Wrapper.m_TwinStickShooter_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_TwinStickShooter; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TwinStickShooterActions set) { return set.Get(); }
        public void SetCallbacks(ITwinStickShooterActions instance)
        {
            if (m_Wrapper.m_TwinStickShooterActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_TwinStickShooterActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TwinStickShooterActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TwinStickShooterActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_TwinStickShooterActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_TwinStickShooterActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_TwinStickShooterActionsCallbackInterface.OnAim;
                @Shoot.started -= m_Wrapper.m_TwinStickShooterActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_TwinStickShooterActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_TwinStickShooterActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_TwinStickShooterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public TwinStickShooterActions @TwinStickShooter => new TwinStickShooterActions(this);
    private int m_KBMSchemeIndex = -1;
    public InputControlScheme KBMScheme
    {
        get
        {
            if (m_KBMSchemeIndex == -1) m_KBMSchemeIndex = asset.FindControlSchemeIndex("KBM");
            return asset.controlSchemes[m_KBMSchemeIndex];
        }
    }
    public interface IGlobalActions
    {
        void OnReloadScene(InputAction.CallbackContext context);
        void OnExitToMainMenu(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnConfirm(InputAction.CallbackContext context);
    }
    public interface ITowerDefenseActions
    {
        void OnSpeedx1(InputAction.CallbackContext context);
        void OnSpeedx2(InputAction.CallbackContext context);
        void OnSpeedx3(InputAction.CallbackContext context);
        void OnSpeedx4(InputAction.CallbackContext context);
        void OnSpeedx5(InputAction.CallbackContext context);
        void OnSkipWave(InputAction.CallbackContext context);
    }
    public interface IEndlessRunnerActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnSlide(InputAction.CallbackContext context);
    }
    public interface ITwinStickShooterActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
