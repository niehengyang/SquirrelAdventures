using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    public class TGameManager : MMPersistentSingleton<TGameManager>
    {
        public int TargetFrameRate = 300;

        [Header("Lives")]
        public int MaximumLives = 0;

        public int CurrentLives = 0;
    }
}

