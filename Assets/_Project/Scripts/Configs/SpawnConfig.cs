using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "SpawnConfig", menuName = "Configs/SpawnConfig")]
    public class SpawnConfig : ScriptableObject
    {
        [Range(0,2)]public float SpawnInterval;
        public float PreySpawnChance;
        public float PredatorSpawnChance;
    }
}