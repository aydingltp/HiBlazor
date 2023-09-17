namespace HiBlazor.SPA.Entity.VmModels
{
    public class ResultVm
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
    public class ResultVm<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
