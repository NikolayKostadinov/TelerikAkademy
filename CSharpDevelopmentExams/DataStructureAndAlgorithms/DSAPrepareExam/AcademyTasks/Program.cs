using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyTasks
{
    class Program
    {
        private static int[] pleasantness =
            {
               1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 999
            };

        private static int variety = 1; // expected 26
        static bool isSolved = false;
        static HashSet<int> vizited = new HashSet<int>();

        static void Main()
        {
            string[] input = Console.ReadLine().Split(',');
            variety = int.Parse(Console.ReadLine());

            pleasantness = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                pleasantness[i] = int.Parse(input[i]);
            }

            var start = new Node();
            start.Value = pleasantness[0];
            start.Min = Math.Min(start.Value, int.MaxValue);
            start.Max = Math.Max(start.Value, int.MinValue);
            start.Index = 0;
            start.Steps = 1;

            var queue = new Queue<Node>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.Steps == 22)
                {
                    
                }

                if (Math.Abs(currentNode.Min - currentNode.Max) >= variety)
                {
                    Console.WriteLine(currentNode.Steps);
                    isSolved = true;
                    return;
                }

                //i+1
                if (currentNode.Index + 1< pleasantness.Count())
                {
                    var nodeOne = new Node();
                    nodeOne.Steps = currentNode.Steps + 1;
                    nodeOne.Value = pleasantness[currentNode.Index + 1];
                    nodeOne.Index = currentNode.Index + 1;
                    nodeOne.Min = Math.Min(pleasantness[currentNode.Index + 1], currentNode.Min);
                    nodeOne.Max = Math.Max(pleasantness[currentNode.Index + 1], currentNode.Max);
                    if(!vizited.Contains(nodeOne.Id))
                    {
                        queue.Enqueue(nodeOne);
                        vizited.Add(nodeOne.Id);
                    }
                }

                //i+2
                if (currentNode.Index + 2 < pleasantness.Count())
                {
                    var nodeTwo = new Node();
                    nodeTwo.Steps = currentNode.Steps + 1;
                    nodeTwo.Value = pleasantness[currentNode.Index + 2];
                    nodeTwo.Index = currentNode.Index + 2;
                    nodeTwo.Min = Math.Min(pleasantness[currentNode.Index + 2], currentNode.Min);
                    nodeTwo.Max = Math.Max(pleasantness[currentNode.Index + 2], currentNode.Max);
                    queue.Enqueue(nodeTwo);
                }
            }
            if (!isSolved)
                Console.WriteLine(pleasantness.Count());
        }
    }

    class Node
    {
        private int id = 0;
        public int Id
        {
            get { return this.Value + this.Steps + this.Index + this.Min + this.Max; }
        }

        public int Value { get; set; }

        public int Steps { get; set; }

        public int Index { get; set; }

        public int Min { get; set; }

        public int Max { get; set; }
        
    }
}