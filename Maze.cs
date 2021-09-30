using NUnit.Framework;

namespace MazeGeneric
{
    public class Maze { }

    public class MazeBuilder<TMazeItem> where TMazeItem : MazeBuilder<TMazeItem>
    {
        protected Maze maze = new Maze();
        
        public TMazeItem AddRock(int x, int y)
        {
            // добавляем камень в maze
            return (TMazeItem)this;
        }
    
        // ещё много подобных методов добавления всего в maze.
        
        public Maze Build()
        {
            // ...
            return maze;
        }
    }
    
    public class ScaryMazeBuilder : MazeBuilder<ScaryMazeBuilder>
    {
        // Хотим добавить новые возможности к MazeBuilder-у
        public ScaryMazeBuilder AddGhost(int x, int y)
        {
            return this;
        }

        // ещё много методов добавления страшилок в лабиринт.
    }

    [TestFixture]
    public class Test
    {
        [Test]
        public void TestBuilder_ShouldBeOk()
        {
            var builder = new ScaryMazeBuilder();
            var maze = builder
                .AddRock(5, 6)
                .AddRock(5, 4)
                .AddRock(4, 5)
                .AddGhost(5, 5)
                .AddGhost(15, 5)
                .Build();
        }
    }
}