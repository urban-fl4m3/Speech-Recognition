using System;
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
            _accuracy.text = $"Accuracy: {_completes/(_failes + _completes)}";
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