using UnityEngine;

namespace _Project.Scripts.UI
{
    public interface IUIService
    {
        void ShowTastyLabel(Vector3 worldPosition);
        void IncrementDeadPreyCount();
        void IncrementPredatorsCount();
        void DecrementPredatorsCount();
    }
}