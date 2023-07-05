namespace minecraftsaas.DB {
    public class Server {
    
        public string serverName { get; set; }
    
        public string ip { get; set; }
    
        public string containerID { get; set; }
    
        public Guid? settingsID { get; set; }
    
        public ServerSettings settings { get; set; }
    
        public List<User> admin { get; set; }

        public List<string> whitelist { get; set; }

    }
}