using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class ChaoticParticle : Particle
    {
        protected Random rand = new Random();
 
        public ChaoticParticle(MatrixCoords position, MatrixCoords speed)
            : base(position, speed)
        {
        }        
        protected override void Move()
        {                        
            int row = this.rand.Next(-1,1+1);
            int col = this.rand.Next(-1, 1+1);              
            this.Position += new MatrixCoords(row, col);                                                                                      
        }
        public override char[,] GetImage()
        {
            return new char[,] { { 'R' } };
        }
    }
}
