using System;
using UnityEngine;

namespace Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private float sensX, sensY;
        [SerializeField] private Transform orientation;

        private float _xRotation, _yRotation, _xMouseInput, _yMouseInput;
        public bool CanMove { get; set; } = true;

        private void Start()
        {
            _yRotation = transform.eulerAngles.y;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            if (!CanMove) return;
            
            var mouseX = _xMouseInput * Time.deltaTime * sensX;
            var mouseY = _yMouseInput * Time.deltaTime * sensY;

            _yRotation += mouseX;
            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
            
            transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, _yRotation, 0);
        }

        public void SetMouseInput(Vector2 lookVector)
        {
            _xMouseInput = lookVector.x;
            _yMouseInput = lookVector.y;
        }

        public void SetRotationInY(float yRotation)
        {
            _yRotation = yRotation;
        }
    }
}