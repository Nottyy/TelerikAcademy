using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class ChickenParticle : ChaoticParticle
    {
        private const int maxEggsToProducePerTick = 2;
        private int framesFreezedCount;
        private int framesMovingCount;

        public ChickenParticle(MatrixCoords position, MatrixCoords speed, int freezeAfter, int freezeTime)
            : base(position, speed)
        {
            this.FreezeTime = freezeTime;
            this.FreezeAfter = freezeAfter;
            this.Freezed = false;
        }
        public int FreezeTime { get; private set; }
        public int FreezeAfter { get; private set; }
        public bool Freezed { get; private set; }
        public bool ProducedEggs { get; private set; }

        public override IEnumerable<Particle> Update()
        {
            if (this.Freezed)
            {
                this.framesFreezedCount++;
                if (this.framesFreezedCount == this.FreezeTime)
                {
                    this.Freezed = false;
                    this.framesFreezedCount = 0;
                    this.ProducedEggs = false;
                }

                List<Particle> produced = new List<Particle>();
                int r = this.rand.Next(-1, 2);
                if (!this.ProducedEggs)
                {

                    for (int i = 0; i <= ChickenParticle.maxEggsToProducePerTick; i++)
                    {
                        int dir = this.rand.Next(-1, 2);
                        int dir2 = this.rand.Next(-1, 2);
                        Particle p = new Particle(this.Position, new MatrixCoords(dir, dir2));
                        produced.Add(p);
                    }
                    var baseProduced = base.Update();
                    produced.AddRange(baseProduced);
                    this.ProducedEggs = true;
                    return produced;
                }
            }

            this.framesMovingCount++;
            if (this.framesMovingCount == this.FreezeAfter)
            {
                this.Freezed = true;
                this.framesMovingCount = 0;
            }
            return base.Update();
        }

        protected override void Move()
        {
            if (!this.Freezed)
            {
                int row = this.rand.Next(-1, 2);
                int col = this.rand.Next(-1, 2);
                this.Position += new MatrixCoords(row, col);
            }
            else
            {
                this.Position += new MatrixCoords(0, 0);
            }
        }

        public override char[,] GetImage()
        {
            return new char[,] { { '9' } };
        }
    }
}
