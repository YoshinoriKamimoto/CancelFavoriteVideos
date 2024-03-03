namespace CancelFavoriteVideos.Models
{
    // Chromeプロフィール情報
    internal class ChromeProfile
    {
        public string Path { get; private set; }
        public string Name { get; private set; }

        public ChromeProfile(string path, string name)
        {
            this.Path = path;
            this.Name = name;
        }
    }
}
