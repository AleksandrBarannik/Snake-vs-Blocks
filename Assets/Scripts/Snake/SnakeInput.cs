using UnityEngine;

namespace Snake
{
    public class SnakeInput : MonoBehaviour
    {//Для контроля направления движения мыши (за ней следует голова звеи)
        private Camera _camera;

        public void Start()
        {
            _camera = Camera.main;
        }
        public Vector2 GetDirectionToCLick(Vector2 headPosition)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = _camera.ScreenToViewportPoint(mousePosition);
            mousePosition.y = 1;
            mousePosition = _camera.ViewportToWorldPoint(mousePosition);
            Vector2 direction = new Vector2(mousePosition.x - headPosition.x, mousePosition.y - headPosition.y);

            return direction;
        }
    }
}
