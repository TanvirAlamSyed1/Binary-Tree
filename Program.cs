using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using node;
using Binary_tree;
using Bs_tree;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bool end = false;//ends code once user is done
            BSTree<string> mytree = new BSTree<string>(); //  create a new Binary Search Tree


            while (end != true)// whilst user hasn't entered end
            {
                Console.WriteLine("add,traverse,height,total,contains,end");//print comands
                Console.WriteLine("Please choose the following options");
                string ans = Console.ReadLine();//take the input of the user in
                ans.ToLower();//convert all to lower case
                if ( ans == "add") //if add
                {
                    Console.WriteLine("please enter the STRING you want to add to the tree");
                    string word = Console.ReadLine();//take in users answer
                    if (word.Length != 0  )// check if word is empty
                    {
                        mytree.InsertItem(word);//insert word into tree
                    }
                    else
                    {
                        Console.WriteLine("Error");//print error message
                    }
                }
                else if ( ans == "traverse")
                {
                    Console.WriteLine("InOrder,PreOrder,PostOrder");
                    Console.WriteLine("please enter the TRAVERSE you want to use");
                    string word = Console.ReadLine();//take in users answer
                    word.ToLower();//convert all to lower case
                    if( word == "inorder")
                    {
                        string buffer = "";// creates an empty string 
                        mytree.InOrder(ref buffer);// in function adds onto the string
                        Console.WriteLine(buffer);
                    }
                    else if( word == "preorder")
                    {
                        string buffer = "";
                        mytree.PreOrder(ref buffer); ;
                        Console.WriteLine(buffer);
                    }
                    else if(word == "postorder")
                    {
                        string buffer = "";
                        mytree.PostOrder(ref buffer); ;
                        Console.WriteLine(buffer);
                    }
                    else
                    {
                        Console.WriteLine("Error");//error message
                    }
                }
                else if (ans == "height")
                {
                    int height = mytree.FindHeight();
                    Console.WriteLine("height of the tree is: " + height.ToString() );
                }
                else if ( ans == "contains")
                {
                    Console.WriteLine("please enter the STRING you want to search for");
                    string word = Console.ReadLine();//take in users answer
                    if (word.Length != 0)// check if word is empty
                    {
                        Console.WriteLine(mytree.Contain(word));//insert word into tree
                    }
                    else
                    {
                        Console.WriteLine("Error");//print error message
                    }
                }
                else if(ans == "total")
                {
                    int total = 0;
                    total = mytree.Count();
                    Console.WriteLine("The total amount of items in the tree is: " + total.ToString() );
                }
                else if (ans == "end")
                {
                    end = true;
                    Console.WriteLine("Goodbye!");
                }
                else
                {
                    Console.WriteLine("Error");
                }

            }
        }
    }
}
