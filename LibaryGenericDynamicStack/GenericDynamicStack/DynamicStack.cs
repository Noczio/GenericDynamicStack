using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtLibraries
{
    public class DynamicStack<T>
    {
        #region Atributes

        Node First;
        Node Last;
        int Lenght;

        #endregion

        #region Constructor

        public DynamicStack()
        {
            this.First = null;
            this.Last = null;
            this.Lenght = 0;
        }

        #endregion

        #region Destructor
        ~DynamicStack()
        {

        }
        #endregion

        #region Methods

        private Node Find(int position)
        {
            Node auxnode = null;
            if (!Empty())
            {
                auxnode = this.Last;
                for (int i = this.Lenght; i >= 1; i--)
                {
                    if (position == i)
                    {
                        break;
                    }
                    auxnode = auxnode.next;
                }
            }

            return auxnode;
        }

        public T[] ToArray()
        {         
            T[] array = new T[this.Lenght];

            for (int i = this.Lenght; i >= 1; i--)
            {
                Node auxnode = this.Find(i);

                array[this.Lenght-i] = auxnode.info;

            }

            return array;
        }

        public int StackLength()
        {

            return this.Lenght;
        }

        public bool Empty()
        {
            return (this.Lenght == 0);

        }       

        //Pops a node out of the stack
        public void Pop()
        {
            if (!Empty())
            {
                //Disassociates last node from the stack
                Node auxnode = this.Last;
                this.Last = this.Last.next;
                auxnode.next = null;
                //deleted node in console
                //Console.Write(auxnode.info);
                //frees memory
                Release(auxnode);
                this.Lenght -= 1;
            }

        }

        //add a node to the stack
        public void Push(T value)
        {
            Node nw = new Node();
            nw.info = value;

            if (this.First == null)
            {
                //stack is empty
                nw.next = null;
                this.First = nw;
                this.Last = nw;

            }
            else
            {
                //there's an existing node
                nw.next = this.Last;
                this.Last = nw;
            }

            //Stack counter
            this.Lenght += 1;
        }

        public T Front()
        {
            Node auxnode = new Node();

            if (!Empty())
            {

                auxnode = this.Last;

            }
            else
            {
                auxnode = null;
            }


            return auxnode.info;
        }

        public T Back()
        {
            Node auxnode = new Node();

            if (!Empty())
            {              
                auxnode = this.First;                             
            }
            else
            {
                auxnode = null;
            }


            return auxnode.info;
        }

        public void Print()
        {
            if (!Empty())
            {
                Node auxnode = this.Last;
                // Iterate the queue
                while (auxnode != null)
                {
                    Console.WriteLine(auxnode.info);
                    // Take the next node
                    auxnode = auxnode.next;
                }
            }
            else
            {
                Console.WriteLine("There's not elements");
            }
        }

        private void Release(Node node)
        {
            node = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        #endregion

        #region Inner class

        private class Node
        {
            #region Atributes

            public Node(T info)
            {
                _next = null;
                _info = info;
            }

            public Node()
            {

            }

            private Node _next;
            public Node next
            {
                get { return _next; }
                set { _next = value; }
            }

            // T as private member data type.          
            private T _info;
            // T as return type of property.            
            public T info
            {
                get { return _info; }
                set { _info = value; }
            }

            #endregion

            #region Destructor
            ~Node()
            {
            }
            #endregion

        }
        #endregion
    }
}
