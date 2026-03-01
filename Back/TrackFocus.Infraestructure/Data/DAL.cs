namespace TrackFocus.Infraestructure.Data
{
    public class DAL<T> where T : class
    {
        private readonly AppDbContext _appContext;

        public DAL(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        
    }
}