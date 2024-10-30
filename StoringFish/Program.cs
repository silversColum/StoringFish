using System.Xml;
using System.Xml.Linq;

namespace StoringFish
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read fish data from file
            List<string> fishList = ReadFishData("C:\\Users\\logan\\source\\repos\\StoringFish\\StoringFish\\StoringFish\\fish_data.txt");

            // Array
            //array is a fixed-size collection of elements of the same type
            //elements can be accessed via an index
            ////accessing an element by index is O(1), 
            ///but adding or removing elements can be O(n) 
            ///due to the need to resize the array
            string[] fishArray = fishList.ToArray();
            ///best for storing a fixed number of elements when 
            ///quick access by index is needed

            // Dictionary (Map)
            /// dictionary stores key-value pairs, allowing for fast lookups, 
            /// additions, and deletions based on keys
            /// average O(1) time complexity for insertions, deletions, and lookups, 
            /// but O(n) in the worst case
            Dictionary<int, string> fishDictionary = new Dictionary<int, string>();
            //useful when you need to associate unique keys with values,
            //such as mapping fish IDs to fish names
            for (int i = 0; i < fishList.Count; i++)
            {
                fishDictionary.Add(i, fishList[i]);
            }

            // Stack
            /// stack is a last-in-first-out (LIFO) data structure. 
            /// elements are added and removed from the top
            //// Operations:
            //push(T element) O(1)
            //pop() O(1)
            //size() O(1)
            //IsEmpty() O(1)
            Stack<string> fishStack = new Stack<string>(fishList);
            //best for scenarios where you need to backtrack or undo operations,
            //such as navigating back through a series of actions or
            //maintaining a history of selections


            // Queue
            ///queue is a first-in-first-out (FIFO) data structure
            ///elements are added to the back and removed from the front
            ////Operations:
            //Enqueue(T element) O(1)
            //Dequeue() O(1)
            //size() O(1)
            //IsEmpty() O(1)
            Queue<string> fishQueue = new Queue<string>(fishList);
            //made for scheduling tasks / handling requests in the order
            //they arrive / or simulating real-world queues like waiting lines

            // Display the data
            Console.WriteLine("Array:");
            foreach (var fish in fishArray)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(fish);
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("\nDictionary:");
            foreach (var fish in fishDictionary)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Key: {fish.Key}, Value: {fish.Value}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("\nStack:");
            while (fishStack.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(fishStack.Pop());
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("\nQueue:");
            while (fishQueue.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(fishQueue.Dequeue());
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static List<string> ReadFishData(string filePath)
        {
            var fishList = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        fishList.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Could not read the file: {e.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            return fishList;
        }
    }
}
