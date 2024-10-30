using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace General
{
    //to modify in the future, just used for debug
    public class GeneralObserver : MonoBehaviour
    {
        private void OnEnable()
        {
            PauseMenu.OnTimeChanged += NotifyTimeScaleListeners;
        }


        private void OnDisable()
        {
            PauseMenu.OnTimeChanged -= NotifyTimeScaleListeners;
        }
        public static event Action<int> OnTimeScaleChanged;

        private void NotifyTimeScaleListeners(int scale)
        {
            OnTimeScaleChanged?.Invoke(scale);
        }
    }


}
