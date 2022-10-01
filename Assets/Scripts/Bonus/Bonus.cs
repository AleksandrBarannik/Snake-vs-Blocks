using TMPro;
using UnityEngine;
using Snake;
namespace Bonus
{
    public enum BonusType
    {
        Add,
        Multiply,
        Subtract,
        Share
    };

    
    public class Bonus : MonoBehaviour
    {
        public BonusType bonusType;
        
        [SerializeField]
        private Snake.Snake _snake;
        
        [SerializeField] 
        private TMP_Text _view;

        [SerializeField] 
        private Vector2Int _bonusSizeRange;

        private int _bonusSize;
       
        private void Start()
        {
            _bonusSize = Random.Range(_bonusSizeRange.x, _bonusSizeRange.y);
            _view.text = _bonusSize.ToString();
        }

        public int Collect()
        {
            switch (bonusType)
            {
                case BonusType.Add:
                    
                    break ;
                
                case BonusType.Multiply:
                    _bonusSize = (_bonusSize * _snake.Tail.Count) - _snake.Tail.Count;
                    break ;
                
                case BonusType.Subtract:

                    //Вычитание с хвоста

                    break ;
                
                case BonusType.Share:
                    
                    _bonusSize = _snake.Tail.Count / _bonusSize ;
                    
                    //вызов удаления с хвоста
                    
                    break ;
            }
            
            Destroy((gameObject));
            return _bonusSize;
            
            
        }
        
       
    }
}
