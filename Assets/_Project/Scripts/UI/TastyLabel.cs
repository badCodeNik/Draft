using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class TastyLabel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private Coroutine _hideCoroutine;

        public void Show(float duration, Action onComplete)
        {
            gameObject.SetActive(true);

            if (_hideCoroutine != null)
                StopCoroutine(_hideCoroutine);

            _hideCoroutine = StartCoroutine(HideAfterDelay(duration, onComplete));
        }

        private IEnumerator HideAfterDelay(float delay, Action onComplete)
        {
            yield return new WaitForSeconds(delay);
            gameObject.SetActive(false);
            onComplete?.Invoke();
        }
    }
}