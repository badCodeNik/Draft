using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class UIService : MonoBehaviour, IUIService
    {
        [SerializeField] private GameObject _tastyLabelPrefab;
        [SerializeField] private TMP_Text _deadPreyCountText;
        [SerializeField] private TMP_Text _predatorsCountText;
        private readonly Queue<TastyLabel> _labelPool = new(10);
        private int _deadPreyCount;
        private int _predatorsCount;

        //usually I would use MVP here, but I don't want to overcomplicate this example
        private void Awake()
        {
            for (var i = 0; i < 10; i++)
            {
                var label = Instantiate(_tastyLabelPrefab, transform).GetComponent<TastyLabel>();
                label.gameObject.SetActive(false);
                _labelPool.Enqueue(label);
            }
        }

        public void ShowTastyLabel(Vector3 worldPosition)
        {
            var label = _labelPool.Dequeue();
            label.gameObject.SetActive(true);

            worldPosition.y += 1f;
            label.transform.position = worldPosition;

            label.Show(1.5f, () => ReturnLabel(label));
        }

        private void ReturnLabel(TastyLabel label)
        {
            label.gameObject.SetActive(false);
            _labelPool.Enqueue(label);
        }

        public void IncrementDeadPreyCount()
        {
            _deadPreyCount++;
            _deadPreyCountText.text = $"Preys killed : {_deadPreyCount.ToString()}";
        }

        public void IncrementPredatorsCount()
        {
            _predatorsCount++;
            SetPredatorsAlive(_predatorsCount.ToString());
        }

        private void SetPredatorsAlive(string text)
        {
            _predatorsCountText.text = $"Predators alive : {text}";
        }

        public void DecrementPredatorsCount()
        {
            _predatorsCount--;
            SetPredatorsAlive(_predatorsCount.ToString());
        }
    }
}