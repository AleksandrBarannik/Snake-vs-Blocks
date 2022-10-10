using UnityEngine;
using AllForSnake;

namespace Bonus
{ //Умножающий бонус
    public class MultiplyBonus:BaseBonus
    {
        public override int Collect()
        {
            _targetBonusSize = (_targetBonusSize * Snake.Instance.Tail.Count) - Snake.Instance.Tail.Count;
            _currentBonusSize = LeftToFill;
            CheckBonusStatus();
            return _currentBonusSize;
        }
        
    }
}