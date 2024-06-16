using Microsoft.Data.SqlClient;
using System.Data;

namespace Giggle_Garments_MVC.Models.Repositories
{
    public class StockRepository
    {
        string connectionstr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = GiggleGarmentsDB; Integrated Security = True;";
        List<Stock> stocks = new List<Stock>();
        IRepository<Stock> _repository = new GenericRepository<Stock>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = GiggleGarmentsDB; Integrated Security = True;");
        public void Add(Stock s)
        {

            _repository.Add(s);
        }
        public void Update(Stock s)
        {

            _repository.Update(s);

        }
        public IEnumerable<Stock> GetAll()
        {

            return _repository.GetAll();
        }
        public Stock GetbyId(int id)
        {

            return _repository.GetById(id); 
        }


    }
}
