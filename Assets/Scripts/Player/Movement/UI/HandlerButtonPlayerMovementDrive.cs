using Player.Movement.View;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UI.Player.Movement
{
    [RequireComponent(typeof(Collider2D))]
    public sealed class HandlerButtonPlayerMovement : MonoBehaviour, IHandlerButtonPlayerMovement
    {
        private enum TypeButtonMovement : byte { Drive, Brake }
        
        [SerializeField, EnumToggleButtons]
        private TypeButtonMovement _typeButtonMovement;

        private bool _isPressed;


        private void OnMouseDown()
        {
            _isPressed = true;
        }

        private void OnMouseUp()
        {
            _isPressed = false;
        }
    }
}

