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
        public void Quest_Is_Completed_When_All_Objectives_Are_Finished_And_Turned_In()
        {
            // Arrange
            var quest = CreateQuest();

            // Act
            quest.ProgressObjective("Kill Goblins", 5);
            quest.TurnIn();

            // Assert
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

        [Fact]
        public void Quest_Is_Not_Completed_Until_Turned_In()
        {
            // Arrange
            var quest = new Quest("Goblin Slayer");
            quest.AddObjective("Kill Goblins", 5);

            // Act
            quest.ProgressObjective("Kill Goblins", 5);

            // Assert
            Assert.False(quest.IsCompleted);
        }
    }
}

/*
Why did the tests fail?
the test was failed because requirement was changed. Using only Objective doesn't complete quest, and needed turn in


Did the implementation need to change?
I added a private field to track whether the quest was turned in, added a TurnIn() method, and updated IsCompleted.


Did the tests need to change?
The old test expected using only completing object, so I added Turn in method and added Iscompleted

How do real software teams handle requirement changes like this?
 software teams update both the code and the tests,so they match the new requirements.


*/
