using System;
using System.Linq;
using model;
using UnityEditorInternal;
using UnityEngine;

namespace ui
{
    public class DirectionChoicePanel : MonoBehaviour
    {
        private Action<Direction> _callback;

        public void Show(Action<Direction> callback)
        {
            gameObject.SetActive(true);
            _callback = callback;
        }

        public void ReportChoice(Direction direction)
        {
            _callback.Invoke(direction);
            Hide();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            GetComponentsInChildren<DirectionChoice>().ToList().ForEach(c => c.LowLight());
        }
    }
}