using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public static GameScore Instance;
    public TextMeshProUGUI gemText;
    public int gemCount;
    private void Awake()
    {
        gemCount = 0;
        Instance = this;
    }

    public void UpdateGemTotal()
    {
        gemText.text = gemCount.ToString();
    }

}
