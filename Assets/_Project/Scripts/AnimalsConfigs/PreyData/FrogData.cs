using UnityEngine;

namespace _Project.Scripts.AnimalsConfigs.PreyData
{
    [CreateAssetMenu(fileName = "FrogData", menuName = "AnimalData/PreyData/FrogData", order = 0)]
    public class FrogData : AnimalsConfigs.AnimalData
    {
        public float JumpForce;
        public float JumpInterval;
    }
}