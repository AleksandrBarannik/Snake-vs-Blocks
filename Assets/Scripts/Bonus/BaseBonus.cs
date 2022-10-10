using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using AllForSnake;
using Random = UnityEngine.Random;

namespace Bonus
{
    public abstract class BaseBonus : MonoBehaviour
    {
        [SerializeField] protected Vector2Int bonusSizeRange;
        
        public int LeftToFill => _targetBonusSize - _currentBonusSize;

        
        protected int _targetBonusSize;
        protected int _increaseStep = 1;
        protected int _currentBonusSize;
        
        public Action OnFillUpdate = () => {};
       
        private void Start()
        {
            _targetBonusSize = Random.Range(bonusSizeRange.x, bonusSizeRange.y);
            OnFillUpdate.Invoke();
        }
        
        public abstract int Collect();
        
        protected void CheckBonusStatus()
        {
            if (_currentBonusSize < _targetBonusSize) return;
            
            Destroy(gameObject);
        }

    }
}