namespace SqlQueryBuilderCommon.Model
{
    public class DbConnectionString
    {
        public string InitialCatalog { get; set; }
        public string DataSource { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public DbConnectionString(string initialCatalog, string dataSource, string userName, string passWord)
        {
            InitialCatalog = initialCatalog;
            DataSource = dataSource;
            UserName = userName;
            PassWord = passWord;
        }

        public DbConnectionString()
        {
            
        }
    }
}