using CALMario.Entities;
using CALMario.Entities.Blocks;
using CALMario.Entities.Enemies;
using CALMario.Entities.Items;
using CALMario.Entities.Mario;
using CALMario.Entities.Projectiles;
using CALMario.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CALMario.CollisionDetection
{
    public class CollisionDetector
    {
        private static readonly int VerticalBias = 2;

        internal static void DetectAllCollisions(List<IEntity> entities, IMario player, IMario ghostPlayer)
        {
            var items = entities.Where(t => t is IItem).ToList();
            var marios = new List<IMario> { player };
            if (ghostPlayer != null)
            {
                marios.Add(ghostPlayer);
            }
            var blocks = entities.Where(t => t is IBlock).ToList();
            var projectiles = entities.Where(t => t is IProjectile).ToList();
            var enemies = entities.Where(t => t is IEnemy).ToList();

            for (int i = 0; i < projectiles.Count; i++)
            {
                IProjectile projectileRef = (IProjectile)projectiles[i];
                ISprite projectileSprite = projectileRef.Sprite;

                for (int i2 = 0; i2 < enemies.Count; i2++)
                {
                    IEnemy enemyRef = (IEnemy)enemies[i2];

                    if (CheckForObject1CollidesTop(projectileRef, enemyRef))
                    {
                        projectileRef.CollideWithEnemy(Side.Bottom, enemyRef);
                        enemyRef.CollideWithProjectile(Side.Top, projectileRef);
                    }
                    else if (CheckForObject1CollidesBottom(projectileRef, enemyRef))
                    {
                        projectileRef.CollideWithEnemy(Side.Top, enemyRef);
                        enemyRef.CollideWithProjectile(Side.Bottom, projectileRef);
                    }
                    else if (CheckForObject1CollidesLeft(projectileRef, enemyRef))
                    {
                        projectileRef.CollideWithEnemy(Side.Right, enemyRef);
                        enemyRef.CollideWithProjectile(Side.Left, projectileRef);
                    }
                    else if (CheckForObject1CollidesRight(projectileRef, enemyRef))
                    {
                        projectileRef.CollideWithEnemy(Side.Left, enemyRef);
                        enemyRef.CollideWithProjectile(Side.Right, projectileRef);
                    }
                }

                for (int i2 = 0; i2 < blocks.Count; i2++)
                {
                    IBlock blockRef = (IBlock)blocks[i2];

                    if (CheckForObject1CollidesTop(projectileRef, blockRef))
                    {
                        projectileRef.CollideWithBlock(Side.Bottom, blockRef);
                        blockRef.CollideWithProjectile(Side.Top, projectileRef);
                    }
                    else if (CheckForObject1CollidesBottom(projectileRef, blockRef))
                    {
                        projectileRef.CollideWithBlock(Side.Top, blockRef);
                        blockRef.CollideWithProjectile(Side.Bottom, projectileRef);
                    }
                    else if (CheckForObject1CollidesLeft(projectileRef, blockRef))
                    {
                        projectileRef.CollideWithBlock(Side.Right, blockRef);
                        blockRef.CollideWithProjectile(Side.Left, projectileRef);
                    }
                    else if (CheckForObject1CollidesRight(projectileRef, blockRef))
                    {
                        projectileRef.CollideWithBlock(Side.Left, blockRef);
                        blockRef.CollideWithProjectile(Side.Right, projectileRef);
                    }
                }

            }

            for (int i = 0; i < items.Count; i++)
            {
                IItem itemRef = (IItem)items[i];

                for (int i2 = 0; i2 < marios.Count; i2++)
                {
                    IMario marioRef = (IMario)marios[i2];

                    if (CheckForObject1CollidesTop(itemRef, marioRef))
                    {
                        itemRef.CollideWithMario(Side.Bottom, marioRef);
                        marioRef.CollideWithItem(Side.Top, itemRef);
                    }
                    else if (CheckForObject1CollidesBottom(itemRef, marioRef))
                    {
                        itemRef.CollideWithMario(Side.Top, marioRef);
                        marioRef.CollideWithItem(Side.Bottom, itemRef);
                    }
                    else if (CheckForObject1CollidesLeft(itemRef, marioRef))
                    {
                        itemRef.CollideWithMario(Side.Right, marioRef);
                        marioRef.CollideWithItem(Side.Left, itemRef);
                    }
                    else if (CheckForObject1CollidesRight(itemRef, marioRef))
                    {
                        itemRef.CollideWithMario(Side.Left, marioRef);
                        marioRef.CollideWithItem(Side.Right, itemRef);
                    }
                }

                for (int i2 = 0; i2 < blocks.Count; i2++)
                {
                    IBlock blockRef = (IBlock)blocks[i2];

                    if (CheckForObject1CollidesTop(itemRef, blockRef))
                    {
                        itemRef.CollideWithBlock(Side.Bottom, blockRef);
                        blockRef.CollideWithItem(Side.Top, itemRef);
                    }
                    else if (CheckForObject1CollidesBottom(itemRef, blockRef))
                    {
                        itemRef.CollideWithBlock(Side.Top, blockRef);
                        blockRef.CollideWithItem(Side.Bottom, itemRef);
                    }
                    else if (CheckForObject1CollidesLeft(itemRef, blockRef))
                    {
                        itemRef.CollideWithBlock(Side.Right, blockRef);
                        blockRef.CollideWithItem(Side.Left, itemRef);
                    }
                    else if (CheckForObject1CollidesRight(itemRef, blockRef))
                    {
                        itemRef.CollideWithBlock(Side.Left, blockRef);
                        blockRef.CollideWithItem(Side.Right, itemRef);
                    }
                }

            }

            for (int i = 0; i < blocks.Count; i++)
            {
                IBlock blockRef = (IBlock)blocks[i];
                ISprite blockSprite = blockRef.Sprite;

                for (int i2 = 0; i2 < marios.Count; i2++)
                {

                    IMario marioRef = (IMario)marios[i2];

                    if (CheckForObject1CollidesTop(blockRef, marioRef))
                    {
                        blockRef.CollideWithMario(Side.Bottom, marioRef);
                        marioRef.CollideWithBlock(Side.Top, blockRef);
                    }
                    else if (CheckForObject1CollidesBottom(blockRef, marioRef))
                    {
                        blockRef.CollideWithMario(Side.Top, marioRef);
                        marioRef.CollideWithBlock(Side.Bottom, blockRef);
                    }
                    else if (CheckForObject1CollidesLeft(blockRef, marioRef))
                    {
                        blockRef.CollideWithMario(Side.Right, marioRef);
                        marioRef.CollideWithBlock(Side.Left, blockRef);
                    }
                    else if (CheckForObject1CollidesRight(blockRef, marioRef))
                    {
                        blockRef.CollideWithMario(Side.Left, marioRef);
                        marioRef.CollideWithBlock(Side.Right, blockRef);
                    }
                }

                for (int i2 = 0; i2 < enemies.Count; i2++)
                {
                    IEnemy enemyRef = (IEnemy)enemies[i2];

                    if (CheckForObject1CollidesTop(blockRef, enemyRef))
                    {
                        blockRef.CollideWithEnemy(Side.Bottom, enemyRef);
                        enemyRef.CollideWithBlock(Side.Top, blockRef);
                    }
                    else if (CheckForObject1CollidesBottom(blockRef, enemyRef))
                    {
                        blockRef.CollideWithEnemy(Side.Top, enemyRef);
                        enemyRef.CollideWithBlock(Side.Bottom, blockRef);
                    }
                    else if (CheckForObject1CollidesLeft(blockRef, enemyRef))
                    {
                        blockRef.CollideWithEnemy(Side.Right, enemyRef);
                        enemyRef.CollideWithBlock(Side.Left, blockRef);
                    }
                    else if (CheckForObject1CollidesRight(blockRef, enemyRef))
                    {
                        blockRef.CollideWithEnemy(Side.Left, enemyRef);
                        enemyRef.CollideWithBlock(Side.Right, blockRef);
                    }
                }

            }

            for (int i = 0; i < enemies.Count; i++)
            {
                IEnemy enemyRef = (IEnemy)enemies[i];

                for (int i2 = 0; i2 < enemies.Count; i2++)
                {
                    IEnemy secondEnemyRef = (IEnemy)enemies[i2];

                    if (CheckForObject1CollidesTop(secondEnemyRef, enemyRef))
                    {
                        secondEnemyRef.CollideWithEnemy(Side.Bottom, enemyRef);
                        enemyRef.CollideWithEnemy(Side.Top, secondEnemyRef);
                    }
                    else if (CheckForObject1CollidesBottom(secondEnemyRef, enemyRef))
                    {
                        secondEnemyRef.CollideWithEnemy(Side.Top, enemyRef);
                        enemyRef.CollideWithEnemy(Side.Bottom, secondEnemyRef);
                    }
                    else if (CheckForObject1CollidesLeft(secondEnemyRef, enemyRef))
                    {
                        secondEnemyRef.CollideWithEnemy(Side.Right, enemyRef);
                        enemyRef.CollideWithEnemy(Side.Left, secondEnemyRef);
                    }
                    else if (CheckForObject1CollidesRight(secondEnemyRef, enemyRef))
                    {
                        secondEnemyRef.CollideWithEnemy(Side.Left, enemyRef);
                        enemyRef.CollideWithEnemy(Side.Right, secondEnemyRef);
                    }
                }

                for (int i2 = 0; i2 < marios.Count; i2++)
                {
                    IMario marioRef = (IMario)marios[i2];

                    if (CheckForObject1CollidesTop(enemyRef, marioRef))
                    {
                        enemyRef.CollideWithMario(Side.Bottom, marioRef);
                        marioRef.CollideWithEnemy(Side.Top, enemyRef);
                    }
                    else if (CheckForObject1CollidesBottom(enemyRef, marioRef))
                    {
                        enemyRef.CollideWithMario(Side.Top, marioRef);
                        marioRef.CollideWithEnemy(Side.Bottom, enemyRef);
                    }
                    else if (CheckForObject1CollidesLeft(enemyRef, marioRef))
                    {
                        enemyRef.CollideWithMario(Side.Right, marioRef);
                        marioRef.CollideWithEnemy(Side.Left, enemyRef);
                    }
                    else if (CheckForObject1CollidesRight(enemyRef, marioRef))
                    {
                        enemyRef.CollideWithMario(Side.Left, marioRef);
                        marioRef.CollideWithEnemy(Side.Right, enemyRef);
                    }
                }
            }
        }

        private static bool CheckForObject1CollidesTop(IEntity object1, IEntity object2)
        {
            float topOverlap = object1.Location.Y + object1.Sprite.Height - object2.Location.Y;
            float bottomOverlap = object2.Location.Y + object2.Sprite.Height - object1.Location.Y;
            float horizontalOverlap = HorizontalOverlap(object1, object2);

            return Collision(object1, object2) && topOverlap > 0 && bottomOverlap > topOverlap && topOverlap - VerticalBias < horizontalOverlap
                && object1.Physics.Velocity.Y - object2.Physics.Velocity.Y > 0;
        }

        private static bool CheckForObject1CollidesBottom(IEntity object1, IEntity object2)
        {
            float topOverlap = object1.Location.Y + object1.Sprite.Height - object2.Location.Y;
            float bottomOverlap = object2.Location.Y + object2.Sprite.Height - object1.Location.Y;
            float horizontalOverlap = HorizontalOverlap(object1, object2);

            return Collision(object1, object2) && bottomOverlap > 0 && topOverlap > bottomOverlap && bottomOverlap - VerticalBias < horizontalOverlap
                && object1.Physics.Velocity.Y - object2.Physics.Velocity.Y < 0;
        }

        private static bool CheckForObject1CollidesLeft(IEntity object1, IEntity object2)
        {
            float leftOverlap = object1.Location.X + object1.Sprite.Width - object2.Location.X;
            float rightOverlap = object2.Location.X + object2.Sprite.Width - object1.Location.X;
            float verticalOverlap = VerticalOverlap(object1, object2);
            return Collision(object1, object2) && leftOverlap > 0 && leftOverlap < rightOverlap && leftOverlap < verticalOverlap - VerticalBias;

        }

        private static bool CheckForObject1CollidesRight(IEntity object1, IEntity object2)
        {
            float leftOverlap = object1.Location.X + object1.Sprite.Width - object2.Location.X;
            float rightOverlap = object2.Location.X + object2.Sprite.Width - object1.Location.X;
            float verticalOverlap = VerticalOverlap(object1, object2);
            return Collision(object1, object2) && rightOverlap > 0 && rightOverlap < leftOverlap && rightOverlap < verticalOverlap - VerticalBias;
        }

        public static bool Collision(IEntity ent1, IEntity ent2)
        {
            return HorizontalOverlap(ent1, ent2) > 0 && VerticalOverlap(ent1, ent2) > 0;
        }
        private static float HorizontalOverlap(IEntity ent1, IEntity ent2)
        {
            //Four cases, ent1 touches ent2's left, the opposite, or one is inside the other.
            if(ent1.Location.X < ent2.Location.X)
            {
                return HorizontalOverlap(ent2, ent1);
            }
            else
            {
                if(ent1.Location.X + ent1.Sprite.Width <= ent2.Location.X + ent2.Sprite.Width)
                {
                    //ent1 is within ent2
                    return ent1.Sprite.Width;
                }
                else if(ent1.Location.X > ent2.Location.X + ent2.Sprite.Width)
                {
                    //they aren't intersecting at all.
                    return 0;
                }
                else
                {
                    return ent2.Location.X + ent2.Sprite.Width - ent1.Location.X;
                }
            }
        }
        private static float VerticalOverlap(IEntity ent1, IEntity ent2)
        {
            if (ent1.Location.Y < ent2.Location.Y)
            {
                return VerticalOverlap(ent2, ent1);
            }
            else
            {
                if (ent1.Location.Y + ent1.Sprite.Height <= ent2.Location.Y + ent2.Sprite.Height)
                {
                    return ent1.Sprite.Height;
                }
                else if (ent1.Location.Y > ent2.Location.Y + ent2.Sprite.Height)
                {
                    return 0;
                }
                else
                {
                    return ent2.Location.Y + ent2.Sprite.Height - ent1.Location.Y;
                }
            }
        }

    }
}
