using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    public class TBackgroundMusic : MMPersistentHumbleSingleton<TBackgroundMusic>
    {
        public AudioSource _source;


        protected virtual void Start()
        {
            Debug.Log("TBackgroundMusic---Start");
            _source.Play();
        }
    }
}


