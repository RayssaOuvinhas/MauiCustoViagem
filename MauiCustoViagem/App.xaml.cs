using MauiCustoViagem.Helpers;

namespace MauiCustoViagem
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db;

        public static SQLiteDatabaseHelper db
        {
            get
            {
                if (_db == null)
                {
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "banco_sqlite_viagem.db3");

                    _db = new SQLiteDatabaseHelper(path);
                }

                return _db;
            }
        }

        static SQLiteDatabaseHelperPedagio _db_pedagio;

        public static SQLiteDatabaseHelperPedagio dbPedagio
        {
            get
            {
                if (_db_pedagio == null)
                {
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "banco_sqlite_pedagio.db3");

                    _db_pedagio = new SQLiteDatabaseHelperPedagio(path);
                }

                return _db_pedagio;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
