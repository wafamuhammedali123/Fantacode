using System;
namespace MyStack
{
    class NewStack<T>
    {
        int size;
        int top;
        T[] Array;
        
        public NewStack(int s)
        {
           size=s;
           top=-1;
           Array=new T[size];
        }
        public int push(T variable)
        {
            if(top==size-1)
            {
                return -1;
            }
            else
            {
                top=top+1;
                Array[top]=variable;
                return 0;
            }
        }
        public T pop()
         {
             T popelement;
             if(top!=-1)
             {
                 popelement=Array[top];
                 top=top-1;
                 return popelement;
            }
          return default(T);
         }
         public T peep(int pos)
         {
             T temp=default(T);
             if(pos>=0&&pos<size)
             {
                 return Array[pos];
             }
             return temp;
         }
    }
    class Stacks
    {
        public static void Main(string[] args)
        {
            int s;
            Console.WriteLine("Enter the size of the stack");
            s=int.Parse(Console.ReadLine());
            NewStack<object> obj=new NewStack<object>(s);
            
              

            while(true)
        {
            Console.WriteLine("1.PUSH");
            Console.WriteLine("2.POP");
            Console.WriteLine("3.PEEP");
            Console.WriteLine("4.EXIT");
            Console.WriteLine("Enter your choice");
            int choice=int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                {
                    Console.WriteLine("Enter the element to push");
                    object el = Console.ReadLine();
                    int r=obj.push(el); 
                    if(r!=-1)
                    {
                        Console.WriteLine("Element has been pushed to stack");
                    }
                    else
                    {
                        Console.WriteLine("Stack Overflow");
                    }
                    break;
                }
                case 2:
                {
                    object result = obj.pop();
                    if(result!=null)
                    {
                        Console.WriteLine("Deleted element : "+result);
                    }
                    else{
                        Console.WriteLine("Stack underflow!");
                    }
                break;
                }
                case 3:
                {
                    Console.WriteLine("Enter the position :");
                    int p = int.Parse(Console.ReadLine());
                    object r = obj.peep(p);

                    if(r!=null)
                    {
                        Console.WriteLine("Element at " + p + " is "+ r);
                    }
                 break;   
                }
                case 4: 
                {
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid choice!");
                    break;
                }
            }
        }

        
    }
    
    }
}