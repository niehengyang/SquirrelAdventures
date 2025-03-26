using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    public class TGUIManager : MMSingleton<TGUIManager>
    {
        public virtual void TestSigletonFun()
        {
            Debug.Log("TGUIManager---TestSigletonFun");
        }
    }

}
