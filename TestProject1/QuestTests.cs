using QuestProgressTracker;

namespace TestProject
{
    public class QuestTests
    {
        [Fact]
        public void Quest_Is_Not_Completed_When_Objectives_Not_Finished()
        {
            //Arrange
            var quest = CreateQuest();
            //Act
            quest.ProgressObjective("Kill Goblins", 3);
            //Assert
            Assert.False(quest.IsCompleted);
        }

        [Fact]
        public void Quest_Is_Completed_When_All_Objectives_Are_Finished()
        {
            //Arrange
            var quest = CreateQuest();
            //Act
            quest.ProgressObjective("Kill Goblins", 5);
            //Assert
            Assert.True(quest.IsCompleted);
        }

        [Fact]
        public void Progress_Cannot_Exceed_Required_Amount()
        {
            //Arrange
            var quest = CreateQuest();
            //Act
            quest.ProgressObjective("Kill Goblins", 10);
            //Assert
            Assert.Equal(5, quest.GetObjective("Kill Goblins").CurrentAmount);
        }

        [Fact]
        public void Progressing_Nonexistent_Objective_Throws()
        {
            //Arrange
            var quest = new Quest("Goblin Slayer");
            //Act//Assert
            Assert.Throws<Exception>(() =>
                quest.ProgressObjective("Fake", 1));
        }

        [Fact]
        public void Progress_Cannot_Be_Negative()
        {
            //Arrange
            var quest = CreateQuest();
            //Act//Assert
            Assert.Throws<Exception>(() =>
                quest.ProgressObjective("Kill Goblins", -1));
        }

        private Quest CreateQuest()
        {
            var quest = new Quest("Goblin Slayer");
            quest.AddObjective("Kill Goblins", 5);
            return quest;
        }
    }
}
