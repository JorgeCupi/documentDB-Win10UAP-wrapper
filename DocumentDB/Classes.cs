using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTChallenge.Universal.Core
{
    public class genericDocument
    {
        public string id { get; set; } // Assigned ID 
        public string _rid { get; set; } // Auto Generated ID 
    }

    public class genericDocumentsCollection
    {
        public string _rid { get; set; } //Auto Generated ID
        public List<genericDocument> Documents { get; set; } // List of documents in the collection
        public int _count { get; set; } // Number of documents within the collection

    }
}
