using System;
using Unity.MARS.Providers;
using Unity.MARS.Settings;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS
{
    public class MarsCameraSetting : MonoBehaviour, IUsesFunctionalityInjection, IUsesSessionControl
    {
        IProvidesFunctionalityInjection IFunctionalitySubscriber<IProvidesFunctionalityInjection>.provider { get; set; }
        IProvidesSessionControl IFunctionalitySubscriber<IProvidesSessionControl>.provider { get; set; }

        void Awake()
        {
            // Only necessary if this script isn't already in the scene when you press Play
            this.EnsureFunctionalityInjected();
        }

        public void TogglePaused()
        {
            var marsCore = MARSCore.instance;
            var wasPaused = marsCore.paused;
            marsCore.paused = !wasPaused;
            if (wasPaused)
            {
                this.ResumeSession();
            }
            else
            {
                this.PauseSession();
            }
        }
    }
}