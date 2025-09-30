using _Project.Scripts.Entities.Interfaces;
using UnityEngine;

namespace _Project.Scripts.Movement
{
    public class JumpMovementStrategy : IMovementStrategy
    {
        private readonly float _jumpDistance;
        private readonly float _jumpInterval;
        private float _nextJumpTime;
        private readonly Rigidbody _rigidbody;

        public JumpMovementStrategy(float jumpDistance, float jumpInterval, Rigidbody component)
        {
            _jumpDistance = jumpDistance;
            _jumpInterval = jumpInterval;
            _rigidbody = component;
        }

        public void Move(Transform transform, ref Vector3 direction, float deltaTime)
        {
            if (Time.time >= _nextJumpTime)
            {
                Vector3 jumpForce = transform.forward * _jumpDistance;
                _rigidbody.AddForce(jumpForce + Vector3.up, ForceMode.Impulse);
                _nextJumpTime = Time.time + _jumpInterval;
            }
        }

        public void TurnAround(Transform transform, ref Vector3 direction)
        {
            transform.forward *= -1f;
        }
    }
}