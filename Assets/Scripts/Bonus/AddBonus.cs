using TMPro;

namespace Bonus
{//Отвечает за увеличивающий бонус
    public class AddBonus : BaseBonus
    {
        
        public override int Collect()
        {
            _currentBonusSize = LeftToFill;
            CheckBonusStatus();
            return _currentBonusSize;
        }
        
        
    }
}