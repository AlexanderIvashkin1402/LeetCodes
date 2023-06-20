namespace Monarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMonarchy mon = new Monarchy("Jake");
            mon.Birth("Catherine", "Jake");
            mon.Birth("Tom", "Jake");
            mon.Birth("Celine", "Jake");
            mon.Birth("Peter", "Celine");
            mon.Birth("Jane", "Catherine");
            mon.Birth("Farah", "Jane");
            mon.Birth("Mark", "Catherine");
            var firstOrder = mon.GetOrderOfSuccession();

            mon.Death("Jake");
            mon.Death("Jane");
            var secondOrder = mon.GetOrderOfSuccession();

            Console.WriteLine(string.Join(",", firstOrder.ToArray()));
            Console.WriteLine(string.Join(",", secondOrder.ToArray()));
        }
    }

    public interface IMonarchy
    {
        void Birth(string childName, string parentName);
        void Death(string name);
        List<string> GetOrderOfSuccession();
    }

    public class Monarchy : IMonarchy
    {
        private Person _king { get; set; }
        private Dictionary<string, Person> _persons;
        public Monarchy(string king)
        {
            _king = new Person(king);
            _persons = new Dictionary<string, Person>();
            _persons[king] = _king;
        }

        public void Birth(string childName, string parentName)
        {
            var parent = _persons.ContainsKey(parentName) ? _persons[parentName] : null;
            if (parent == null) return;
            
            var newChild = new Person(childName);

            parent.Children.Add(newChild);
            _persons[childName] = newChild;
        }

        public void Death(string name)
        {
            var person = _persons.ContainsKey(name) ? _persons[name] : null;
            if (person == null) return;
            person.IsAlive = false;
        }

        public List<string> GetOrderOfSuccession()
        {
            var order = new List<string>();
            Dfs(_king, order);
            return order;
        }

        void Dfs(Person currentPerson, IList<string> order)
        {
            if (currentPerson.IsAlive)
            {
                order.Add(currentPerson.Name);
            }

            foreach (var child in currentPerson.Children)
            {
                Dfs(child, order);
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public bool IsAlive { get; set; }
        public List<Person> Children { get; set; }
        public Person(string name) 
        {
            Name = name;
            IsAlive = true;
            Children = new List<Person>();
        }
    }
}