using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AllForSnake
{
   [RequireComponent(typeof(TailGenerator))]
   [RequireComponent(typeof(SnakeInput))]
   public class Snake : MonoBehaviour
   {
      public static Snake Instance;
      
      [SerializeField]
      private SnakeHead _head;
   
      [SerializeField]
      private float _speed;
   
      [SerializeField]
      private float _tailSpringiness;
      
      [SerializeField]
      private int _tailSize;
      
      

      private SnakeInput _snakeInput;
      public List<Segment> Tail { get; private set; }

      private TailGenerator _tailGenerator;
      
      
      public event UnityAction <int> SizeTailUpdated;
   

      private void Awake()
      {
         Instance = this;
         
         _snakeInput = GetComponent<SnakeInput>();
         _tailGenerator = GetComponent<TailGenerator>();
      
         Tail = _tailGenerator.Generate(_tailSize);
         SizeTailUpdated?.Invoke(Tail.Count);
     
      }

      private void Start()
      {
         SizeTailUpdated?.Invoke(Tail.Count);
      }

      private void OnEnable()
      {
         _head.DecreaseBonusCollected += OnDeleteSegmetTail;
         _head.IncreaseBonusCollected += OnConnectSegmentToTail;
         _head.BlockCollided += OnDeleteSegmetTail;
      }

      private void OnDisable()
      {
         _head.DecreaseBonusCollected -= OnDeleteSegmetTail;
         _head.IncreaseBonusCollected -= OnConnectSegmentToTail;
         _head.BlockCollided -= OnDeleteSegmetTail;
      }

      private void FixedUpdate()
      {
         MoveTail(_head.transform.position + _head.transform.up * _speed * Time.fixedDeltaTime);
         _head.transform.up = _snakeInput.GetDirectionToCLick(_head.transform.position);
      }

      private void MoveTail( Vector3 nextPosition)
      {
         Vector3 previousPosition = _head.transform.position;
      
         foreach (var segment in Tail)
         {
            Vector3 tempPosition =  segment.transform.position;
            segment.transform.position = Vector2.Lerp( segment.transform.position, previousPosition,
               _tailSpringiness * Time.deltaTime);
            previousPosition = tempPosition;
         }
         _head.Move(nextPosition);
      }

      public void OnDeleteSegmetTail(int count = 1)
      {
         for (int i = 0; i < count; i++)
         {
            Segment deletedSegment = Tail[Tail.Count - 1];
            Tail.Remove(deletedSegment);
            Destroy(deletedSegment.gameObject);
            SizeTailUpdated?.Invoke(Tail.Count);
         }
      }

      private void OnConnectSegmentToTail(int bonusSize)
      {
         Tail.AddRange(_tailGenerator.Generate(bonusSize));
         SizeTailUpdated?.Invoke(Tail.Count);
      }
      
      
      
   }
}
