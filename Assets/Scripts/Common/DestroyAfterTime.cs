using System;
using UnityEngine;

namespace Common
{
    public class DestroyAfterTime : MonoBehaviour
    {
        [SerializeField] private float timeToDestroy = 10;

        private void Start()
        {
            StartCoroutine(Utils.MakeActionDelay(delegate { Destroy(gameObject); }, timeToDestroy));
        }
    }
}
