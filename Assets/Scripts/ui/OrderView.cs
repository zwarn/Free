using model;
using UnityEngine;
using UnityEngine.UI;

namespace ui
{
    public class OrderView : MonoBehaviour
    {
        public static OrderView CreateOrderView(Order order, Hero hero, Transform parent)
        {
            var gameObject = (GameObject) Instantiate(Resources.Load("Order"), parent);
            OrderView orderView = gameObject.GetComponent<OrderView>();
            orderView.SyncWithModel(order, hero);
            return orderView;
        }

        private void SyncWithModel(Order order, Hero hero)
        {
            var skillView = GetComponentInChildren<SkillView>();
            skillView.SyncWithModel(order, hero);
            var directionView = GetComponentInChildren<DirectionView>();
            directionView.SyncWithModel(order);
        }
    }
}