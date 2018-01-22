using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalWork_Serv
{
    public class Product
    {
        int id;
        string name;
        string category;
        int price;

        //public Product(int Id, string Name, string Category, int Price)
        //{
        //    this.category = Category;
        //    this.id = Id;
        //    this.name = Name;
        //    this.price = Price;
        //}

        public int Price { get => price; set => price = value; }
        public string Category { get => category; set => category = value; }
        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
    }
}