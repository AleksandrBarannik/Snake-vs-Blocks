using System;
using Blocks;
using UnityEngine;
using UnityEngine.Events;

namespace Snake
{// Отвечает за взаимодействие головы с блоками, бонусами , ожидая слушателя событий
    [RequireComponent(typeof(Rigidbody2D))]
    public class SnakeHead : MonoBehaviour
    {
        private Rigidbody2D _rigitBody2d;

        public event UnityAction BlockColided;
        public event UnityAction <int> BonusCollected;

        private void Start()
        {
            _rigitBody2d = GetComponent<Rigidbody2D>();
        }

        public void Move( Vector3 newPosition)
        {
            _rigitBody2d.MovePosition(newPosition);
        }

        public void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Block block))
            {
                BlockColided?.Invoke();
                block.Fill();
            }
               
                
        }
        
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Bonus.Bonus bonus))
            {
                BonusCollected?.Invoke(bonus.Collect());
                
            }
               
                
        }
    }
}
