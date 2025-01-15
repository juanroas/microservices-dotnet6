using RestWithASPNETUdemy.Model;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace RestWithASPNETUdemy.Services.Implementation
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public PersonServiceImplementation() { }

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> test = new List<Person>();
            for (int i = 1; i <= 8; i++)
            {
              test.Add(MockPerson(i));
            }
            return test;
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindByID(long id)
        {
            var test = (id > 0) ? FindAll().Find(x => x.Id == id) : null;

            return  test;
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Juan" + i,
                LastName = "Roas" + i,
                Gender = "Male" + i,
                Address = "ES-BRAZIL" + i
            };
        }
    }
}
