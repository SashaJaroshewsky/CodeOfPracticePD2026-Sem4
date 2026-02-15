namespace LSP.BadExample1
{
    internal class Zoo
    {
        public List<Bird> Birds { get; }

        public Zoo()
        {
            Birds = new List<Bird>();
        }

        public void AddBird(Bird bird)
        {
            Birds.Add(bird);
        }

        public void MoveBirds()
        {
            foreach (var bird in Birds)
            {
                bird.Fly();
            }
        }
    }
}
