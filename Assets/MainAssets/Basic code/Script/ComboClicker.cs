using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class ComboTarget
{
    public GameObject target; // 按下键时要点击的物体
}

public class ComboClicker : MonoBehaviour
{
    [Tooltip("数字键之间的最大间隔（秒）")]
    public float comboTimeout = 0f;

    [Tooltip("第 N 个元素对应数字 N+1")]
    public List<ComboTarget> targets = new List<ComboTarget>();

    private readonly HashSet<KeyCode> _pressed = new HashSet<KeyCode>(); // 当前按住的数字键
    private string _buffer = "";
    private Coroutine _timer;

    void Update()
    {
        // 检测按下键
        for (KeyCode k = KeyCode.Alpha0; k <= KeyCode.Alpha9; k++)
        {
            if (Input.GetKeyDown(k))
            {
                _pressed.Add(k);
                _buffer += (k - KeyCode.Alpha0).ToString();
            }
        }

        // 检测键松开
        bool anyReleased = false;
        for (KeyCode k = KeyCode.Alpha0; k <= KeyCode.Alpha9; k++)
        {
            if (Input.GetKeyUp(k) && _pressed.Remove(k))
                anyReleased = true;
        }

        // 所有数字键全都松开时重启计时器
        if (anyReleased && _pressed.Count == 0)
        {
            RestartTimer();
        }

        if (_pressed.Count > 0 && _timer != null)
        {
            StopCoroutine(_timer);
            _timer = null;
        }
    }

    private void RestartTimer()
    {
        if (_timer != null) StopCoroutine(_timer);
        _timer = StartCoroutine(Timeout());
    }

    private IEnumerator Timeout()
    {
        yield return new WaitForSecondsRealtime(comboTimeout);

        if (int.TryParse(_buffer, out int number) && number > 0)
        {
            int index = number - 1;
            if (index >= 0 && index < targets.Count)
            {
                var entry = targets[index];
                if (entry.target != null)
                    ExecuteEvents.Execute(entry.target,
                        new PointerEventData(EventSystem.current),
                        ExecuteEvents.pointerClickHandler);

                Debug.Log($"[ComboClick] 数字 {number} → {entry.target?.name}");
            }
            else
            {
                Debug.Log($"[ComboClick] 数字 {number} 无对应物体");
            }
        }
        _buffer = "";
    }
}