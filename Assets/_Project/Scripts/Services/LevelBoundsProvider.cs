using UnityEngine;
using Zenject;

namespace _Project.Scripts.Services
{
    public class LevelBoundsProvider : MonoBehaviour, ILevelBoundsProvider
    {
        [SerializeField] private GameObject _floor;
        private RngService _rngService;
        private Bounds _bounds;

        [Inject]
        public void Construct(RngService rngService)
        {
            _rngService = rngService;
        }

        public Bounds GetFloorBounds()
        {
            _bounds = _floor.GetComponent<Renderer>().bounds;
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
            return new Vector3(x, _bounds.min.y, z);
        }
    }
}