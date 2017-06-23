using System.Collections.Generic;
using System.Collections.ObjectModel;
using ngVega.Models;

namespace ngVega.Controllers.Resources
{
    public class MakeResource : KeyValuePairResource
    {
        public ICollection<KeyValuePairResource> Models { get; set; }

        // Collections should be initialised in the constructor so that it does
        // not need to be initialised every time the a new Make object is created
        public MakeResource()
        {
            Models = new Collection<KeyValuePairResource>();
        }
    }
}