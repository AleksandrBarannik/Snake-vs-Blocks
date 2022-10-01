using TMPro;
using UnityEngine;

namespace Snake
{
    public class SnakeSizeView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _viewText;

        private Snake _snake;

        private void Awake()
        {
            _snake = GetComponent<Snake>();
        }
        
        private void OnEnable()
        {
            _snake.SizeTailUpdated += onTailUpdated ;
        }

        private void OnDisable()
        {
            _snake.SizeTailUpdated -= onTailUpdated ;
        }

        private void onTailUpdated(int sizeToTail)
        {
            _viewText.text = sizeToTail.ToString();
        }


    }
}
