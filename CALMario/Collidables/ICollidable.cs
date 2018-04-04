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
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands
{
    public interface ICollidable
    {
        void CollideWithEnemy(Side side,  IEnemy e); //TODO: Add an Enum EnemyType inside of enemy? 
        //To allow for different behavior depending on what kind of enemy has eben collided with?
        void CollideWithBlock(Side side, IBlock b); //ground is considered a block
        void CollideWithItem(Side side, IItem i);
        void CollideWithMario(Side side, IMario m);
        void CollideWithProjectile(Side side, IProjectile p);
    }
}
