using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    public class EGameManager : MMSingleton<EGameManager>, MMEventListener<MMGameEvent>
    {
        public void OnMMEvent(MMGameEvent eventType)
        {
            Debug.Log("EGameManager---OnMMEvent");
            if (eventType.EventName == "GameOver")
            {
                Debug.Log("EGameManager do Somthing");
            }

        }


        protected virtual void OnEnable()
        {
            Debug.Log("EGameManager---OnEnable");
            this.MMEventStartListening<MMGameEvent>();
        }

        protected virtual void OnDisable()
        {
            Debug.Log("EGameManager---OnDisable");
            this.MMEventStopListening<MMGameEvent>();
        }
    }

}
