using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    public class EGUIManager : MMSingleton<EGUIManager>, MMEventListener<MMGameEvent>
    {
        public virtual void TestSigletonFun()
        {
            Debug.Log("EGUIManager---TestSigletonFun");
        }


        public void OnMMEvent(MMGameEvent eventType)
        {
            Debug.Log("EGUIManager---OnMMEvent");
            if (eventType.EventName == "GameOver")
            {
                Debug.Log("EGUIManager do Somthing");
            }
        }

        protected virtual void OnEnable()
        {
            Debug.Log("EGUIManager---OnEnable");
            this.MMEventStartListening<MMGameEvent>();
        }

        protected virtual void OnDisable()
        {
            Debug.Log("EGUIManager---OnDisable");
            this.MMEventStopListening<MMGameEvent>();
        }
    }

}