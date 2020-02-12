using System;
using TheSolidDesignPrinciples.Dependency_Inversion_Principle;

namespace TheSolidDesignPrinciples
{
    class Program
    {
        //accessing low-level modules in the high-level module
        //public Program(Relationships relationships)
        //{
        //    var relations = relationships.Relations;
        //    foreach (var relation in relations.Where(x => x.Item1.Name == "John" &&x.Item2 == Relationship.Parent))
        //    {   
        //        Console.WriteLine($"John has a child called {relation.Item3.Name}");
        //    }
        //}

        public Program(IRelationshipBrowser relationshipBrowser)
        {
            foreach (var item in relationshipBrowser.FindAllChildrenOf("John"))
            {
                Console.WriteLine($"John has a child called {item.Name}");
            }
        }

        static void Main(string[] args)
        {
            // Dependency Inversion Principle
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            // access the low-level module in the high-level module
            // the relationship class cannot change how it stores
            // the relationships/data
            var relationships = new Relationships();
            relationships.AddParentChild(parent, child1);
            relationships.AddParentChild(parent, child2);

            new Program(relationships);

            Console.ReadLine();
        }
    }
}