using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;


namespace Blocks
{  //Отвечает за наполнение блока  и уничтожение его (когда он наполнится на его цену)
    public class Block : MonoBehaviour
    {
        [SerializeField]
        private Vector2Int _destroyPriceRange;

        private int _destroyPrice;
        private int _filling;

        public int LefttoFill => _destroyPrice - _filling;

        public event UnityAction <int> FillingUpdated;

        private void Start()
        {
            _destroyPrice = Random.Range(_destroyPriceRange.x, _destroyPriceRange.y);
            FillingUpdated?.Invoke(LefttoFill);
        }

        public void Fill()
        {
            _filling++;
            FillingUpdated?.Invoke(LefttoFill);
            DestroyBlock();
        }


        public void DestroyBlock()
        {
            if (_filling == _destroyPrice)
                Destroy(gameObject);
        }







    }
}
