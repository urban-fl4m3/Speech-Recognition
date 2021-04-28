using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UI : MonoBehaviour
    {
        public static UI Instance => _instance;
        private static UI _instance;
        
        [SerializeField] private Text _accuracy;

        private float _completes;
        private float _failes;

        private void Awake()
        {
            _instance = this;
        }

        public void AddComplete()
        {
            _completes++;
        }

        public void AddFail()
        {
            _failes++;
        }

        private void UpdateText()
        {
            Debug.Log($"{_completes/(_failes + _completes)}%");
            _accuracy.text = $"Accuracy: {_completes/(_failes + _completes)}";

            if (_failes + _completes >= 1000)
            {
                _failes = 0;
                _completes = 0;
            }
        }
        

        private float tick;
        private void Update()
        {
            tick += Time.deltaTime;

            if (tick >= .1f)
            {
                UpdateText();
            }
        }
    }
}