// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player Scripts/PlayerControls/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""8f5e6f26-dc69-47bf-a47d-0ff989dc4606"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f5167547-ea41-4c54-a415-de620ca398a0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""fb65080a-62a3-49ef-b11d-c41a58fd68fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraLook"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a8570cb0-f31a-4e72-b56f-1f90dfffe761"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""b644b32a-887d-4a0c-b195-6926fff9291c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""0875bd49-4fa1-438a-ac0e-594fd49c1d16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grab/Throw"",
                    ""type"": ""Button"",
                    ""id"": ""0c257a4c-af8f-4832-8ba9-9639752e8a06"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Puking"",
                    ""type"": ""Button"",
                    ""id"": ""15280c36-b272-44e3-b44a-ff53b91b4c3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Direction"",
                    ""id"": ""74081e87-405c-4a1b-8342-3b3d6a8b5aaf"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ed2af82f-19ba-4b8a-a8fe-98b8ea82b8c3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e34d1897-1765-432f-a8e9-031ca5113698"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""49b4b8a9-dcda-4517-9ef8-21607dfddb0b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ffd4d66d-a073-4396-90ac-2938eaad9bce"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fbc01845-42c4-4534-8604-269d8f993861"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""847fc5ec-63e9-41a6-b98e-2768d8ceb631"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47eb217e-eb50-45c1-ae48-3fc49194141b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce4380da-6481-4694-a6bb-12667f15b046"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2dd8eff-caad-4d30-9a6c-6083e56e1b48"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""caceb293-8f48-4eb2-ac67-d2b1446efc51"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ceb24954-65cb-4d61-a97b-7cdf547e7164"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d165b5b-f0ef-48b5-ad46-a9252ddbe52f"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd00df99-dc87-498a-9a36-3427d776058d"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c8aab1a-c026-4f42-ae51-b988a9672c57"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab/Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c58eb83-ca8f-4979-8c15-32b719a63970"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab/Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e137982-bc17-44a8-9433-7cdd2766702b"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Puking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""921b9d61-f558-473e-a61d-bffa65ffd6e2"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Puking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""9ad5adb9-93d7-4db8-9f28-887148a79a99"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""60b14a3a-edaf-47b4-ad46-08a1737ee7b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start Button"",
                    ""type"": ""Button"",
                    ""id"": ""118dabb4-139a-4fb9-a9a7-5a623ed2c92d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""(U) Menu Movement"",
                    ""type"": ""Button"",
                    ""id"": ""f7e72550-e500-47c4-8d2b-4e5beb7bf9c2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""(D) Menu Movement"",
                    ""type"": ""Button"",
                    ""id"": ""12a62470-bc51-4259-b7b1-fae759826674"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""(L) Menu Movement"",
                    ""type"": ""Button"",
                    ""id"": ""162f18c3-c571-405d-8597-2ed2e8faadc2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""(R) Menu Movement"",
                    ""type"": ""Button"",
                    ""id"": ""01672f5c-8cc6-406b-8597-9c2b4f40ba99"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b3a8670c-5ec6-454a-8587-68d397f34ab7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18a80530-1f1a-4f0c-8ba7-a1590a8f4b88"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfcd587f-941d-4394-b8d9-4b79b129c53d"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""588a2dc8-b23d-467c-89cb-e0446dc41861"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6eea367-7b11-4b62-a0cc-9da72b900b96"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac57280f-a58e-4bec-86fe-e32a83681724"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b34db769-aec7-454e-834c-c3f6342f60b9"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": ""Press"",
                    ""processors"": ""Normalize(min=1,max=1)"",
                    ""groups"": """",
                    ""action"": ""(L) Menu Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""403cb7ae-b80b-4194-ae0a-d242bbe919bf"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""(L) Menu Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0fe55750-ff0e-4a15-85e7-4efc182c39b1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""(L) Menu Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a62c7ede-f2eb-4a7e-b6da-3ca310b803ae"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""(L) Menu Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd329e74-aa32-4a04-a61a-d785b1fcb739"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": ""Press"",
                    ""processors"": ""Normalize(min=1,max=1)"",
                    ""groups"": """",
                    ""action"": ""(R) Menu Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a183431d-df30-4ce1-9e9a-b2f1d115b526"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""(R) Menu Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6837ebf1-33f8-4e8d-9572-4172de8d8246"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""(R) Menu Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""445c1a3c-e417-4878-81e0-e3f65d70343f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""(R) Menu Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6dff4853-238c-4709-8170-0df0924c6f95"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": ""Press"",
                    ""processors"": ""Normalize(min=1,max=1)"",
                    ""groups"": """",
                    ""action"": ""(U) Menu Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60c124e9-a1b7-4577-8224-c98149678320"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""(U) Menu Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9025b8e0-4b42-4489-82cd-47bcdd3b98e6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""(U) Menu Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c86ba00-6d05-42aa-835c-f742492873e4"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""(U) Menu Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bd5524c-ef99-4ab9-ac27-5b5960730ba6"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": ""Press"",
                    ""processors"": ""Normalize(min=1,max=1)"",
                    ""groups"": """",
                    ""action"": ""(D) Menu Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16d341ff-8a6e-4a6b-adf1-e5417fbe1bb5"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""(D) Menu Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e76e7ac-61d0-470c-922f-125711b255e9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""(D) Menu Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0e093cf-a4f4-44b3-b6c1-09149fb9fed6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""(D) Menu Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Trailer"",
            ""id"": ""93b2bada-d5e5-4325-9852-8e0957df9ef5"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bea5aec0-9bbb-4e39-9c68-ce98a00a48e5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Button"",
                    ""id"": ""204aee9b-fea4-4f07-90f1-ff906132a664"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Elevate"",
                    ""type"": ""Value"",
                    ""id"": ""6643b9f4-0e72-4281-896f-7ec4aba41422"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Decend"",
                    ""type"": ""Value"",
                    ""id"": ""4d27cae0-a146-4717-a368-459053bfd388"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Gameplay"",
                    ""type"": ""Button"",
                    ""id"": ""858c129e-d80f-46a4-9cd5-28e8b433596c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""220171c2-22d0-4ee9-afd4-a0e3eced2621"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9b4409ce-e19b-4f41-a975-2ae271fb8dcf"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""780771f2-e7e6-40c5-b8e5-378467bb5de8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e3259c2e-a32a-4a1c-859e-9e6af08100a4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1c749d2b-d091-41b1-8ef2-da4177dbb63b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""bdb2aeee-6b9d-427e-ba9a-00d4f7729052"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3df3b513-988b-4bce-a18a-9150c02c7371"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""14ab8ea1-25d4-472a-90c9-d130b8f36e5b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""15fdaf73-7f12-43cc-90e4-00f0f74197dd"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2efaa6d8-e893-4790-9a15-e8b738a9802d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""493bcade-b8e9-464d-8ad3-2f228a2766d7"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Elevate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""236e9743-4928-4908-8758-389abe19d2d5"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Decend"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53fbe881-49c3-4560-a860-70b21f25149a"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gameplay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_CameraLook = m_Player.FindAction("CameraLook", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_GrabThrow = m_Player.FindAction("Grab/Throw", throwIfNotFound: true);
        m_Player_Puking = m_Player.FindAction("Puking", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Select = m_Menu.FindAction("Select", throwIfNotFound: true);
        m_Menu_StartButton = m_Menu.FindAction("Start Button", throwIfNotFound: true);
        m_Menu_UMenuMovement = m_Menu.FindAction("(U) Menu Movement", throwIfNotFound: true);
        m_Menu_DMenuMovement = m_Menu.FindAction("(D) Menu Movement", throwIfNotFound: true);
        m_Menu_LMenuMovement = m_Menu.FindAction("(L) Menu Movement", throwIfNotFound: true);
        m_Menu_RMenuMovement = m_Menu.FindAction("(R) Menu Movement", throwIfNotFound: true);
        // Trailer
        m_Trailer = asset.FindActionMap("Trailer", throwIfNotFound: true);
        m_Trailer_Movement = m_Trailer.FindAction("Movement", throwIfNotFound: true);
        m_Trailer_Rotation = m_Trailer.FindAction("Rotation", throwIfNotFound: true);
        m_Trailer_Elevate = m_Trailer.FindAction("Elevate", throwIfNotFound: true);
        m_Trailer_Decend = m_Trailer.FindAction("Decend", throwIfNotFound: true);
        m_Trailer_Gameplay = m_Trailer.FindAction("Gameplay", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_CameraLook;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_GrabThrow;
    private readonly InputAction m_Player_Puking;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @CameraLook => m_Wrapper.m_Player_CameraLook;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @GrabThrow => m_Wrapper.m_Player_GrabThrow;
        public InputAction @Puking => m_Wrapper.m_Player_Puking;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @CameraLook.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraLook;
                @CameraLook.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraLook;
                @CameraLook.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraLook;
                @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @GrabThrow.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrabThrow;
                @GrabThrow.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrabThrow;
                @GrabThrow.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrabThrow;
                @Puking.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPuking;
                @Puking.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPuking;
                @Puking.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPuking;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @CameraLook.started += instance.OnCameraLook;
                @CameraLook.performed += instance.OnCameraLook;
                @CameraLook.canceled += instance.OnCameraLook;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @GrabThrow.started += instance.OnGrabThrow;
                @GrabThrow.performed += instance.OnGrabThrow;
                @GrabThrow.canceled += instance.OnGrabThrow;
                @Puking.started += instance.OnPuking;
                @Puking.performed += instance.OnPuking;
                @Puking.canceled += instance.OnPuking;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Select;
    private readonly InputAction m_Menu_StartButton;
    private readonly InputAction m_Menu_UMenuMovement;
    private readonly InputAction m_Menu_DMenuMovement;
    private readonly InputAction m_Menu_LMenuMovement;
    private readonly InputAction m_Menu_RMenuMovement;
    public struct MenuActions
    {
        private @PlayerInput m_Wrapper;
        public MenuActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_Menu_Select;
        public InputAction @StartButton => m_Wrapper.m_Menu_StartButton;
        public InputAction @UMenuMovement => m_Wrapper.m_Menu_UMenuMovement;
        public InputAction @DMenuMovement => m_Wrapper.m_Menu_DMenuMovement;
        public InputAction @LMenuMovement => m_Wrapper.m_Menu_LMenuMovement;
        public InputAction @RMenuMovement => m_Wrapper.m_Menu_RMenuMovement;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelect;
                @StartButton.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnStartButton;
                @StartButton.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnStartButton;
                @StartButton.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnStartButton;
                @UMenuMovement.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnUMenuMovement;
                @UMenuMovement.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnUMenuMovement;
                @UMenuMovement.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnUMenuMovement;
                @DMenuMovement.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnDMenuMovement;
                @DMenuMovement.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnDMenuMovement;
                @DMenuMovement.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnDMenuMovement;
                @LMenuMovement.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnLMenuMovement;
                @LMenuMovement.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnLMenuMovement;
                @LMenuMovement.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnLMenuMovement;
                @RMenuMovement.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnRMenuMovement;
                @RMenuMovement.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnRMenuMovement;
                @RMenuMovement.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnRMenuMovement;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @StartButton.started += instance.OnStartButton;
                @StartButton.performed += instance.OnStartButton;
                @StartButton.canceled += instance.OnStartButton;
                @UMenuMovement.started += instance.OnUMenuMovement;
                @UMenuMovement.performed += instance.OnUMenuMovement;
                @UMenuMovement.canceled += instance.OnUMenuMovement;
                @DMenuMovement.started += instance.OnDMenuMovement;
                @DMenuMovement.performed += instance.OnDMenuMovement;
                @DMenuMovement.canceled += instance.OnDMenuMovement;
                @LMenuMovement.started += instance.OnLMenuMovement;
                @LMenuMovement.performed += instance.OnLMenuMovement;
                @LMenuMovement.canceled += instance.OnLMenuMovement;
                @RMenuMovement.started += instance.OnRMenuMovement;
                @RMenuMovement.performed += instance.OnRMenuMovement;
                @RMenuMovement.canceled += instance.OnRMenuMovement;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);

    // Trailer
    private readonly InputActionMap m_Trailer;
    private ITrailerActions m_TrailerActionsCallbackInterface;
    private readonly InputAction m_Trailer_Movement;
    private readonly InputAction m_Trailer_Rotation;
    private readonly InputAction m_Trailer_Elevate;
    private readonly InputAction m_Trailer_Decend;
    private readonly InputAction m_Trailer_Gameplay;
    public struct TrailerActions
    {
        private @PlayerInput m_Wrapper;
        public TrailerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Trailer_Movement;
        public InputAction @Rotation => m_Wrapper.m_Trailer_Rotation;
        public InputAction @Elevate => m_Wrapper.m_Trailer_Elevate;
        public InputAction @Decend => m_Wrapper.m_Trailer_Decend;
        public InputAction @Gameplay => m_Wrapper.m_Trailer_Gameplay;
        public InputActionMap Get() { return m_Wrapper.m_Trailer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TrailerActions set) { return set.Get(); }
        public void SetCallbacks(ITrailerActions instance)
        {
            if (m_Wrapper.m_TrailerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_TrailerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_TrailerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_TrailerActionsCallbackInterface.OnMovement;
                @Rotation.started -= m_Wrapper.m_TrailerActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_TrailerActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_TrailerActionsCallbackInterface.OnRotation;
                @Elevate.started -= m_Wrapper.m_TrailerActionsCallbackInterface.OnElevate;
                @Elevate.performed -= m_Wrapper.m_TrailerActionsCallbackInterface.OnElevate;
                @Elevate.canceled -= m_Wrapper.m_TrailerActionsCallbackInterface.OnElevate;
                @Decend.started -= m_Wrapper.m_TrailerActionsCallbackInterface.OnDecend;
                @Decend.performed -= m_Wrapper.m_TrailerActionsCallbackInterface.OnDecend;
                @Decend.canceled -= m_Wrapper.m_TrailerActionsCallbackInterface.OnDecend;
                @Gameplay.started -= m_Wrapper.m_TrailerActionsCallbackInterface.OnGameplay;
                @Gameplay.performed -= m_Wrapper.m_TrailerActionsCallbackInterface.OnGameplay;
                @Gameplay.canceled -= m_Wrapper.m_TrailerActionsCallbackInterface.OnGameplay;
            }
            m_Wrapper.m_TrailerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
                @Elevate.started += instance.OnElevate;
                @Elevate.performed += instance.OnElevate;
                @Elevate.canceled += instance.OnElevate;
                @Decend.started += instance.OnDecend;
                @Decend.performed += instance.OnDecend;
                @Decend.canceled += instance.OnDecend;
                @Gameplay.started += instance.OnGameplay;
                @Gameplay.performed += instance.OnGameplay;
                @Gameplay.canceled += instance.OnGameplay;
            }
        }
    }
    public TrailerActions @Trailer => new TrailerActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCameraLook(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnGrabThrow(InputAction.CallbackContext context);
        void OnPuking(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnStartButton(InputAction.CallbackContext context);
        void OnUMenuMovement(InputAction.CallbackContext context);
        void OnDMenuMovement(InputAction.CallbackContext context);
        void OnLMenuMovement(InputAction.CallbackContext context);
        void OnRMenuMovement(InputAction.CallbackContext context);
    }
    public interface ITrailerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
        void OnElevate(InputAction.CallbackContext context);
        void OnDecend(InputAction.CallbackContext context);
        void OnGameplay(InputAction.CallbackContext context);
    }
}
