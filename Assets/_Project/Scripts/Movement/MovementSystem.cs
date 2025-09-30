using System.Collections.Generic;
using _Project.Scripts.Entities.Interfaces;
using _Project.Scripts.Services;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Movement
{
    public class MovementSystem : ITickable
    {
        private readonly ILevelBoundsProvider _levelBoundsProvider;
        private List<IMovable> _movables = new();

        public MovementSystem(ILevelBoundsProvider levelBoundsProvider)
        {
            _levelBoundsProvider = levelBoundsProvider;
        }

        public void Register(IMovable movable)
        {
            if (_movables.Contains(movable)) return;
            _movables.Add(movable);
        }

        public void Unregister(IMovable movable)
        {
            _movables.Remove(movable);
        }
        

        public void Tick()
        {
            foreach (var movable in _movables)
            {
                var dir = movable.Direction;
                movable.MovementStrategy.Move(movable.Transform, ref dir, Time.deltaTime);
                movable.Direction = dir;
            
                if (!_levelBoundsProvider.IsWithinBounds(movable.Position))
                {
                    var newDir = movable.Direction;
                    movable.MovementStrategy.TurnAround(movable.Transform, ref newDir);
                    movable.Direction = newDir;
                }
            }
        }
    }
}