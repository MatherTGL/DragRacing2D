using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Player.Movement
{
    [RequireComponent(typeof(Collider2D))]
    public sealed class HandlerButtonPlayerMovement : MonoBehaviour, IHandlerButtonPlayerMovement
    {
        public enum TypeButtonMovement : byte { Drive, Brake }

        [SerializeField, EnumToggleButtons]
        private TypeButtonMovement _typeButtonMovement;
        TypeButtonMovement IHandlerButtonPlayerMovement.typeButtonMovement => _typeButtonMovement;

        [SerializeField, Required]
        private AudioSource _raceAudio;

        [SerializeField, Required]
        private AudioSource _brakeAudio;

        private bool _isPressed;
        bool IHandlerButtonPlayerMovement.isPressed => _isPressed;


#if UNITY_EDITOR
        private void OnMouseDown()
        {
            if (_typeButtonMovement is TypeButtonMovement.Drive)
                _raceAudio.Play();
            else
                _brakeAudio.Play();
            _isPressed = true;
        }

        private void OnMouseUp()
        {
            if (_typeButtonMovement is TypeButtonMovement.Drive)
                _raceAudio.Stop();
            else
                _brakeAudio.Stop();

            _isPressed = false;
        }
#endif

        public void OnTouchDown()
        {
            if (_typeButtonMovement is TypeButtonMovement.Drive)
                _raceAudio.Play();
            else
                _brakeAudio.Play();
            _isPressed = true;
        }

        public void OnTouchUp()
        {
            if (_typeButtonMovement is TypeButtonMovement.Drive)
                _raceAudio.Stop();
            else
                _brakeAudio.Stop();

            _isPressed = false;
        }
    }
}

