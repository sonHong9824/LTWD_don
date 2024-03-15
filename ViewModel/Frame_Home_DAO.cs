using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Market.Model;
namespace WPF_Market.ViewModel
{
    public static class Frame_Home_DAO
    {
        public static ImagesLinkedList imagesLinkedList = null;
        public static Node INode;
        public static void InitializedLinkedList()
        {
            imagesLinkedList = new ImagesLinkedList();
            SQLConnection.conn.Open();
            string command = string.Format("Select * from Image_link");
            SqlCommand sqlCommand = new SqlCommand(command, SQLConnection.conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                imagesLinkedList.AddNode(reader["Image_link"].ToString());
         
            }
            SQLConnection.conn.Close();
            INode = new Node();
            INode = imagesLinkedList.Head;
        }

        public static string GetImageLink()
        {
            string link = INode.Value;
            INode = INode.Next;
            return link;
        }
    }
    public class Node
    {
        string value;
        Node next = null;

        public Node()
        {
        }

        public string Value { get => value; set => this.value = value; }
        internal Node Next { get => next; set => next = value; }
    }
    public class ImagesLinkedList
    {
        Node head = null;
        Node tail = null;

        public ImagesLinkedList()
        {
        }

        public ImagesLinkedList(string headvalue)
        {
            Head = new Node();
            Head.Value = headvalue;
            
            Tail = new Node();
            Tail.Next = Head;
            Tail.Value = null;
            head.Next =tail;
        }
        public void AddNode(string value)
        {
            if (Head == null)
            {
                Head = new Node();
                Head.Value = value;

                Tail = new Node();
                Tail = head;
                return;
            }

            Node node = new Node();
            node.Value = value;

            Tail.Next = node;
            Tail = node;
            Tail.Next = head;
        }

        internal Node Tail { get => tail; set => tail = value; }
        internal Node Head { get => head; set => head = value; }
    }
}
