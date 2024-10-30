using General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class TimeScaleManager : MonoBehaviour
    {
        private void OnEnable()
        {
            GeneralObserver.OnTimeScaleChanged += ChangeTimeScale;
        }

        private void OnDisable()
        {
            GeneralObserver.OnTimeScaleChanged -= ChangeTimeScale;
        }

        private void ChangeTimeScale(int scale)
        {
            Time.timeScale = scale;
        }
    }
}
