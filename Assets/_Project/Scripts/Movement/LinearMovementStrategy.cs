using _Project.Scripts.Entities.Interfaces;
using UnityEngine;

namespace _Project.Scripts.Movement
{
    public class LinearMovementStrategy : IMovementStrategy
    {
        private readonly float _speed;
    
        public LinearMovementStrategy(float speed)
        {
            _speed = speed;
        }
    
        public void Move(Transform transform, ref Vector3 direction, float deltaTime)
        {
            transform.position += transform.forward * _speed * deltaTime;
        }
    
        public void TurnAround(Transform transform, ref Vector3 direction)
        {
            direction = Quaternion.Euler(0, 180, 0) * transform.forward;
            transform.rotation = Quaternion.Euler(0, 180, 0) * transform.rotation;
        }
    }
}