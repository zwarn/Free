using System;
using System.Collections.Generic;
using System.Linq;
using scriptableObject;
using UnityEngine;
using Animation = animation.Animation;

namespace model
{
    public class Hero : Character
    {
        public List<Order> Orders;
        public List<Skill> PossibleSkills;

        public Hero(Vector2Int position, HeroSo heroSo, List<Order> orders, bool friend = true)
            : base(position, heroSo, friend)
        {
            Orders = orders;
            PossibleSkills = heroSo.PossibleSkills;
        }

        public override List<Animation> Act(State state)
        {
            return PerformOrders(state);
        }

        public List<Animation> PerformOrders(State state)
        {
            return Orders.Select(order => PerformOrder(state, order)).ToList();
        }

        private Animation PerformOrder(State state, Order order)
        {
            return order.Skill.Execute(state, this, order.Direction);
        }

        public override Character Copy()
        {
            Hero copy = new Hero(Position, (HeroSo) CharacterSo, Orders.Select(order => order.Copy()).ToList());
            copy.hp = hp;
            copy.SetView(View);
            return copy;
        }
    }
}