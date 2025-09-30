using _Project.Scripts.AnimalsConfigs.PreyData;
using _Project.Scripts.Entities.Interfaces;
using _Project.Scripts.Movement;
using _Project.Scripts.Services;
using UnityEngine;

namespace _Project.Scripts.Entities.Animals
{
    [RequireComponent(typeof(Rigidbody))]
    public class Frog : Prey, IMovable
    {
        private FrogData _frogData;
        public override void Init(CollisionMediator collisionMediator)
        {
            base.Init(collisionMediator);
            _frogData = AnimalData as FrogData;
            MovementStrategy = new JumpMovementStrategy(_frogData.JumpForce, _frogData.JumpInterval, GetComponent<Rigidbody>());
        }


        public Vector3 Position => transform.position;
        public IMovementStrategy MovementStrategy { get; private set; }
        public Transform Transform => transform;
        public Vector3 Direction { get; set; } = Vector3.forward;
        
        public override void JumpAway()
        {
            
        }
    }
}