using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSolidDesignPrinciples.Dependency_Inversion_Principle;

namespace TheSolidDesignPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dependency Inversion Principle
            var parent = new Person { name = "John" };
            var child1 = new Person { name = "Chris" };
            var child2 = new Person { name = "Mary" };

            //access the low-level module in the high-level module
            var relationships = new Relationships();
            relationships.AddParentChild(parent, child1);
            relationships.AddParentChild(parent, child2);

            Console.ReadLine();
        }
    }
}
