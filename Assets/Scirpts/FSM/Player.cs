using System.Collections;
using UnityEngine;
public class Player : FSM
{
    public static Player Instance;
    private void Awake()
    {
        Instance = this;
    }

    protected override void Start()
    {
        Health.Instance.HP.value = 1.0f;
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    /// <summary>
    ///  ‹…À
    /// </summary>
    /// <param name="value"></param>
    public override void IsHurted(int value)
    {
        base.IsHurted(value);
        Health.Instance.HP.value = parameter.hp/parameter.maxHP;
    }

    /// <summary>
    /// ≤»π÷
    /// </summary>
    /// <param name="enemy"></param>
    public override void StampEemy(GameObject enemy)
    {
        base.StampEemy(enemy);
    }
}
