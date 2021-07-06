namespace animation
{
    public abstract class Animation
    {
        public bool Finished = false;
        protected float _currentTime;

        public void Animate(float deltaTime)
        {
            if (Finished)
            {
                return;
            }

            if (_currentTime == 0)
            {
                OnStart();
            }

            OnUpdate(deltaTime);
        }

        protected abstract void OnUpdate(float deltaTime);

        protected abstract void OnStart();
    }
}