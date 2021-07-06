using System.Collections.Generic;
using model;
using UnityEngine;

namespace ui
{
    public class ActionPanelView : MonoBehaviour
    {
        public void SyncWithModel(List<Order> heroOrders, Hero hero)
        {
            Clear();
            foreach (var heroOrder in heroOrders)
            {
                OrderView.CreateOrderView(heroOrder, hero, transform);
            }
        }

        private void Clear()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}