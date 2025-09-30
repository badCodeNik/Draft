using UnityEngine;

namespace _Project.Scripts.Services
{
    public interface ILevelBoundsProvider
    {
        Bounds GetFloorBounds();
        bool IsWithinBounds(Vector3 position);
        Vector3 GetRandomPositionOnFloor();
    }
}