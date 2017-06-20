using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ngVega.Models
{
    public class Make
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }

        // Collections should be initialised in the constructor so that it does
        // not need to be initialised every time the a new Make object is created
        public Make()
        {
            Models = new Collection<Model>();
        }
    }
}