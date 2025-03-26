using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    public class TestFader : MMSingleton<TestFader>, MMEventListener<MMGameEvent>
    {

        public MMTweenType TestFaderTween;
        public int FadeId;
        public bool FadeIgnoreTimeScale = true;
        public float FadeDuration = 2f;
        [MMInspectorButton("TriggerFadeOut")]
        public bool TriggerFadeOutButton;
        [MMInspectorButton("TriggerFadeIn")]
        public bool TriggerFadeInButton;


        protected virtual void TriggerFadeOut()
        {
            MMFadeOutEvent.Trigger(FadeDuration, TestFaderTween, FadeId, FadeIgnoreTimeScale); 
        }

        protected virtual void TriggerFadeIn()
        {
            MMFadeInEvent.Trigger(FadeDuration, TestFaderTween, FadeId, FadeIgnoreTimeScale);
        }

        public void OnMMEvent(MMGameEvent eventType)
        {
            Debug.Log("TestFader---OnMMEvent");
            if (eventType.EventName == "GameOver")
            {
                Debug.Log("TestFader do Somthing");
            }

        }


        protected virtual void OnEnable()
        {
            Debug.Log("TestFader---OnEnable");
            this.MMEventStartListening<MMGameEvent>();
        }

        protected virtual void OnDisable()
        {
            Debug.Log("TestFader---OnDisable");
            this.MMEventStopListening<MMGameEvent>();
        }
    }
}

