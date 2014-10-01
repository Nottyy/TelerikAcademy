using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ParticleSystemMain
    {
        const int SimulationRows = 30;
        const int SimulationCols = 40;

        static readonly Random RandomGenerator = new Random();

        static void Main(string[] args)
        {
            Random random = new Random();
            var renderer = new ConsoleRenderer(SimulationRows, SimulationCols);
            var particleOperator = new AdvancedParticleOperator();

            var particles = new List<Particle>()
            {
                //new Particle(new MatrixCoords(5, 5), new MatrixCoords(1, 1)),
                //new ParticleEmitter(new MatrixCoords(5, 10), new MatrixCoords(0, 0), RandomGenerator),
                //new ParticleEmitter(new MatrixCoords(5, 20), new MatrixCoords(0, 0), RandomGenerator),
                //new VariousLifetimeParticleEmitter(new MatrixCoords(29, 1), new MatrixCoords(0, 0), RandomGenerator),
                //new ChaoticParticle(new MatrixCoords(20, 25), new MatrixCoords (1,1)), // First and Second exercises
                new ChickenParticle(new MatrixCoords(14,10),new MatrixCoords(1,1), 3, 3), //Third and Fourth exercises
                //new ParticleRepeller(new MatrixCoords(12,20), new MatrixCoords(0,0), 3, 8) // Fifth and Sixth exercises

               
            };

            var engine = new Engine(renderer, particleOperator, particles, 500);

            engine.Run();
        }
    }
}
