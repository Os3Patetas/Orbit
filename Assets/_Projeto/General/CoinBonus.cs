using UnityEngine;

namespace com.Icypeak.Orbit.General
{
    public enum CoinBonusType
    {
        None = 0,
        OneQuarter = 25,
        TwoQuarter = 50,
        ThreeQuarter = 75,
        Double = 100
    }

    [System.Serializable]
    public class CoinBonus
    {
        public CoinBonusType type = CoinBonusType.None;
        public int remainingUsages = 0;

        public void UseBonus()
        {
            remainingUsages--;
            if(remainingUsages <= 0)
            {
                type = CoinBonusType.None;
            }
        }

        public void ActivateBonus(CoinBonusType bonusType, int usages)
        {
            type = bonusType;
            remainingUsages = usages;
        }
    }
}
