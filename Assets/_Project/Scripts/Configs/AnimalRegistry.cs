using System;
using System.Collections.Generic;
using _Project.Scripts.Entities;
using UnityEngine;

namespace _Project.Scripts.Configs
{
    
    [CreateAssetMenu(fileName = "AnimalRegistry", menuName = "Configs/AnimalRegistry", order = 0)]
    public class AnimalRegistry : ScriptableObject
    {
        
        [SerializeField] private List<Animal> _animals;
        private Dictionary<Type, Animal> _animalsDict = new();
        
        
        public bool TryGetAnimal(Type type, out Animal animal)
        {
            return _animalsDict.TryGetValue(type, out animal);
        }

        private void OnValidate()
        {
            foreach (var animal in _animals)
            {
                _animalsDict.Add(animal.GetType(), animal);
            }
            
            Debug.Log("Animals registry initialized with " + _animalsDict.Count + " animals");
        }

        public IEnumerable<Type> GetAllTypes()
        {
            return _animalsDict.Keys;
        }
    }
    
}