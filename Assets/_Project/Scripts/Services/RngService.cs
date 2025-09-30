using UnityEngine;

namespace _Project.Scripts.Services
{
    public class RngService
    {
        public float Roll()
        {
            return Random.value;
        }
        
        public float GetRandomFloat(float min, float max)
        {
            return Random.Range(min, max);
        }
    }
}