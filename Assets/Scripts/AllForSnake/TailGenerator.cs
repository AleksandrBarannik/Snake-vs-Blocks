using System.Collections.Generic;
using UnityEngine;

namespace AllForSnake
{// Отвечает за генерацию хвоста змеи (получает значение от класса Snake
   public class TailGenerator : MonoBehaviour
   {
	   
      [SerializeField] private Segment _segmentTamplate;
      public List<Segment> Generate(int tailSize)
      {
         List<Segment> tail = new List<Segment>();
         for (int i = 0; i < tailSize; i++)
         {
            tail.Add(Instantiate(_segmentTamplate,transform));
         }
         return tail;
      }
   }
}
