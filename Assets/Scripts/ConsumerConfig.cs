public struct ConsumerConfig {
    public string Topic { get; set; }
    public string Servers { get; set; }
    public int PollingRateMs { get; set; }
}
