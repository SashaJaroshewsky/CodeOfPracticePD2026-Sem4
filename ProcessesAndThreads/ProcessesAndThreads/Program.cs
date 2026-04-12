namespace ProcessesAndThreads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Console.WriteLine("==========================================");

            //ProcessDefinition processDefinition = new ProcessDefinition();
            //processDefinition.ShowProcessInfo();
            //processDefinition.StartNewProcess();

            //Console.WriteLine("==========================================");

            //ThreadDefinition threadDefinition = new ThreadDefinition();
            //threadDefinition.ShowThreadInfo();
            //threadDefinition.StartNewThread();

            //Console.WriteLine("==========================================");

            //ForegroundVsBackground foregroundVsBackground = new ForegroundVsBackground();
            //foregroundVsBackground.ForegroundThreadExample();
            //foregroundVsBackground.BackgroundThreadExample();

            //Console.WriteLine("==========================================");

            //foregroundVsBackground.TaskExample();

            //Synchronization synchronization = new Synchronization();
            //synchronization.RaceConditionExample();
            //synchronization.SynchronizationExample();

            ThreadPoolDefinition pool = new ThreadPoolDefinition();
            pool.Example();
        }
    }
}
