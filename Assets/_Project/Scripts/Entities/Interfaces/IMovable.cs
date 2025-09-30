using UnityEngine;

namespace _Project.Scripts.Entities.Interfaces
{
    public interface IMovable
    {
        Transform Transform { get; }
        Vector3 Direction { get; set; }
        Vector3 Position { get; }
        IMovementStrategy MovementStrategy { get; }
    }
}