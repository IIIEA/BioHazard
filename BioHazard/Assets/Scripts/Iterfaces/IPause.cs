public interface IPause
{
    void Pause();
    void Resume();
    bool IsPaused { get; set; }
}
