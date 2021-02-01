using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Matt I, 2/23, 3/1, 3/4
namespace BuzzBattle
{
    /// <summary>
    /// This class will have a list of the projectiles
    /// </summary>
    class ProjectileManager
    {

        //fields
        private List<Projectile> projectiles;
        private int count;

        private int score;

        Hive hive;
        EnemyManager enemyManager;

        //properties
        public int Score
        {
            get { return score; }
            set { score = value; }
        }


        /// <summary>
        /// This is the indexer for the list
        /// </summary>
        /// <param name="index">The desired position</param>
        /// <returns></returns>
        public Projectile this[int index]
        {
            get
            {
                return projectiles[index];
            }
            set
            {
                //if (projectiles.)
                projectiles[index] = value;
            }
        }

        public int Count
        {
            get { return count; }
        }

        //constructors
        public ProjectileManager(Hive hive, EnemyManager enemyManager)
        {
            this.hive = hive;
            this.enemyManager = enemyManager;
            projectiles = new List<Projectile>();
        }



        //methods

        /// <summary>
        /// This adds to the projectile list
        /// </summary>
        /// <param name="newProjectile">The new projectile</param>
        public void Add(Projectile newProjectile)
        {
            projectiles.Add(newProjectile);
            count++;
        }

        public void UpdateProjectiles()
        {
            List<Projectile> removalList = new List<Projectile>();

            foreach(Projectile p in projectiles)
            {
                bool projectileActive = true;

                if (p.CollidesWith(hive.Pos))
                {
                    removalList.Add(p);
                    projectileActive = false;
                    continue;
                }
                else
                {
                    foreach (Enemy enemy in enemyManager.Enemies)
                    {
                        if (enemy.CheckCollison(p.Pos))
                        {
                            enemyManager.Kill(enemy);
                            removalList.Add(p);
                            projectileActive = false;
                            score++;
                            break;
                        }
                    }

                    if (p.CanMove)
                    {
                        if (projectileActive)
                        {
                            p.Move();
                        }
                    }
                    else
                    {
                        removalList.Add(p);
                    }
                }
            }

            foreach (Projectile p in removalList)
            {
                Remove(p);
            }
        }

        /// <summary>
        /// Removes a projectile at a given position
        /// </summary>
        /// <param name="index">The position</param>
        public void RemoveAt(int index)
        {
            projectiles.RemoveAt(index);
            count--;
        }

        /// <summary>
        /// Removes a projectile
        /// </summary>
        /// <param name="projectile">The projectile being removed</param>
        public void Remove(Projectile projectile)
        {
            projectiles.Remove(projectile);
            count--;
        }

        public void Reset()
        {
            projectiles.Clear();
            count = 0;
        }
    }
}
