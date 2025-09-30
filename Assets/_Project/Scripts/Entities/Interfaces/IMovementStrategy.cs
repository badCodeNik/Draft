using UnityEngine;

namespace _Project.Scripts.Entities.Interfaces
{
    public interface IMovementStrategy
    {
        void Move(Transform transform, ref Vector3 direction, float deltaTime);
        void TurnAround(Transform transform, ref Vector3 direction);
    }
}