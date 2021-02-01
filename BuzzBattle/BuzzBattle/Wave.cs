using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// This code was written by Grant Minor (4/12/20)


namespace BuzzBattle
{
    class Wave
    {
        // Fields
        private string name;

        private int top;
        private int left;
        private int right;
        private int bottom;

        private int totalEnemyCount;

        private List<char> enemyList;

        private Stack<char> randomEnemyStack;

        private Random rng;



        // Properties

        public string Name
        {
            get { return name; }
        }

        public int Top
        {
            get { return top; }
        }

        public int Left
        {
            get { return left; }
        }

        public int Right
        {
            get { return right; }
        }

        public int Bottom
        {
            get { return bottom; }
        }

        public int TotalEnemyCount
        {
            get { return totalEnemyCount; }
        }

        public Stack<char> RandomEnemyStack
        {
            get { return randomEnemyStack; }
        }


        // Constructor
        public Wave(string name, int top, int left, int right, int bottom, Random rng)
        {
            this.name = name;
            this.top = top;
            this.left = left;
            this.right = right;
            this.bottom = bottom;
            this.rng = rng;

            totalEnemyCount = 0;
            totalEnemyCount += Top;
            totalEnemyCount += Left;
            totalEnemyCount += Right;
            totalEnemyCount += Bottom;

            enemyList = new List<char>();

            for(int n = 0; n < Top; n++)
            {
                enemyList.Add('T');
            }

            for (int n = 0; n < Left; n++)
            {
                enemyList.Add('L');
            }

            for (int n = 0; n < Right; n++)
            {
                enemyList.Add('R');
            }

            for (int n = 0; n < Bottom; n++)
            {
                enemyList.Add('B');
            }

            if (totalEnemyCount != enemyList.Count)
            {
                throw new Exception("ERROR: Enemy count discrepency during wave construction");
            }

            RandomizeEnemyStack();
        }


        // Creates a stack containing all enemies shuffled into a random order
        public Stack<char> RandomizeEnemyStack()
        {
            randomEnemyStack = new Stack<char>();

            List<char> tempEnemyList = new List<char>();

            tempEnemyList.AddRange(enemyList);

            for (int n = 0; n < totalEnemyCount; n++)
            {
                int randomIndex = rng.Next(0, tempEnemyList.Count);

                char enemy = tempEnemyList[randomIndex];

                randomEnemyStack.Push(enemy);

                tempEnemyList.RemoveAt(randomIndex);
            }

            return randomEnemyStack;
        }
    }
}
