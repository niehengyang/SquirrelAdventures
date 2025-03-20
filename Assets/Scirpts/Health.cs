using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static Health Instance;
    public Slider HP;
    public float hp;
    private void Awake()
    {
        Instance = this;
    }

    public void UpdateGemTotal()
    {
        HP.value = hp;
    }
}
