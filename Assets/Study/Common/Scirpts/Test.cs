using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public string NextLevel;

    public virtual void Test1()
    {
        TGUIManager.Instance.TestSigletonFun();
    }

    public virtual void JumpToNextLevel()
    {
        SceneManager.LoadScene(NextLevel);
    }

    public virtual void TestTriggerGameOver()
    {
        Debug.Log("Test---TestTriggerGameOver");
        MMGameEvent.Trigger("GameOver");
    }
}
