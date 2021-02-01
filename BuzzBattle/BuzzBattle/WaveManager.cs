using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// This code was written by Grant Minor (4/12/20)


// THE ONLY THINGS THAT MATTER TO YOU GUYS HERE ARE:

// 1.)  Stack<char> enemyStack

// 2.)  void NextWave()

// 3.)  void ResetWave()


namespace BuzzBattle
{
    class WaveManager
    {
        // Private Fields
        private List<Wave> waveList;
        private Random rng;

        private const int finalWaveEnemyCountIncrease = 10;

        //Public Fields
        public Queue<Wave> waveQueue;
        public Wave currentWave;
        public int currentEnemyCount;
        public int finalWaveEnemyCount;


        // ====== THIS IS WHERE YOU GET THE ENEMIES ======
        public Stack<char> enemyStack;


        // Constructor
        public WaveManager()
        {
            waveList = new List<Wave>();
            waveQueue = new Queue<Wave>();
            currentWave = null;
            currentEnemyCount = 0;
            enemyStack = new Stack<char>();

            rng = new Random();

            ReadWaveFile();

            /*try
            {
                ReadWaveFile();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR!!! A problem has occurred while attempting to save!");
                Console.WriteLine(e.Message);
            }*/
        }


        // Methods

        /// <summary>
        /// Fills the enemyStack with letter characters that represent enemies.
        /// Each letter corresponds to the side of the screen the enemy should spawn on.
        /// ('T' => Top, 'L' => Left, 'R' => Right, and 'B' => Bottom)
        /// </summary>
        public void NextWave()
        {
            if (waveQueue.Count > 0)
            {
                currentWave = waveQueue.Dequeue();

                enemyStack = currentWave.RandomEnemyStack;

                currentEnemyCount = currentWave.TotalEnemyCount;
            }
            else
            {
                finalWaveEnemyCount += finalWaveEnemyCountIncrease;

                for (int n = 0; n < finalWaveEnemyCount; n++)
                {
                    int randomDirection = rng.Next(0, 4);

                    switch (randomDirection)
                    {
                        case 0:
                            enemyStack.Push('T');
                            break;

                        case 1:
                            enemyStack.Push('L');
                            break;

                        case 2:
                            enemyStack.Push('R');
                            break;

                        case 3:
                            enemyStack.Push('B');
                            break;

                        default:
                            break;
                    }
                }

                currentEnemyCount = finalWaveEnemyCount;
            }
        }


        /// <summary>
        /// Resets the wave queue (starts over from Wave 1).
        /// Call this if the player decides to restart.
        /// </summary>
        public void ResetWaves()
        {
            waveQueue.Clear();

            RandomizeEnemies();

            for (int i = 0; i < waveList.Count; i++)
            {
                waveQueue.Enqueue(waveList[i]);
            }
        }



        // ================ IGNORE EVERYTHING PAST THIS POINT ======================



        private void ReadWaveFile()
        {
            if (File.Exists("waves.txt"))
            {
                FileStream inStream = File.OpenRead("waves.txt");
                StreamReader input = new StreamReader(inStream);


                int totalWaves = int.Parse(input.ReadLine());

                int finalWaveEnemyCount = int.Parse(input.ReadLine());

                List<string[]> wavesAsStringArrays = new List<string[]>();

                string line = "";

                int totalWavesRead = 0;

                do
                {
                    line = input.ReadLine();

                    if (line != null && line != "")
                    {
                        string[] waveData = line.Split(',');
                        wavesAsStringArrays.Add(waveData);
                        totalWavesRead++;
                    }
                }
                while (line != null && line != "");

                input.Close();
                inStream.Close();

                if (totalWaves != totalWavesRead)
                {
                    throw new Exception("Discrepancy in wave quantities.");
                }

                for (int i = 0; i < totalWaves; i++)
                {
                    string[] waveArray = wavesAsStringArrays[i];

                    string wName = waveArray[0];

                    int wTop = int.Parse(waveArray[1]);
                    int wLeft = int.Parse(waveArray[2]);
                    int wRight = int.Parse(waveArray[3]);
                    int wBottom = int.Parse(waveArray[4]);

                    Wave newWave = new Wave(wName, wTop, wLeft, wRight, wBottom, rng);

                    waveList.Add(newWave);
                    waveQueue.Enqueue(newWave);
                }
            }
            else
            {
                throw new Exception("ERROR: Wave file was not found (\"waves.txt\")");
            }
        }

        private void RandomizeEnemies()
        {
            foreach(Wave w in waveList)
            {
                w.RandomizeEnemyStack();
            }
        }
    }
}
