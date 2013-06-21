using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyTasks
{
    class Program
    {
        private static int[] pleasantness =
            {
                25, 35, 34, 6, 27, 32, 28, 32, 25, 11, 19, 3, 27, 14, 24, 2, 24, 32, 25, 15
                , 10, 25, 9, 25, 14, 7, 24, 30, 14, 18, 20, 24, 20, 17, 25, 8
            };

        private static int variety = 32; // expected 7
        private static int step = 0;
        //static int min = int.MaxValue;
        //static int max = int.MinValue;
        static bool isSolved = false;

        static void Main()
        {
            //string[] input = Console.ReadLine().Split(',');
            //variety = int.Parse(Console.ReadLine());

            //pleasantness = new int[input.Length];
            //for (int i = 0; i < input.Length; i++)
            //{
            //    pleasantness[i] = int.Parse(input[i]);
            //}

            var start = new Node<int>();
            start.Value = pleasantness[0];
            start.Min = Math.Min(start.Value, int.MaxValue);
            start.Max = Math.Max(start.Value, int.MinValue);

            var queue = new Queue<Node<int>>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                step++;
                var currentNode = queue.Dequeue();

                if (Math.Abs(currentNode.Min - currentNode.Max) >= variety)
                {
                    Console.WriteLine(step);
                    isSolved = true;
                    return;
                }

                //i+1
                if (step < pleasantness.Count())
                {
                    var nodeOne = new Node<int>();
                    nodeOne.Value = pleasantness[step];
                    nodeOne.Min = Math.Min(nodeOne.Value, currentNode.Min);
                    nodeOne.Max = Math.Max(nodeOne.Value, currentNode.Max);
                    queue.Enqueue(nodeOne);
                }

                //i+2
                if (step + 1 < pleasantness.Count())
                {
                    var nodeTwo = new Node<int>();
                    nodeTwo.Value = pleasantness[step + 1];
                    nodeTwo.Min = Math.Min(nodeTwo.Value, currentNode.Min);
                    nodeTwo.Max = Math.Max(nodeTwo.Value, currentNode.Max);
                    queue.Enqueue(nodeTwo);
                }

                //if (currentNode.Step + 1 < pleasantness.Count())
                //{
                //    CreateNewNode(currentNode, pleasantness[currentNode.Step + 1], queue);
                //}

                //if (queue.Count > 0 && currentNode.Step + 2 < pleasantness.Count())
                //{
                //    CreateNewNode(currentNode, pleasantness[currentNode.Step + 2], queue);
                //}
            }
            if (!isSolved)
                Console.WriteLine(pleasantness.Count());
        }

        //private static void CreateNewNode(Node<int> currentNode, int newValue, Queue<Node<int>> queue)
        //{
        //    //if (newValue == -1)
        //    //{
        //    //    Console.WriteLine(pleasantness.Count());
        //    //    queue.Clear();
        //    //    return;
        //    //}

        //    var nodeOne = new Node<int>();
        //    nodeOne.Value = newValue;
        //    //nodeOne.Parent = currentNode;
        //    nodeOne.Step++;
        //    nodeOne.Min = Math.Min(nodeOne.Value, currentNode.Min);
        //    nodeOne.Max = Math.Max(nodeOne.Value, currentNode.Max);

        //    if (Math.Abs(nodeOne.Min - nodeOne.Max) >= variety)
        //    {
        //        queue.Clear();
        //        Print(nodeOne);
        //        isSolved = true;
        //    }
        //    else
        //    {
        //        queue.Enqueue(nodeOne);
        //    }
        //}

        //private static void Print(Node<int> nodeOne)
        //{
        //    Node<int> cNode = nodeOne;
        //    int result = 0;
        //    while (cNode.Parent != null)
        //    {
        //        result++;
        //        cNode = cNode.Parent;
        //    }
        //    Console.WriteLine(result + 1);
        //}

        //static int OperationOne(int index)
        //{
        //    if (index + 1 > pleasantness.Length - 1)
        //    {
        //        return -1;
        //    }
        //    return pleasantness[index + 1];
        //}

        //static int OperationTwo(int index)
        //{
        //    if (index + 2 > pleasantness.Length - 1)
        //    {
        //        return -1;
        //    }
        //    return pleasantness[index + 2];
        //}
    }

    class Node<T>
    {
        public T Value { get; set; }

        public int Min { get; set; }

        public int Max { get; set; }
    }
}
