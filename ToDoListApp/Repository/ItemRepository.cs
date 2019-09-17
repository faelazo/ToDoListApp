

namespace ToDoListApp.Repository
{
    public class ItemRepository
    {
        public int id { get ; set ; }
        public string description { get ; set ; }
        public string state { get ; set ; }
        public int userID { get ; set ; }

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                ItemRepository p = (ItemRepository)obj;
                return (id == p.id);
            }
        }

        public override int GetHashCode()
        {
            return id^2;
        }
    }
}
