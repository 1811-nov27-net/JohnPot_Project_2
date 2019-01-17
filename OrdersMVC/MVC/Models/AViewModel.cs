using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public abstract class AViewModel
    {
        public static List<AViewModel> Models = new List<AViewModel>();

        public AViewModel()
        {
            Id = NextId;
            Models.Add(this);
        }

        public int Id { get; set; }
        public static int NextId { get => (Models.Count <= 0) ? 1 : Models.Max(m => m.Id) + 1; }
        public string Name { get; set; }

        public static AViewModel GetById(int id)
        {
            return Models.FirstOrDefault(m => m.Id == id);
        }
        public static AViewModel GetByName(string name)
        {
            if (name == null)
                return null;

            return Models.FirstOrDefault(m => m.Name == name);
        }
    }
}
