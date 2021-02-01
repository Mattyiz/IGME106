using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Justin Cheng 3/4/2020 
namespace BuzzBattle
{
    /// <summary>
    /// This is the enemy manager class
    /// sets the spawn rate and spots of the enemies.
    /// have events done when collision is detected
    /// </summary>
    class EnemyManager
    {
        //fields
        private WaveManager waveManager;
        private Texture2D enemySprite;
        private Rectangle target;
        private Hive homeBase;

        //spawning fields
        private Rectangle spawnLocationTop;
        private Rectangle spawnLocationBot;
        private Rectangle spawnLocationLeft;
        private Rectangle spawnLocationRight;
        private int spawnRate;
        private List<Enemy> enemies;
        private bool spawnPhase;
        private int currentCD;
        private const int waveCD = 240;

        private Random rng;
        private int maxWidth;
        private int maxHeight;

        private int enemyDamage = 5;

            //damaging fields


        //properties
        public Rectangle SpawnLocationTop { get { return spawnLocationTop; } set { spawnLocationTop = value; } }
        public Rectangle SpawnLocationBot { get { return spawnLocationBot; } set { spawnLocationBot = value; } }
        public Rectangle SpawnLocationLeft { get { return spawnLocationLeft; } set { spawnLocationLeft = value; } }
        public Rectangle SpawnLocationRight { get { return spawnLocationRight; } set { spawnLocationRight = value; } }
        public List<Enemy> Enemies { get { return enemies; } }
        public int Spawnrate { get { return spawnRate; } }
        public bool SpawnPhase { get { return spawnPhase; } set { spawnPhase = value; } }
        public WaveManager WaveManager { get { return waveManager; } }
        public Texture2D EnemySprite { get { return enemySprite; } set { enemySprite = value;  } }
        //constructor
        public EnemyManager(Texture2D enemySprite, Rectangle enemytarget, Hive homeBase, int screenWidth, int screenHeight)
        {
            this.enemySprite = enemySprite;
            target = enemytarget;
            this.homeBase = homeBase;
            waveManager = new WaveManager();
            enemies = new List<Enemy>();

            spawnPhase = false;
            spawnRate = 30;
            currentCD = 0;

            maxWidth = screenWidth;
            maxHeight = screenHeight;

            rng = new Random();
        }

        //methods
        /// <summary>
        /// start spawnning the enemies
        /// </summary>
        public void Spawn()
        {
            //cooldown timer for spawning
            if (currentCD > 0)
            {
                currentCD--;
            }
            else
            {
                //is it currently not between waves (is it time to spawn a wave in)
                if (spawnPhase)
                {
                    //does the wave currently still have enemies to spawn
                    if (waveManager.enemyStack.Count > 0)
                    {
                        //spawn the enemies at locations the text file says
                        int intSpawnRNG = rng.Next(30, 71);

                        double spawnRNG = (double)intSpawnRNG / 100;

                        int rngPos;
                        Rectangle spawnLocation;
                        switch (waveManager.enemyStack.Pop())
                        {
                            case 'T':
                                rngPos = (int)(maxWidth * spawnRNG);
                                spawnLocation = new Rectangle(rngPos, 0, 75, 75);
                                enemies.Add(new Enemy(enemySprite, spawnLocation, target,'T'));
                                break;

                            case 'B':
                                rngPos = (int)(maxWidth * spawnRNG);
                                spawnLocation = new Rectangle(rngPos, maxHeight, 75, 75);
                                enemies.Add(new Enemy(enemySprite, spawnLocation, target,'B'));
                                break;

                            case 'L':
                                rngPos = (int)(maxHeight * spawnRNG);
                                spawnLocation = new Rectangle(0, rngPos, 75, 75);
                                enemies.Add(new Enemy(enemySprite, spawnLocation, target,'L'));
                                break;

                            case 'R':
                                rngPos = (int)(maxHeight * spawnRNG);
                                spawnLocation = new Rectangle(maxWidth, rngPos, 75, 75);
                                enemies.Add(new Enemy(enemySprite, spawnLocation, target,'R'));
                                break;

                            default:
                                break;
                        }
                    }
                    else //no more enemies in this wave
                    {
                        spawnPhase = false;
                    }
                    //cooldown between each spawn
                    currentCD = spawnRate;
                }
                else 
                {
                    //are there no more enemies in the current wave
                    if (enemies.Count <= 0)
                    {
                        currentCD = waveCD; //wave cooldown
                        spawnPhase = true;
                        WaveManager.NextWave(); //prepares next wave 

                        //debug
                        Console.WriteLine("next wave");
                    }
                }
            }
        }
        public void Update()
        {
            if (enemies.Count > 0)
            {
                foreach (Enemy enemy in enemies)
                {
                    if (enemy.IsTouchingBase)
                    {
                        if (enemy.CanAttack())
                        {
                            homeBase.Health -= enemyDamage;
                        }
                    }
                    else
                    {
                        enemy.Move();
                    }
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Enemy enemy in enemies)
            {
                sb.Draw(enemy.Sprite, enemy.Pos, Color.White);
            }
        }

        public void Reset()
        {
            enemies.Clear();
            waveManager.ResetWaves();
        }

        public void Kill(Enemy enemy)
        {
            enemies.Remove(enemy);
        }
    }
}
