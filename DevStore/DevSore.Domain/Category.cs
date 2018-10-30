using System.Collections;
using System.Collections.Generic;

namespace DevSore.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }

 
        public override string ToString()
        {
            return this.Title; 
        }
    }
}