using UnityEngine;
using Zenject;

namespace _Project.Scripts.Services
{
    public class LevelBoundsProvider : MonoBehaviour, ILevelBoundsProvider
    {
        [SerializeField] private GameObject _floor;
        [SerializeField] private Collider _collider;
        private RngService _rngService;
        private Bounds _bounds;

        [Inject]
        public void Construct(RngService rngService)
        {
            _rngService = rngService;
            _bounds = _collider.bounds;
        }

        public Bounds GetFloorBounds()
        {
            return _bounds;
        }

        public bool IsWithinBounds(Vector3 position)
        {
            return _bounds.Contains(position);
        }

        public Vector3 GetRandomPositionOnFloor()
        {
            var x = _rngService.GetRandomFloat(_bounds.min.x, _bounds.max.x);
            var z = _rngService.GetRandomFloat(_bounds.min.z, _bounds.max.z);
            return new Vector3(x, _bounds.max.y, z);
        }
    }
}