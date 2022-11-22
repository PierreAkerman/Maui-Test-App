

namespace MobileAppMaui.Models
{
    public class TechnicianModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public TechnicianModel()
        {

        }
        public TechnicianModel(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public TechnicianModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
