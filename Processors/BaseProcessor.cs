namespace OperationalStorage.Processors
{
    public class BaseProcessor
    {
        public string Path { get; set; }

        public BaseProcessor(string path)
        {
            Path = path;
        }
    }
}
