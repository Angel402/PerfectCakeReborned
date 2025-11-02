using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed, runSpeed, groundDrag, playerHeight;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform orientation;
        [SerializeField] private Rigidbody playerRigidbody;

        private float _horizontalInput, _verticalInput;

        private Vector3 _moveDirection;
        private Rigidbody _rigidbody;

        private bool _grounded, _running, _canMove = true;

        public bool CanMove
        {
            get => _canMove;
            set => _canMove = value;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.freezeRotation = true;
        }

        private void Update()
        {
            _grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * .5f + .2f, groundLayer);

            SpeedControl();
                
            if (_grounded)
                _rigidbody.linearDamping = groundDrag;
            else
                _rigidbody.linearDamping = 0;
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            if (!_canMove) return;
            _moveDirection = orientation.forward * _verticalInput + orientation.right * _horizontalInput;
            var speed = _running ? runSpeed : moveSpeed;
            _rigidbody.AddForce(_moveDirection.normalized * (speed * 20f), ForceMode.Force);
        }

        private void SpeedControl()
        {
            
            Vector3 flatVelocity = new Vector3(_rigidbody.linearVelocity.x, 0, _rigidbody.linearVelocity.z);
            
            var speed = _running ? runSpeed : moveSpeed;

            if (flatVelocity.magnitude > speed)
            {
                Vector3 limitedVelocity = flatVelocity.normalized * speed;
                _rigidbody.linearVelocity = new Vector3(limitedVelocity.x, _rigidbody.linearVelocity.y, limitedVelocity.z);
            }
        }

        public void SetMouseInput(Vector2 lookVector)
        {
            _horizontalInput = lookVector.x;
            _verticalInput = lookVector.y;
        }

        public void Run(bool isRunning)
        {
            _running = isRunning;
        }

        public void UseGravity(bool toggle)
        {
            playerRigidbody.useGravity = toggle;
        }
    }
}