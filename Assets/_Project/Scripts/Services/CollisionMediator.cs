using _Project.Scripts.Entities;
using _Project.Scripts.Entities.Interfaces;
using _Project.Scripts.UI;

namespace _Project.Scripts.Services
{
    public class CollisionMediator
    {
        private readonly RngService _rngService;
        private readonly IUIService _uiService;

        public CollisionMediator(RngService rngService, IUIService uiService)
        {
            _rngService = rngService;
            _uiService = uiService;
        }

        public void HandleCollision(IAnimal a, IAnimal b)
        {
            switch (a)
            {
                case Predator predator when b is Prey prey:
                    predator.Eat(prey);
                    _uiService.ShowTastyLabel(predator.transform.position);
                    break;
                case Prey prey when b is Predator predator:
                    predator.Eat(prey);
                    _uiService.ShowTastyLabel(predator.transform.position);
                    break;
                case Predator p1 when b is Predator p2:
                    var firstRoll = _rngService.Roll();
                    var secondRoll = _rngService.Roll();
                    if (firstRoll > secondRoll)
                    {
                        p1.Eat(p2);
                        _uiService.ShowTastyLabel(p1.transform.position);
                    }
                    else
                    {
                        p2.Eat(p1);
                        _uiService.ShowTastyLabel(p2.transform.position);
                    }
                    
                    break;

                case Prey when b is Prey:
                    
                    break;
            }
        }
    }
}