namespace model
{
    public class Order
    {
        public Skill Skill;
        public Direction Direction;

        public Order(Skill skill, Direction direction)
        {
            Skill = skill;
            Direction = direction;
        }

        public static Order from(Skill skill, Direction direction)
        {
            return new Order(skill, direction);
        }

        public Order Copy()
        {
            return new Order(Skill, Direction);
        }
    }
}