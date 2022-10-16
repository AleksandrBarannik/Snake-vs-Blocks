
using UnityEngine;

namespace Bonus
{ //Отвечает за уменьшающий бонус
    public class SubtractBonus : BaseBonus
    {
        public override int Collect()
        {
            _currentBonusSize += _targetBonusSize;
            OnFillUpdate.Invoke();
            CheckBonusStatus();
            return _targetBonusSize;
        }
    }
}