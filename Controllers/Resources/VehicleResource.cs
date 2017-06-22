using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ngVega.Controllers.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        // The model is included so that we don't have to import a new Model 
        // object from the DbContext when populating the edit vehicle form
        public bool IsRegistered { get; set; }

        public ContactResource Contact { get; set; }
        public ICollection<int> Features { get; set; }

        public VehicleResource()
        {
            Features = new Collection<int>();
        }
    }
}