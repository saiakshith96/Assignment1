using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b = 22;
            printSelfDividingNumbers(a, b);
            

            int n2 = 5;
            printSeries(n2);

            int n3 = 5;
            printTriangle(n3);

            int[] J = new int[] { 1, 3 };
            int[] S = new int[] { 1, 3, 3, 2, 2, 2, 2, 2 };
            int r4 = numJewelsInStones(J, S);
            Console.WriteLine(r4);

           int[] arr1 = new int[] { 1, 2, 5, 6, 7, 8, 9 };
            int[] arr2 = new int[] { 1, 2, 3, 4, 5 };
            int[] r5 = getLargestCommonSubArray(arr1, arr2);
            displayArray(r5);

            /*solvePuzzle();*/



        }
        public static void displayArray(int[] r5)
        {
            foreach (int elem in r5)
                Console.WriteLine(elem);

        }
        public static void printSelfDividingNumbers(int x, int y)
        {
            try
            {
                ArrayList res = new ArrayList();
                for (int a=x;a<=y;a++)
                {
                    Boolean check = isSelfDividing(a); //call method to check whether numbere in series is self divding or not
                    if (check)
                        res.Add(a);
                                          
                }
                string result = "";
                foreach(int item in res)
                {
                    result=result+item+",";  //adding , for each result
                }
                Console.WriteLine(result.TrimEnd(',')); // we don't need , for last element.
                
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSelfDividingNumbers()");
            }
            

        }
        /*internal Method for printSelfDividingNumbers*/
        public static Boolean isSelfDividing(int i)
        {
            int check = 0;
            int temp = 0;
            int num = i; //assign num=i so that value of num don't change while we change dynamically value of i in loop
            String s = i.ToString(); //finding length of number so that for loop needs to be runned that number of times
            int length = s.Length;
            
            for (int j = 0; j < length; j++)
            {
                
                temp = i % 10; // to find each and every digit in number
                  
                   i = i / 10; 
                if (temp!=0 ) //if remainder is 0 we don't require the number as any number divide by zero is not defined.
                {
                    if(num%temp==0)
                    check++; //if number is divided by digit then increment the check value
                }
            } 
            if (check == length) //if the incremented value and lenght of number is ssam it concludes each and every digit in number divides the number
            {
                return true;
            }
            else return false;

        }

        public static void printSeries(int n)
        {
            try
            {
                int count1 = 1, m = 0, k = 0;
                ArrayList res = new ArrayList();
                while (count1 <= n) //run loop till value of input 'n'
                {
                    m = count1;
                    for (int i = 1; i <= count1; i++)
                    {
                        if (k < n)
                        {
                            res.Add(m);
                            k++;
                        }
                        else break;

                    }
                    count1++;
                }
                string result = "";
                foreach (int item in res)
                {
                    result = result + item + ",";  //adding , for each result
                }
                Console.WriteLine(result.TrimEnd(',')); // we don't need , for last element.

            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSeries()");
            }
        }

        public static void printTriangle(int n)
        {
            try
            {
                for (int x = 0; x < n; x++)
                {
                    for (int y = 0; y <= (2 * n) - 1; y++) //for prinitng till 2*n -1 places
                    {
                        if (y <= x || y > (2 * n) -x-1) // to print 'space' only at these conditions
                            Console.Write(" ");
                        else Console.Write("*"); //remaining print *
                    }
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }

        }

        public static int numJewelsInStones(int[] J, int[] S)
        {
            try
            {
                int value = 0;
                for (int i = 0; i < J.Length; i++)
                {
                    for (int j = 0; j < S.Length; j++)
                    {
                        if (J[i] == S[j]) //compare each and every element
                        {
                            value += 1; //if they are equal then increment the value.
                        }
                    }
                }
                return value;

            }
            catch
            {
                Console.WriteLine("Exception occured while computing numJewelsInStones()");
            }

            return 0;
        }


        public static int[] getLargestCommonSubArray(int[] a, int[] b)
        {
            try
            {
                // creating  hashset  common to find the common numbers between two arrays and also eliminate any dummy values
                HashSet<int> h_s = new HashSet<int>();
                // Sorting two input arrays in ascending order 
                Array.Sort(a);
                Array.Sort(b);
                // Run Loop to find common elements
                for (int i = 0; i < a.Length; i++)
                {
                    for (int j = 0; j < b.Length; j++)
                    {
                        if (a[i] == b[j])
                        {
                            h_s.Add(a[i]);
                        }
                    }
                }
               
                // Create a dictionary 'd' to store value of sum as key and Contigous array in list of int
                Dictionary<int, List<int>> d = new Dictionary<int, List<int>>();
                
                foreach (int y in h_s)
                {
                    // storing the current value
                    int x = y;
                    // initializing the 'add' of contigous array to zero as if we get 2 sub arrays of same length we need to consider the sub array with largest eleemts hence calculatinf sum
                    int add = 0;
                    // Creating new list  to store contigous array elements temporarily 
                    List<int> element = new List<int>();
                   //Check if the current value has next consequtive value or not
                    if (h_s.Contains(x + 1))
                        // while loop to get contigous array whether the first element of any contigous array is present 
                        while (h_s.Contains(x))
                        {                          
                            add+= x;
                            // adding each element of contigous array to 'element'
                            element.Add(x);
                            x++;
                        }
                    // check if the contigous array 'add' as a key present in the dictionary 
                    if (!d.ContainsKey(add))
                                           
                        d.Add(add, element); // adding the key 'sum' of contigous array and 'value' contigous array list to dictionary 
                    
                }
                // find the highest key value
                int max_sum = d.Keys.Max();
                // getting the array list of corresponding key value from above
                List<int> final = d[max_sum];
                // converting list to array 
                return final.ToArray();
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getLargestCommonSubArray()");
                return null;
            }

            
        }





    }
}
