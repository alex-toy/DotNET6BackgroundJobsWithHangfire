namespace HangFireApp.Services
{
    public class ServiceManagement : IServiceManagement
    {
        public void GenerateMerchandise()
        {
            Console.WriteLine($"Generate merchandise - {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        }

        public void SendMail()
        {
            Console.WriteLine($"Send mail - {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        }

        public void SyncData()
        {
            Console.WriteLine($"Sync data - {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        }

        public void UpdateDatabase()
        {
            Console.WriteLine($"Upadte database - {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        }
    }
}
