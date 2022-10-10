
using UnityEngine;

namespace Bonus
{ //Отвечает за уменьшающий бонус
    public class SubtractBonus : BaseBonus
    {
        public override int Collect()
        {
            _currentBonusSize += _increaseStep;
            OnFillUpdate.Invoke();
            CheckBonusStatus();
            return _increaseStep;
        }
    }
}