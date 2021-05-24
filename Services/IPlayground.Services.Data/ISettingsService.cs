using System.Collections.Generic;

namespace IPlayground.Services.Data
{
    public interface ISettingsService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();
    }
}
