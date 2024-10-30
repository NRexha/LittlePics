using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace General
{
    public class GeneralObserver : MonoBehaviour
    {
        private void OnEnable()
        {
            InputMenus.OnTimeChanged += NotifyTimeScaleListeners;
        }


        private void OnDisable()
        {
            InputMenus.OnTimeChanged -= NotifyTimeScaleListeners;
        }
        public static event Action<int> OnTimeScaleChanged;

        private void NotifyTimeScaleListeners(int scale)
        {
            OnTimeScaleChanged?.Invoke(scale);
        }
    }


}
