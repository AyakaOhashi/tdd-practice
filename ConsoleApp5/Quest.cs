namespace QuestProgressTracker
{
    public class Quest
    {
        private string name;
        private List<Objective> objectives = new List<Objective>();
        private bool isTurnedIn = false;

        public Quest(string name)
        {
            this.name = name;
        }

        public bool IsCompleted
        {
            get
            {
                return objectives.Count > 0 &&
                       objectives.All(objective => objective.IsCompleted) &&
                       isTurnedIn;
            }
        }

        public void AddObjective(string name, int requiredAmount)
        {
            Objective objective = new Objective(name, requiredAmount);
            objectives.Add(objective);
        }

        public Objective GetObjective(string name)
        {
            Objective objective = objectives.FirstOrDefault(
                objective => objective.Name == name
            );

            if (objective == null)
            {
                throw new Exception("Objective not found.");
            }

            return objective;
        }

        public void ProgressObjective(string name, int amount)
        {
            if (amount < 0)
            {
                throw new Exception("Progress cannot be negative.");
            }

            Objective objective = GetObjective(name);
            objective.Progress(amount);
        }

        public void TurnIn()
        {
            isTurnedIn = true;
        }
        
    }
}