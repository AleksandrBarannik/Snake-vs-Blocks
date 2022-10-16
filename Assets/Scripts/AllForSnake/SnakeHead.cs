using System;
using Blocks;
using Bonus;
using UnityEngine;
using UnityEngine.Events;

namespace AllForSnake
{
    // Отвечает за взаимодействие головы с блоками, бонусами , ожидая слушателя событий
    [RequireComponent(typeof(Rigidbody2D))]
    public class SnakeHead : MonoBehaviour
    {
        public static SnakeHead Instance;
        private Rigidbody2D _rigitBody2d;

        public event UnityAction <int> DecreaseBonusCollected;
        public event UnityAction <int> BlockCollided;
        public event UnityAction <int> IncreaseBonusCollected;


        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

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
                BlockCollided?.Invoke(1);
                block.Fill();
            }

        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out AddBonus bonusAdd))
            {
                IncreaseBonusCollected?.Invoke(bonusAdd.Collect());
            }
            
            if (collision.TryGetComponent(out MultiplyBonus bonusMultiply))
            {
                IncreaseBonusCollected?.Invoke(bonusMultiply.Collect());
            }
            if (collision.gameObject.TryGetComponent(out SubtractBonus bonusSubstract))
            {
                DecreaseBonusCollected?.Invoke(bonusSubstract.Collect());
            }
            
            if (collision.gameObject.TryGetComponent(out ShareBonus bonusShare))
            {
                DecreaseBonusCollected?.Invoke(bonusShare.Collect());
            }    
                
        }
    }
}
