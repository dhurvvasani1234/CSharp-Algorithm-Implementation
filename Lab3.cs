/*---------------------------------------------------------------------------
 *                Lab 3 - Dhruv Vasani
 * 
 * 
 * Objective: Implementation of Bubble sort, Linear search and Binary search
 * --------------------------------------------------------------------------
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class 
        Lab3
    {
        static int[] intArray = {17,  166,  288,  324,  531,  792,  946,  157,  276,  441, 533, 355, 228, 879, 100, 421, 23, 490, 259, 227,
                                 216, 317, 161, 4, 352, 463, 420, 513, 194, 299, 25, 32, 11, 943, 748, 336, 973, 483, 897, 396,
                                 10, 42, 334, 744, 945, 97, 47, 835, 269, 480, 651, 725, 953, 677, 112, 265, 28, 358, 119, 784,
                                 220, 62, 216, 364, 256, 117, 867, 968, 749, 586, 371, 221, 437, 374, 575, 669, 354, 678, 314, 450,
                                 808, 182, 138, 360, 585, 970, 787, 3, 889, 418, 191, 36, 193, 629, 295, 840, 339, 181, 230, 150 };


        static void Main(string[] args)
        {
            int[] sortedArray = new int[100];

            // Print the original unsorted array
            Console.Write("The initial unsorted array is:\n");
            for (int i = 0; i < intArray.Length; i++)
            {
                if (i != intArray.Length - 1)
                {
                    Console.Write("{0}, ", intArray[i]);
                }
                else
                {
                    Console.Write("{0} ", intArray[i]);
                }
            }
            Console.WriteLine();

            // Copy the elements to a new array
            Array.Copy(intArray, sortedArray, intArray.Length);
            // Call BubbleSort function
            int bubbleSortSwaps = BubbleSort(sortedArray);

            Console.WriteLine("\nBubble sort made {0} swaps to sort this array", bubbleSortSwaps);
            Console.WriteLine("\nThe sorted array is:");

            // Print the new sorted array
            for (int i = 0; i < sortedArray.Length; i++)
            {
                if (i != sortedArray.Length - 1)
                {
                    Console.Write("{0}, ", sortedArray[i]);
                }
                else
                {
                    Console.Write("{0} ", sortedArray[i]);
                }
            }
            Console.WriteLine();

            while (true)
            {
                // Ask the user to enter an integer to search
                Console.WriteLine("Enter an integer to search:\t");
                string userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.Write("You have not entered any value. Please enter an integer to search\n");
                } else
                {
                    int searchNeedle = int.Parse(userInput);

                    // Call LinearSearch method on unsorted array
                    int linearComparisons;
                    int linearSearchIndex = LinearSearch(intArray, searchNeedle, out linearComparisons);

                    if (linearSearchIndex != -1)
                    {
                        Console.WriteLine("\nLinear search made {0} comparisons to find out that {1} is at index {2} in this unsorted array", linearComparisons, searchNeedle, linearSearchIndex);
                    } else
                    {
                        Console.WriteLine("\nLinear search made {0} comparisons to find out that {1} is not in this unsorted array", linearComparisons, searchNeedle);
                    }

                    // Call BinarySearch method on the sorted array
                    int binaryComparisons;
                    int binarySearchIndex = BinarySearch(newArray, searchNeedle, out binaryComparisons);

                    if (binarySearchIndex != -1)
                    {
                        Console.WriteLine("\nBinary search made {0} comparisons to find out that {1} is at index {2} in this sorted array", binaryComparisons, searchNeedle, binarySearchIndex);
                    } else
                    {
                        Console.WriteLine("\nBinary search made {0} comparisons to find out that {1} is not in this sorted array", binaryComparisons, searchNeedle);
                    }

                    // Step 8: ask user to search another integer
                    Console.WriteLine("\nDo you want to search another integer (Y/N)?\t");
                    string tryAgain = Console.ReadLine();

                    // condition to try again
                    if (tryAgain == "y" || tryAgain == "Y")
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("\nThank you! Press 'Enter' to finish");
                        Console.ReadLine();
                        break;
                    }
                }
                
            }
        }

        static int LinearSearch(int[] haystack, int niddle, out int numOfComparison)
        {
            numOfComparison = 0;
            int niddleIndex = -1;

            // linear search algorithm
            for (int i = 0; i < haystack.Length; i++)
            {
                numOfComparison++;

                if (haystack[i] == niddle)
                {
                    niddleIndex = i;

                    return niddleIndex;
                }
            }

            return niddleIndex;
        }// Linear Search


        static int BubbleSort(int[] arr)
        {
            int numOfSwaps = 0;
            int arrLength = arr.Length;
            
            // loop to iterate through the array
            for (int i = 0; i < arrLength - 1; i++)
            {
                // inner-loop to iterate through array and make comparisons between the adjacent elements in array
                for (int j = 0; j < arrLength - i - 1; j++)
                {
                    // compare the adjacent elements in array
                    if (arr[j] > arr[j+1])
                    {
                        // temporary variable
                        int temp = arr[j];

                        // swap temp and arr[i]
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        // increment the swap count
                        numOfSwaps++;
                    }
                }
            }

            return numOfSwaps;
        }// Bubble Sort

        static int BinarySearch(int[] haystack, int niddle, out int numOfComparison)
        {
            numOfComparison = 0;
            int niddleIndex = -1, low = 0, high = haystack.Length - 1, mid;

            // find the index of middle element
            mid = (low + high) / 2;

            while (low <= high)
            {
                // iterate until lower index is less than or equals to higher-index
                numOfComparison++;

                // determine the middle element
                if (haystack[mid] == niddle)
                {
                    // return the middle element index
                    return mid;
                }
                else if (niddle < haystack[mid])
                {
                    // remove second-half of the array
                    high = mid - 1;
                }
                else
                {
                    // remove first-half of the array
                    low = mid + 1;
                }

                // update middle index
                mid = (low + high) / 2;
            }


            return niddleIndex;
        } // Binary Search
    }
}
