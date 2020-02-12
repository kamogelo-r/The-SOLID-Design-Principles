using System.Collections.Generic;
using System.Linq;

namespace TheSolidDesignPrinciples.Dependency_Inversion_Principle
{
    /// <summary>
    /// high level parts of the system should not
    /// depend on low level parts of the system
    /// directly, but through abstraction instead
    /// </summary>
    public class Person
    {
        public string Name;
    }

    /// <summary>
    /// low-level (the "would be" API)
    /// </summary>
    public class Relationships: IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((parent, Relationship.Child, parent));
        }

        /// <summary>
        /// instead of depending on a low-level module,
        /// we depend on an abstraction (IRelationshipBrowser)
        /// </summary>
        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return relations.Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent)
                            .Select(x => x.Item3);
        }

        // making a public getter
        //public List<(Person, Relationship, Person)> Relations => relations;
    }

    public enum Relationship
    {
        Parent, Child, Sibling
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }
}