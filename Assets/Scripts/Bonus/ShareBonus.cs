using UnityEngine;
using AllForSnake;

namespace Bonus
{
    public class ShareBonus : BaseBonus
    {
        public override int Collect()
        {
            
            _targetBonusSize = Snake.Instance.Tail.Count - Snake.Instance.Tail.Count / _targetBonusSize;
            _currentBonusSize = LeftToFill;
            CheckBonusStatus();
            return _targetBonusSize;
        }
    }
}
