using System;

using UnityEngine;

namespace com.Icypeak.Orbit
{
    public static class PlayerCurrency
    {
        static int coins = 3000;
        public static int Coins
        {
            get => coins;
            set
            {
                coins = value;
                OnCoinChange?.Invoke();
            }
        }

        public static Action OnCoinChange;
    }
}
