using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSolidDesignPrinciples.Dependency_Inversion_Principle
{
    /// <summary>
    /// high level parts of the system should not
    /// depend on low level parts of the system
    /// directly, but through abstraction instead
    /// </summary>
    public class Person
    {
        public string name;
    }

    /// <summary>
    /// low-level
    /// </summary>
    public class Relationships
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((parent, Relationship.Child, parent));
        }
    }

    public enum Relationship
    {
        Parent, Child, Sibling
    }
}
