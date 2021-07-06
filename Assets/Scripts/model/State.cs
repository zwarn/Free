namespace model
{
    public class State
    {
        public Board Board;

        public State(Board board)
        {
            Board = board;
        }

        public State Copy()
        {
            return new State(Board.Copy());
        }
    }
}