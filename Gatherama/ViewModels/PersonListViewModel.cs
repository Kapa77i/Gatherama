using Gatherama.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherama.ViewModels
{
    public class PersonListViewModel
    {
        public ObservableCollection<List<PersonDto>> persons { get; set; }
    }
}
