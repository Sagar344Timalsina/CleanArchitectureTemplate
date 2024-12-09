using Shared.Utils.Wrapper;

namespace WebApi.Helpers.Http
{
    public interface IHttpServices
    {
        Task<IResponse<T>> GetAsync<T>(string url);
        Task<IResponse<T>> PostAsJsonAsync<T>(string url, object Data);
        Task<IResponse<T>> DeleteAsync<T>(string url);
    }
}
