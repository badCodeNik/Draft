using _Project.Scripts.AnimalsConfigs;
using _Project.Scripts.Entities.Interfaces;
using _Project.Scripts.Services;
using UnityEngine;

namespace _Project.Scripts.Entities
{
    public abstract class Animal : MonoBehaviour,IAnimal
    {
        [SerializeField] private AnimalData _animalData;
        private CollisionMediator _collisionMediator;
        public virtual void Init(CollisionMediator collisionMediator)
        {
            _collisionMediator = collisionMediator;
        }
        public int InstanceID => gameObject.GetInstanceID();
        public AnimalData AnimalData => _animalData;

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.TryGetComponent<Animal>(out _)) return;
            var other = collision.gameObject.GetComponent<IAnimal>();
            if(InstanceID > other.InstanceID)  _collisionMediator.HandleCollision(this, other);
        }
    }
}