namespace QuestProgressTracker
{
    public class Objective
    {
        public string Name { get; private set; }
        public int RequiredAmount { get; private set; }
        public int CurrentAmount { get; private set; }

        public Objective(string name, int requiredAmount)
        {
            Name = name;
            RequiredAmount = requiredAmount;
            CurrentAmount = 0;
        }

        public void Progress(int amount)
        {
            if (amount < 0)
            {
                throw new Exception("Progress cannot be negative.");
            }

            CurrentAmount += amount;

            if (CurrentAmount > RequiredAmount)
            {
                CurrentAmount = RequiredAmount;
            }
        }

        public bool IsCompleted
        {
            get
            {
                return CurrentAmount >= RequiredAmount;
            }
        }
    }
}